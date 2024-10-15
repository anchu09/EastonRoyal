using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

/// <summary>
/// Controls the large dungeon lever that activates the puzzle pieces and reveals
/// the lighting panel. Called from a Unity Inspector event when the player pulls
/// the lever in VR.
/// </summary>
public class Lever : Singleton<Lever>
{
    public GameObject[] puzzlePieces;

    public GameObject[] luces;

    public GameObject restartButton;

    public GameObject leverPivot;

    public GameObject missionCompleteIcon;

    public GameObject missionInProgressIcon;

    private bool _isSolved;

    // Public interaction entry point (called from Unity Inspector event)

    /// <summary>
    /// Fires the lever: enables puzzle piece interactivity, activates lights,
    /// plays the lever animation and sound, and updates player progress.
    /// Safe to call multiple times — only executes once.
    /// </summary>
    public void ActivateGeneralLights()
    {
        if (_isSolved) return;
        _isSolved = true;

        leverPivot.GetComponent<Animator>().SetTrigger("Lever");

        for (int i = 0; i < puzzlePieces.Length; i++)
            puzzlePieces[i].GetComponent<XRGrabInteractable>().enabled = true;

        for (int i = 0; i < luces.Length; i++)
            luces[i].SetActive(true);

        restartButton.GetComponent<XRGrabInteractable>().enabled = true;

        AudioManager.Instance.PlayLeverClick();
        AudioManager.Instance.PlayNarrationLookGood();

        DataManager.Instance.CurrentPlayer.leverPulled  = true;
        DataManager.Instance.CurrentPlayer.progress += GameConstants.ProgressPerPuzzle;

        missionCompleteIcon.SetActive(true);
        missionInProgressIcon.SetActive(false);
    }
}
