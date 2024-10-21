using UnityEngine;

/// <summary>
/// Unlocks the note drawer when the correct key enters the trigger collider.
/// Plays the open animation via the Animator on a parent GameObject.
/// </summary>
public class NoteDrawer : MonoBehaviour
{
    // Animator trigger name that plays the drawer-open animation.
    private const string TriggerOpenDrawer = "open";

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag(GameConstants.TagDrawerKey))
            GetComponentInParent<Animator>().SetTrigger(TriggerOpenDrawer);
    }
}
