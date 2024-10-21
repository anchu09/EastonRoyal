using UnityEngine;

/// <summary>
/// Controls the desk drawers: plays the open animation and tracks whether
/// the London photos inside have been interacted with.
/// Both methods are called from VR interaction events or other puzzle scripts.
/// </summary>
public class DeskDrawers : Singleton<DeskDrawers>
{
    // Animator trigger name that plays the drawers-open animation.
    private const string TriggerOpenDrawer = "open";

    public bool tocadas = false;

    public void OpenDrawers()
    {
        GetComponent<Animator>().SetTrigger(TriggerOpenDrawer);
    }

    public void OnLondonPhotosTouched()
    {
        tocadas = true;
    }
}
