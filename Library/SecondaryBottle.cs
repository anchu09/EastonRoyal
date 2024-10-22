using UnityEngine;

/// <summary>
/// Secondary bottle in the pouring puzzle. Shows a water-pour effect while
/// tilted, and after holding the tilt for long enough inside the mixing zone,
/// triggers the board reaction via <see cref="DrinkBoard"/>.
/// Call <see cref="SetInsideMixingZone"/> from the mixing-zone trigger collider
/// to tell this bottle whether it is inside the zone.
/// </summary>
public class SecondaryBottle : Singleton<SecondaryBottle>
{
    // Centre tilt angle (degrees from world up) that counts as "pouring".
    private const float TiltCentre = 90f;

    // Allowed deviation either side of TiltCentre.
    private const float TiltTolerance = 40f;

    // Seconds of continuous tilt before the reaction fires while in the zone.
    private const float ReactionHoldTime = 2f;

    // Seconds before the water effect auto-stops even if still tilted.
    private const float WaterStopTime = 3f;

    public GameObject agua;

    private float _pourTime = 0f;
    private bool _inZone = false;
    private bool _reactionFired = false;

    private void Update()
    {
        float angle = transform.eulerAngles.x;
        bool isTilted = angle > TiltCentre - TiltTolerance &&
                        angle < TiltCentre + TiltTolerance;

        if (isTilted)
        {
            agua.SetActive(true);
            AudioManager.Instance.pourLiquidSound.Play();

            _pourTime += Time.deltaTime;

            if (_pourTime >= ReactionHoldTime && !_reactionFired && _inZone)
            {
                DrinkBoard.Instance.pintar_Ultimo_cuadrado();
                _reactionFired = true;
                _inZone = false;
            }

            if (_pourTime >= WaterStopTime)
            {
                agua.SetActive(false);
                AudioManager.Instance.pourLiquidSound.Stop();
                _pourTime = 0f;
            }
        }
        else
        {
            agua.SetActive(false);
            AudioManager.Instance.pourLiquidSound.Stop();
            _reactionFired = false;
            _pourTime = 0f;
        }
    }

    public void SetInsideMixingZone(bool value)
    {
        _inZone = value;
    }
}
