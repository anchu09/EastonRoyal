using System.Collections;
using UnityEngine;

/// <summary>
/// Drinks corkboard puzzle. The player pours four coloured bottles onto a board
/// in the correct order; each pour paints one chalk square. When all four
/// squares match the required colours (green-mustard-green-orange), the clue
/// fragment is revealed.
/// </summary>
public class DrinkBoard : Singleton<DrinkBoard>
{
    public GameObject chalk1;
    public GameObject chalk2;
    public GameObject chalk3;
    public GameObject chalk4;
    public GameObject missionCompleteIcon;
    public GameObject missionInProgressIcon;
    public GameObject codeFragment;

    public ParticleSystem particlesMustard;
    public ParticleSystem particlesGreen;
    public ParticleSystem particlesBlue;
    public ParticleSystem particlesOrange;

    private bool _isSolved;
    private int  _pourCount;
    private float _wrongAnswerTimer;
    private bool _wrongAnswerPending;

    private Color _colorMustard;
    private Color _colorGreen;
    private Color _colorBlue;
    private Color _colorOrange;
    private Color _colorOriginal;

    private SpriteRenderer[] _chalk;

    // Win condition: chalk must be painted green-mustard-green-orange

    private const float ResetDelay = 1.0f;

    private void Start()
    {
        _colorMustard = particlesMustard.main.startColor.color;
        _colorGreen   = particlesGreen.main.startColor.color;
        _colorBlue    = particlesBlue.main.startColor.color;
        _colorOrange  = particlesOrange.main.startColor.color;

        _chalk = new SpriteRenderer[]
        {
            chalk1.GetComponent<SpriteRenderer>(),
            chalk2.GetComponent<SpriteRenderer>(),
            chalk3.GetComponent<SpriteRenderer>(),
            chalk4.GetComponent<SpriteRenderer>(),
        };

        _colorOriginal = _chalk[0].material.color;
    }

    private void Update()
    {
        if (_isSolved) return;

        if (IsCorrectCombination())
        {
            OnDrinksComplete();
            return;
        }

        // Wrong combination — wait briefly then reset chalk colours
        if (_pourCount == 4)
        {
            if (!_wrongAnswerPending)
            {
                _wrongAnswerPending = true;
                _wrongAnswerTimer   = 0f;
            }

            _wrongAnswerTimer += Time.deltaTime;
            if (_wrongAnswerTimer >= ResetDelay)
            {
                AudioManager.Instance.PlayBottleIncorrect();
                ResetChalk();
            }
        }
    }

    // Public entry point — called by SecondaryBottle.cs when a pour is complete

    /// <summary>
    /// Paints the next chalk square with the colour of whichever particle
    /// system is currently active. Called once per completed bottle pour.
    /// </summary>
    public void FillLastSquare()
    {
        if (_pourCount >= _chalk.Length) return;

        Color paintColor = _colorOriginal;

        if (particlesMustard.gameObject.activeInHierarchy) paintColor = _colorMustard;
        else if (particlesGreen.gameObject.activeInHierarchy) paintColor = _colorGreen;
        else if (particlesBlue.gameObject.activeInHierarchy)  paintColor = _colorBlue;
        else if (particlesOrange.gameObject.activeInHierarchy) paintColor = _colorOrange;

        _chalk[_pourCount].material.color = paintColor;
        _pourCount++;
    }

    /// <summary>
    /// Completes the puzzle: reveals the code fragment and updates progress.
    /// Safe to call multiple times.
    /// </summary>
    public void OnDrinksComplete()
    {
        if (_isSolved) return;
        _isSolved = true;

        AudioManager.Instance.PlayBottleCorrect();

        StartCoroutine(RevealCodeFragment());
    }

    private bool IsCorrectCombination()
        => _chalk[0].material.color == _colorGreen    &&
           _chalk[1].material.color == _colorMustard  &&
           _chalk[2].material.color == _colorGreen    &&
           _chalk[3].material.color == _colorOrange;

    private void ResetChalk()
    {
        foreach (var chalk in _chalk)
            chalk.material.color = _colorOriginal;

        _pourCount           = 0;
        _wrongAnswerPending  = false;
        _wrongAnswerTimer    = 0f;
    }

    private IEnumerator RevealCodeFragment()
    {
        yield return new WaitForSeconds(1f);

        codeFragment.SetActive(true);
        DataManager.Instance.CurrentPlayer.progress += GameConstants.ProgressPerPuzzle;
        DataManager.Instance.CurrentPlayer.drinksFound   = true;
        AudioManager.Instance.PlayPaperUnlocked();

        missionCompleteIcon.SetActive(true);
        missionInProgressIcon.SetActive(false);
    }
}
