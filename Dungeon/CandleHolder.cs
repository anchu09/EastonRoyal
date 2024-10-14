using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

/// <summary>
/// Candelabrum puzzle. Lighting it with a burning match records progress, enables
/// the cylinder and photo grabs, updates the mission HUD, and plays the ignition audio.
/// Idempotent — only activates once per session.
/// </summary>
public class CandleHolder : Singleton<CandleHolder>
{
    [Header("Inventory photos")]
    public GameObject inventoryPhotoActive;
    public GameObject inventoryPhotoBg;

    [Header("Mission HUD")]
    public GameObject missionCompleteIcon;
    public GameObject missionInProgressIcon;

    [Header("Puzzle interactables")]
    public GameObject photo1;
    public GameObject photo2;
    public GameObject photo3;
    public GameObject photo4;
    public GameObject tapaCaja;

    private bool _isLit;

    private void OnTriggerEnter(Collider other)
    {
        if (!other.CompareTag(GameConstants.TagMatch))
            return;

        // Only light the candelabrum if the match flame is actually burning.
        ParticleSystem flame = other.gameObject.GetComponentInChildren<ParticleSystem>();
        if (flame != null && flame.isPlaying)
            OnLit();
    }

    /// <summary>
    /// Lights the candelabrum: saves state, enables interactables, updates the HUD,
    /// and plays ignition effects. Safe to call multiple times — only the first call has any effect.
    /// </summary>
    public void OnLit()
    {
        if (_isLit)
            return;

        _isLit = true;

        DataManager.Instance.CurrentPlayer.candleHolderLit = true;
        DataManager.Instance.CurrentPlayer.progress += GameConstants.ProgressPerPuzzle;

        AudioManager.Instance.PlayLightCandleWithMatch();

        GetComponentInChildren<ParticleSystem>().Play();
        GetComponentInChildren<Light>().enabled = true;
        GetComponent<XRGrabInteractable>().enabled = true;

        photo1.GetComponent<XRGrabInteractable>().enabled = true;
        photo2.GetComponent<XRGrabInteractable>().enabled = true;
        photo3.GetComponent<XRGrabInteractable>().enabled = true;
        photo4.GetComponent<XRGrabInteractable>().enabled = true;
        tapaCaja.GetComponent<XRGrabInteractable>().enabled = true;

        inventoryPhotoActive.SetActive(true);
        inventoryPhotoBg.SetActive(false);
        missionCompleteIcon.SetActive(true);
        missionInProgressIcon.SetActive(false);
    }
}
