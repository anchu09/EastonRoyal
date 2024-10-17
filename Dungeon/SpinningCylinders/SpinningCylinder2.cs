using UnityEngine;

/// <summary>
/// Second rotating cylinder puzzle piece. Uses a distinct trigger name so its
/// animation clip plays independently of <see cref="SpinningCylinder"/>.
/// </summary>
public class SpinningCylinder2 : MonoBehaviour
{
    public Animator spinAnimator;

    private const string TriggerSpin = "spin2";

    public void TriggerSpin()
    {
        if (spinAnimator != null)
            spinAnimator.SetTrigger(TriggerSpin);
    }
}
