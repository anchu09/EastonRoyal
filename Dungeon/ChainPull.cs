using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

/// <summary>
/// Chain-pull puzzle. Pulling the ceiling chain triggers the staircase animation,
/// enables the trapdoor grab, records progress, and plays accompanying effects.
/// Idempotent — only triggers once per session.
/// </summary>
public class ChainPull : Singleton<ChainPull>
{
    private const string TriggerLowerChain = "lower";
    private const string TriggerExtendStairs = "staircase";

    [Header("Mission HUD")]
    public GameObject missionCompleteIcon;
    public GameObject missionInProgressIcon;

    [Header("Scene objects")]
    public GameObject staircase;
    public GameObject trampilla;
    public GameObject particulas;

    private bool _isTriggered;

    /// <summary>
    /// Lowers the chain, extends the staircase, enables the trapdoor grab, and saves progress.
    /// Safe to call multiple times — only the first call has any effect.
    /// </summary>
    public void TriggerChainDrop()
    {
        if (_isTriggered)
            return;

        _isTriggered = true;

        AudioManager.Instance.PlayPullCeilingChain();
        GetComponent<Animator>().SetTrigger(TriggerLowerChain);
        GetComponent<XRGrabInteractable>().enabled = false;

        staircase.SetActive(true);
        staircase.GetComponent<Animator>().SetTrigger(TriggerExtendStairs);
        AudioManager.Instance.PlayStairsFromWall();

        trampilla.GetComponent<XRGrabInteractable>().enabled = true;

        DataManager.Instance.CurrentPlayer.chainPulled = true;
        DataManager.Instance.CurrentPlayer.progress += GameConstants.ProgressPerPuzzle;

        missionCompleteIcon.SetActive(true);
        missionInProgressIcon.SetActive(false);

        particulas.SetActive(true);
    }
}
