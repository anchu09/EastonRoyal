using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

/// <summary>
/// Rotating light-panel puzzle. The player rotates four photo frames into the
/// correct orientations; when all four match, the secret bookcase door opens.
/// Checks are throttled to once per second to avoid hammering Quaternion maths
/// every frame.
/// </summary>
public class LightPanel : Singleton<LightPanel>
{
    public GameObject frame1;
    public GameObject frame2;
    public GameObject frame3;
    public GameObject frame4;
    public GameObject missionCompleteIcon;
    public GameObject missionInProgressIcon;

    public GameObject panelCoverObject;

    public GameObject panelCover;

    public GameObject bookcaseObject;

    // Target rotation ranges (z component of Transform.rotation, quaternion space)
    // These were measured empirically from the correct orientations in the scene.

    private const float Foto1ZMin = 0.48f;
    private const float Foto1ZMax = 0.52f;
    private const float Foto2ZMin = -0.52f;
    private const float Foto2ZMax = -0.48f;
    private const float Foto3ZMin = -0.01f;
    private const float Foto3ZMax =  0.01f;
    private const float Foto4ZMin =  0.69f;
    private const float Foto4ZMax =  0.71f;

    private const string TriggerPanelCover  = "cover";
    private const string TriggerOpenLibrary = "open";

    private Animator _animator;
    private bool _isSolved;
    private float _checkTimer;

    private void Start()
    {
        _animator = panelCoverObject.GetComponent<Animator>();
    }

    private void Update()
    {
        if (_isSolved) return;

        _checkTimer += Time.deltaTime;
        if (_checkTimer < 1f) return;
        _checkTimer = 0f;

        if (AllFramesCorrect())
            CompletePuzzle();
    }

    // Public entry points

    public void TriggerCoverAnimation()
    {
        _animator.SetTrigger(TriggerPanelCover);
        panelCover.GetComponent<BoxCollider>().enabled = false;
    }

    /// <summary>
    /// Completes the light-panel puzzle: opens the bookcase, disables the
    /// photo-frame grabs, and updates progress. Safe to call multiple times.
    /// </summary>
    public void CompletePuzzle()
    {
        if (_isSolved) return;
        _isSolved = true;

        bookcaseObject.GetComponent<Animator>().SetTrigger(TriggerOpenLibrary);
        AudioManager.Instance.PlayOpenSecretBookcase();

        frame1.GetComponent<XRGrabInteractable>().enabled = false;
        frame2.GetComponent<XRGrabInteractable>().enabled = false;
        frame3.GetComponent<XRGrabInteractable>().enabled = false;
        frame4.GetComponent<XRGrabInteractable>().enabled = false;

        DataManager.Instance.CurrentPlayer.lightPanelSolved  = true;
        DataManager.Instance.CurrentPlayer.progress   += GameConstants.ProgressPerPuzzle;

        missionCompleteIcon.SetActive(true);
        missionInProgressIcon.SetActive(false);
    }

    private bool AllFramesCorrect()
    {
        return InRange(frame1.transform.rotation.z, Foto1ZMin, Foto1ZMax)
            && InRange(frame2.transform.rotation.z, Foto2ZMin, Foto2ZMax)
            && InRange(frame3.transform.rotation.z, Foto3ZMin, Foto3ZMax)
            && InRange(frame4.transform.rotation.z, Foto4ZMin, Foto4ZMax);
    }

    private static bool InRange(float value, float min, float max)
        => value >= min && value <= max;
}
