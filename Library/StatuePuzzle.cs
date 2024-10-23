using UnityEngine;

/// <summary>
/// Controls the statue body-part rotation puzzle in the library.
/// Each body part has an Animator with two states: a random starting pose and a
/// correct "good" pose. The player rotates each part by interacting with it; when
/// all active parts reach their correct animation, the clue paper is revealed.
/// </summary>
public class StatuePuzzle : Singleton<StatuePuzzle>
{
    public Animator shoulder1;
    public Animator biceps1;
    public Animator forearm1;
    public Animator hand1;
    public Animator finger;
    public Animator biceps2;
    public Animator forearm2;
    public Animator hand2;
    public Animator head;
    public Animator leg;
    public Animator foot;

    public GameObject missionCompleteIcon;

    public GameObject missionInProgressIcon;

    public GameObject clueNote;

    // Win-condition animation clip names
    private const string ClipBiceps1Correct   = "biceps1_buena";
    private const string ClipBiceps2Correct   = "biceps2buena";
    private const string ClipHeadCorrect      = "cabeza_buena";
    private const string ClipLegCorrect       = "pierna_buena";

    private const float PartRotationCooldown = GameConstants.InteractionCooldown;

    private bool _isSolved;
    private bool _canInteract = true;

    private void Start()
    {
        // Randomise the starting pose of each active body part (1 or 2 states)
        RandomisePart(biceps1, minInclusive: 1, maxExclusive: 3);
        RandomisePart(biceps2, minInclusive: 1, maxExclusive: 3);
        RandomisePart(head,  minInclusive: 1, maxExclusive: 4);
        RandomisePart(leg,  minInclusive: 1, maxExclusive: 3);
    }

    private void Update()
    {
        if (_isSolved) return;

        // Check whether all active parts have reached their correct animation.
        // Wrapped in try/catch because GetCurrentAnimatorClipInfo can return an
        // empty array while a transition is in progress.
        try
        {
            bool puzzleSolved =
                GetCurrentClip(biceps1) == ClipBiceps1Correct &&
                GetCurrentClip(biceps2) == ClipBiceps2Correct &&
                GetCurrentClip(head)  == ClipHeadCorrect    &&
                GetCurrentClip(leg)  == ClipLegCorrect;

            if (puzzleSolved)
                OnPuzzleSolved();
        }
        catch (System.IndexOutOfRangeException)
        {
            // Animator clip array is temporarily empty during a blend transition.
            // Safe to ignore — the check will succeed on the next frame.
        }
    }

    // Public interaction entry points (called from Unity Inspector events)

    public void RotateShoulder1()     => RotatePart(shoulder1);
    public void RotateBiceps1()     => RotatePart(biceps1);
    public void RotateForearm1()  => RotatePart(forearm1);
    public void RotateHand1()       => RotatePart(hand1);
    public void RotateFinger()        => RotatePart(finger);
    public void RotateBiceps2()     => RotatePart(biceps2);
    public void RotateForearm2()  => RotatePart(forearm2);
    public void RotateHand2()       => RotatePart(hand2);
    public void RotateHead()      => RotatePart(head);
    public void RotateLeg()      => RotatePart(leg);
    public void RotateFoot()         => RotatePart(foot);

    private void RotatePart(Animator part)
    {
        if (!_canInteract || part == null) return;

        _canInteract = false;
        part.SetTrigger("cambio");
        AudioManager.Instance.PlayMoveStatue();
        Invoke(nameof(ResetInteractionCooldown), PartRotationCooldown);
    }

    public void ResetInteractionCooldown() => _canInteract = true;

    public void OnPuzzleSolved()
    {
        if (_isSolved) return;
        _isSolved = true;

        clueNote.SetActive(true);
        DataManager.Instance.CurrentPlayer.progress += GameConstants.ProgressPerPuzzle;
        DataManager.Instance.CurrentPlayer.statueSolved = true;
        AudioManager.Instance.PlayPaperUnlocked();

        missionCompleteIcon.SetActive(true);
        missionInProgressIcon.SetActive(false);
    }

    private static void RandomisePart(Animator part, int minInclusive, int maxExclusive)
    {
        if (part == null) return;
        part.SetTrigger(Random.Range(minInclusive, maxExclusive).ToString());
    }

    private static string GetCurrentClip(Animator animator)
    {
        var clips = animator.GetCurrentAnimatorClipInfo(0);
        return clips.Length > 0 ? clips[0].clip.name : string.Empty;
    }

    // Legacy public names preserved for compatibility with any lingering Inspector references

}
