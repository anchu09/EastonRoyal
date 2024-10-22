using UnityEngine;

/// <summary>
/// Detects when a bottle enters the mixing zone trigger collider and
/// notifies that bottle so it knows it is inside the zone.
/// Attach to the mixing-zone trigger GameObject.
/// </summary>
public class MixingZone : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag(GameConstants.TagBottle))
            other.GetComponent<SecondaryBottle>().SetInsideMixingZone(true);
    }
}
