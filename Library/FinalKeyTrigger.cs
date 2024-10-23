using UnityEngine;

/// <summary>
/// End-game trigger. When the final key enters this collider the game is marked
/// as complete: the victory canvas is shown, audio plays, HUD is updated, and
/// the player's progress is advanced.
/// </summary>
public class FinalKeyTrigger : Singleton<FinalKeyTrigger>
{
    public GameObject canvasFinal;

    public GameObject missionCompleteIcon;

    public GameObject missionInProgressIcon;

    // Ensures the completion sequence fires only once.
    private bool _triggered = false;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag(GameConstants.TagFinalKey))
            OnGameComplete();
    }

    /// <summary>
    /// Executes the game-complete sequence. Safe to call externally (e.g. debug
    /// menu); silently no-ops if already triggered.
    /// </summary>
    public void OnGameComplete()
    {
        if (_triggered)
            return;

        _triggered = true;
        canvasFinal.SetActive(true);
        DataManager.Instance.CurrentPlayer.gameCompleted = true;
        DataManager.Instance.CurrentPlayer.progress += GameConstants.ProgressPerPuzzle;
        missionCompleteIcon.SetActive(true);
        missionInProgressIcon.SetActive(false);
        AudioManager.Instance.PlayVictory();
    }
}
