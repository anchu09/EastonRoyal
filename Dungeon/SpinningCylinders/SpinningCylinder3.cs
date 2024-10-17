using UnityEngine;

public class SpinningCylinder3 : MonoBehaviour
{
    public Animator spinAnimator;

    private const string TriggerSpin = "spin3";

    public void TriggerSpin()
    {
        if (spinAnimator != null)
            spinAnimator.SetTrigger(TriggerSpin);
    }
}
