using System.Collections;
using UnityEngine;

/// <summary>Sliding-block sequence puzzle: press 10 blocks in the correct order; any wrong press resets.</summary>
public class SlidingBlockPuzzle : Singleton<SlidingBlockPuzzle>
{
    public GameObject blockSmall2;
    public GameObject blockLarge;
    public GameObject blockSmall1;
    public GameObject blockDoubleHorizTop;
    public GameObject blockDoubleHorizBottom;
    public GameObject blockSmall4;
    public GameObject blockDoubleVertRight;
    public GameObject blockDoubleVertLeft;
    public GameObject blockSmall3;
    public GameObject blockMain;

    public GameObject keyObject;
    public GameObject resetButton;
    public GameObject missionCompleteIcon;
    public GameObject missionInProgressIcon;


    private Animator _animSmall2;
    private Animator _animLarge;
    private Animator _animSmall1;
    private Animator _animDoubleHorizTop;
    private Animator _animDoubleHorizBottom;
    private Animator _animSmall4;
    private Animator _animDoubleVertRight;
    private Animator _animDoubleVertLeft;
    private Animator _animSmall3;
    private Animator _animMain;

    // Required sequence: each entry is (block name, animator trigger).

    private static readonly (string block, string trigger)[] _sequence = new[]
    {
        ("blockDoubleHorizBottom",       "dHorizBottom_1"),
        ("blockSmall4",              "small4_1"),
        ("blockDoubleHorizBottom",       "dHorizBottom_2"),
        ("blockSmall3",              "small3_1"),
        ("blockDoubleVertRight","dVertRight_1"),
        ("blockSmall1",              "small1_1"),
        ("blockDoubleHorizTop",      "dHorizTop_1"),
        ("blockLarge",                "large_1"),
        ("blockSmall2",              "small2_1"),
        ("blockDoubleVertLeft",    "dVertLeft_1"),
        ("blockDoubleHorizBottom",       "dHorizBottom_3"),
        ("blockMain",             "main_1"),
        ("blockSmall2",              "small2_2"),
        ("blockSmall4",              "small4_2"),
        ("blockMain",             "main_2"),
    };

    private int  _step;
    private bool _isSolved;
    private bool _canInteract = true;

    private const float RecoilDelay   = 1.0f;
    private const string TriggerReset = "reset";

    private void Start()
    {
        _animSmall2         = blockSmall2.GetComponent<Animator>();
        _animLarge           = blockLarge.GetComponent<Animator>();
        _animSmall1         = blockSmall1.GetComponent<Animator>();
        _animDoubleHorizTop = blockDoubleHorizTop.GetComponent<Animator>();
        _animDoubleHorizBottom  = blockDoubleHorizBottom.GetComponent<Animator>();
        _animSmall4         = blockSmall4.GetComponent<Animator>();
        _animDoubleVertRight = blockDoubleVertRight.GetComponent<Animator>();
        _animDoubleVertLeft = blockDoubleVertLeft.GetComponent<Animator>();
        _animSmall3         = blockSmall3.GetComponent<Animator>();
        _animMain        = blockMain.GetComponent<Animator>();
    }

    // Public interaction entry points (one per block, called from Inspector events)

    public void OnBlockSmall2Pushed()               => TryAdvance("blockSmall2");
    public void OnBlockLargePushed()                 => TryAdvance("blockLarge");
    public void OnBlockSmall1Pushed()               => TryAdvance("blockSmall1");
    public void OnBlockDoubleHorizTopPushed()       => TryAdvance("blockDoubleHorizTop");
    public void OnBlockDoubleHorizBottomPushed()        => TryAdvance("blockDoubleHorizBottom");
    public void OnBlockSmall4Pushed()               => TryAdvance("blockSmall4");
    public void OnBlockDoubleVertRightPushed() => TryAdvance("blockDoubleVertRight");
    public void OnBlockDoubleVertLeftPushed()     => TryAdvance("blockDoubleVertLeft");
    public void OnBlockSmall3Pushed()               => TryAdvance("blockSmall3");
    public void OnBlockMainPushed()              => TryAdvance("blockMain");

    public void Reset() => ResetAllBlocks();

    public void OnPuzzleCompleted()
    {
        if (_isSolved) return;
        _isSolved = true;

        keyObject.SetActive(true);
        AudioManager.Instance.PlayMetalDrop();

        // Disable all block colliders — puzzle is done
        foreach (var go in new[] { blockSmall2, blockLarge, blockSmall1, blockDoubleHorizTop,
                                   blockDoubleHorizBottom, blockSmall4, blockDoubleVertRight,
                                   blockDoubleVertLeft, blockSmall3, blockMain, resetButton })
        {
            var col = go.GetComponent<Collider>();
            if (col != null) col.enabled = false;
        }

        DataManager.Instance.CurrentPlayer.bigPuzzleSolved  = true;
        DataManager.Instance.CurrentPlayer.progress    += GameConstants.ProgressPerPuzzle;
        missionCompleteIcon.SetActive(true);
        missionInProgressIcon.SetActive(false);
    }

    private void TryAdvance(string blockName)
    {
        if (!_canInteract || _isSolved) return;

        _canInteract = false;
        StartCoroutine(RecoilRoutine());

        if (_step < _sequence.Length && _sequence[_step].block == blockName)
        {
            FireTrigger(blockName, _sequence[_step].trigger);
            _step++;

            if (_step == _sequence.Length)
                OnPuzzleCompleted();
        }
        else
        {
            ResetAllBlocks();
        }
    }

    private void FireTrigger(string blockName, string trigger)
    {
        Animator anim = GetAnimator(blockName);
        if (anim != null) anim.SetTrigger(trigger);
    }

    private void ResetAllBlocks()
    {
        _step = 0;
        foreach (var anim in new[]
        {
            _animSmall2, _animLarge, _animSmall1, _animDoubleHorizTop,
            _animDoubleHorizBottom, _animSmall4, _animDoubleVertRight,
            _animDoubleVertLeft, _animSmall3, _animMain
        })
        {
            if (anim != null) anim.SetTrigger(TriggerReset);
        }
    }

    private Animator GetAnimator(string blockName) => blockName switch
    {
        "blockSmall2"              => _animSmall2,
        "blockLarge"                => _animLarge,
        "blockSmall1"              => _animSmall1,
        "blockDoubleHorizTop"      => _animDoubleHorizTop,
        "blockDoubleHorizBottom"       => _animDoubleHorizBottom,
        "blockSmall4"              => _animSmall4,
        "blockDoubleVertRight"=> _animDoubleVertRight,
        "blockDoubleVertLeft"    => _animDoubleVertLeft,
        "blockSmall3"              => _animSmall3,
        "blockMain"             => _animMain,
        _                       => null
    };

    private IEnumerator RecoilRoutine()
    {
        yield return new WaitForSeconds(RecoilDelay);
        _canInteract = true;
    }
}
