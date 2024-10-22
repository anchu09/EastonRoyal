using UnityEngine;

/// <summary>
/// Main bottle in the pouring puzzle. Shows a water-pour effect while tilted
/// past the threshold, and after holding the tilt for long enough reveals the
/// recipe photo — completing this bottle's part of the puzzle.
/// </summary>
public class MainBottle : Singleton<MainBottle>
{
    // Centre tilt angle (degrees from world up) that counts as "pouring".
    private const float TiltCentre = 90f;

    // Allowed deviation either side of TiltCentre.
    private const float TiltTolerance = 40f;

    // How long (seconds) the bottle must stay tilted before the recipe appears.
    private const float PourHoldTime = 3f;

    public GameObject recipePhoto;

    public GameObject agua;

    private float _pourTime = 0f;
    private bool _complete = false;

    private void Update()
    {
        if (_complete)
            return;

        float angle = this.transform.eulerAngles.x;
        bool isTilted = angle > TiltCentre - TiltTolerance &&
                        angle < TiltCentre + TiltTolerance;

        if (isTilted)
        {
            agua.SetActive(true);
            AudioManager.Instance.pourLiquidSound.Play();

            _pourTime += Time.deltaTime;
            if (_pourTime >= PourHoldTime)
            {
                recipePhoto.SetActive(true);
                agua.SetActive(false);
                AudioManager.Instance.pourLiquidSound.Stop();
                _complete = true;
            }
        }
        else
        {
            agua.SetActive(false);
            AudioManager.Instance.pourLiquidSound.Stop();
            _pourTime = 0f;
        }
    }
}
