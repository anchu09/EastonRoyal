using System.Collections;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.UI;

/// <summary>
/// Central game manager. Owns the HUD timer and progress display, handles the
/// dungeon-to-library zone transition, and restores all puzzle state on load
/// (so players continue from where they left off).
/// </summary>
public class GameManager : Singleton<GameManager>
{
    private const string TriggerFade = "fade";

    public Text timeDisplay;
    public Text progressDisplay;
    public Text playerNameLabel;

    public GameObject dungeonZone;
    public GameObject libraryZone;
    public Transform librarySpawnPoint;
    public GameObject playerRig;
    public GameObject backgroundSphere;
    public GameObject sunLight;

    public AudioSource menuMusic;
    public AudioSource gameMusic;

    public string currentLevel = GameConstants.LevelDungeon;
    public bool gameStarted;

    private bool _transitionStarted;

    private float _secondAccumulator;
    public int playSeconds;
    public int playMinutes;
    public int playHours;

    private const float TriggerTransitionDelay = 2f;
    private const float LightingEnableDelay    = 1f;

    private void Awake()
    {
        gameStarted = true;

        // Parse saved elapsed time ("hh:mm:ss")
        string savedTime = DataManager.Instance.CurrentPlayer.playTime;
        string[] parts   = savedTime.Split(':');
        playHours    = ParseTimePart(parts, 0);
        playMinutes  = ParseTimePart(parts, 1);
        playSeconds = ParseTimePart(parts, 2);

        DataManager.Instance.CurrentPlayer.progress = 0;
        playerNameLabel.text = DataManager.Instance.CurrentPlayer.Name;

        AudioManager.Instance.PlayAmbientMusic1();

        RestorePuzzleState();

        backgroundSphere.GetComponent<Animator>().SetTrigger(TriggerFade);
    }

    private void Update()
    {
        _secondAccumulator += Time.deltaTime;
        if (_secondAccumulator < 1f) return;

        _secondAccumulator = 0f;
        playSeconds++;

        if (playSeconds == 60)
        {
            playMinutes++;
            playSeconds = 0;
            if (playMinutes == 60)
            {
                playHours++;
                playMinutes = 0;
            }
        }

        string timeString = $"{playHours:00}:{playMinutes:00}:{playSeconds:00}";
        timeDisplay.text = timeString;
        DataManager.Instance.CurrentPlayer.playTime = timeString;
        progressDisplay.text = DataManager.Instance.CurrentPlayer.progress.ToString("F0") + "%";
    }

    public void TransitionToLibrary()
    {
        if (_transitionStarted) return;
        _transitionStarted = true;
        StartCoroutine(ZoneTransitionRoutine());
    }

    private void RestorePuzzleState()
    {
        var player = DataManager.Instance.CurrentPlayer;

        if (player.matchFound)          Match.Instance.matchFoundcogida();
        else                         AudioManager.Instance.PlayNarrationWhereAmI();

        if (player.candleHolderLit)       CandleHolder.Instance.candleHolderLitactivado();
        if (player.codeReferenceFound) CodePhoto.Instance.OnPickedUp();
        if (player.lightPanelSolved)       LightPanel.Instance.CompletePuzzle();
        if (player.leverPulled)          Lever.Instance.ActivateGeneralLights();
        if (player.bigPuzzleSolved)      SlidingBlockPuzzle.Instance.OnPuzzleCompleted();
        if (player.noteFound)             NotePickup.Instance.CollectDungeonNote();

        // Restoring the chain also switches us to the library zone
        if (player.chainPulled)
        {
            ChainPull.Instance.TriggerChainDrop();
            ActivateLibraryZone();
        }

        if (player.drinksFound)                   DrinkBoard.Instance.drinksFoundHechas();
        if (player.booksFound)                    NotePickup.Instance.CollectBookshelfNote();
        if (player.balloonFound)                     Thumbtack.Instance.OnThumbTackPlaced();
        if (player.statueSolved)                   StatuePuzzle.Instance.statueSolvedhecha();
        if (player.chestOpened)               ChestLock.Instance.OnChestUnlocked();
        if (player.gameCompleted)              FinalKeyTrigger.Instance.OnGameComplete();
        if (player.deskNoteFound)  NotePickup.Instance.coger_notaEscritorio();
        if (player.logDrawerNoteFound)    NotePickup.Instance.CollectLogsNote();
        if (player.cageNoteFound)                 NotePickup.Instance.CollectCageNote();
    }

    private IEnumerator ZoneTransitionRoutine()
    {
        backgroundSphere.GetComponent<Animator>().SetTrigger(TriggerFade);

        yield return new WaitForSeconds(TriggerTransitionDelay);

        ActivateLibraryZone();

        yield return new WaitForSeconds(LightingEnableDelay);

        RenderSettings.ambientMode = AmbientMode.Skybox;
        sunLight.SetActive(true);

        backgroundSphere.GetComponent<Animator>().SetTrigger(TriggerFade);
    }

    private void ActivateLibraryZone()
    {
        dungeonZone.SetActive(false);
        libraryZone.SetActive(true);
        playerRig.transform.position = librarySpawnPoint.position;
        AudioManager.Instance.ambientMusic1.Stop();
        AudioManager.Instance.PlayAmbientMusic2();
        currentLevel = GameConstants.LevelLibrary;
    }

    private static int ParseTimePart(string[] parts, int index)
    {
        if (index >= parts.Length) return 0;
        return int.TryParse(parts[index], out int value) ? value : 0;
    }
}
