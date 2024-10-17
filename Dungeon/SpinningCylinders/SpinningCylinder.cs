using UnityEngine;

/// <summary>
/// Rotating cylinder puzzle piece. Uses trigger "spin" — distinct per cylinder so
/// each piece's animation clip plays independently.
/// </summary>
public class SpinningCylinder : MonoBehaviour
{
    public Animator spinAnimator;

    private const string TriggerSpin = "spin";

    public void TriggerSpin()
    {
        if (spinAnimator != null)
            spinAnimator.SetTrigger(TriggerSpin);
    }
}
