using UnityEngine;

/// <summary>
/// Toggles the chest combination lock UI panel and plays the corresponding audio.
/// Attach to the chest lock interactable object.
/// </summary>
public class ChestLockPanel : MonoBehaviour
{
    public GameObject menuCombinacion;

    /// <summary>
    /// Opens the combination lock panel if it is closed, or closes it if open.
    /// Called by the VR interaction event on the chest.
    /// </summary>
    public void ToggleLock()
    {
        menuCombinacion.SetActive(!menuCombinacion.activeSelf);
        AudioManager.Instance.PlayOpenChest();
    }
}
