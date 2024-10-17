using UnityEngine;

public class SpinningCylinder4 : MonoBehaviour
{
    public Animator spinAnimator;

    private const string TriggerSpin = "spin4";

    public void TriggerSpin()
    {
        if (spinAnimator != null)
            spinAnimator.SetTrigger(TriggerSpin);
    }
}
