using UnityEngine;

/// <summary>
/// Thumbtack puzzle piece. When the player places this thumbtack on the correct
/// spot on the board the pin animation plays, the code paper is revealed, and
/// the player's progress advances by one puzzle increment.
/// The London photos drawer must have been interacted with first.
/// </summary>
public class Thumbtack : Singleton<Thumbtack>
{
    // Animator trigger name for the pin-into-board animation.
    private const string TriggerPin = "pin";

    public GameObject clueNote;

    public GameObject photoDrawer;

    public GameObject missionCompleteIcon;

    public GameObject missionInProgressIcon;

    // Animator retrieved at startup from a child object.
    private Animator _animator;

    // Prevents the puzzle from completing more than once.
    private bool _isPlaced = false;

    private void Start()
    {
        _animator = GetComponentInChildren<Animator>();
    }

    /// <summary>
    /// Plays the pin animation and, if the placement tag is correct and the
    /// London photos have been touched, completes the puzzle.
    /// Called by the VR interaction event when the thumbtack is dropped.
    /// </summary>
    public void TriggerPlacementAnimation()
    {
        _animator.SetTrigger(TriggerPin);

        if (CompareTag(GameConstants.TagThumbtackCorrect) &&
            photoDrawer.GetComponent<DeskDrawers>().tocadas)
        {
            OnThumbTackPlaced();
        }
    }

    /// <summary>
    /// Marks the thumbtack puzzle as complete: reveals the code paper,
    /// plays audio, and records progress. Safe to call externally; silently
    /// no-ops if already completed.
    /// </summary>
    public void OnThumbTackPlaced()
    {
        if (_isPlaced)
            return;

        _isPlaced = true;
        clueNote.SetActive(true);
        AudioManager.Instance.PlayPaperUnlocked();
        DataManager.Instance.CurrentPlayer.balloonFound = true;
        DataManager.Instance.CurrentPlayer.progress += GameConstants.ProgressPerPuzzle;
        missionCompleteIcon.SetActive(true);
        missionInProgressIcon.SetActive(false);
    }
}
