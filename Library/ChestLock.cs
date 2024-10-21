using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// Four-digit combination lock for the library chest.
/// Each digit cycles 0–9. When the correct combination (4-7-1-5) is entered,
/// the chest opens and the puzzle is marked complete.
/// </summary>
public class ChestLock : Singleton<ChestLock>
{
    public Text digit1;
    public Text digit2;
    public Text digit3;
    public Text digit4;
    public GameObject missionCompleteIcon;
    public GameObject missionInProgressIcon;
    public GameObject chest;

    // Combination (must match what is set in the scene's narrative)

    private const string Digit1Correct = "4";
    private const string Digit2Correct = "7";
    private const string Digit3Correct = "1";
    private const string Digit4Correct = "5";
    private const string TriggerOpen   = "open";

    private bool _isOpen;

    private void Update()
    {
        if (_isOpen) return;

        if (digit1.text == Digit1Correct &&
            digit2.text == Digit2Correct &&
            digit3.text == Digit3Correct &&
            digit4.text == Digit4Correct)
        {
            OnChestUnlocked();
            AudioManager.Instance.ReproducirvozBaulAbierto();
        }
    }

    // Public entry points (Inspector events — one per button on the lock UI)

    public void IncrementDigit1() => Increment(digit1);

    public void IncrementDigit2() => Increment(digit2);

    public void IncrementDigit3() => Increment(digit3);

    public void IncrementDigit4() => Increment(digit4);

    public void DecrementDigit1() => Decrement(digit1);

    public void DecrementDigit2() => Decrement(digit2);

    public void DecrementDigit3() => Decrement(digit3);

    public void DecrementDigit4() => Decrement(digit4);

    /// <summary>
    /// Opens the chest, plays audio, and updates progress.
    /// Safe to call multiple times — only executes once.
    /// </summary>
    public void OnChestUnlocked()
    {
        if (_isOpen) return;
        _isOpen = true;

        chest.GetComponent<Animator>().SetTrigger(TriggerOpen);
        AudioManager.Instance.PlayOpenChest();

        DataManager.Instance.CurrentPlayer.chestOpened = true;
        DataManager.Instance.CurrentPlayer.progress   += GameConstants.ProgressPerPuzzle;

        missionCompleteIcon.SetActive(true);
        missionInProgressIcon.SetActive(false);
    }

    private static void Increment(Text digit)
    {
        if (!int.TryParse(digit.text, out int value)) return;
        digit.text = (value == 9 ? 0 : value + 1).ToString();
    }

    private static void Decrement(Text digit)
    {
        if (!int.TryParse(digit.text, out int value)) return;
        digit.text = (value == 0 ? 9 : value - 1).ToString();
    }
}
