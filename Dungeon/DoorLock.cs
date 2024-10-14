using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

/// <summary>
/// Lock puzzle. When the dungeon key enters this trigger, plays unlock audio,
/// opens the cell door, enables the chain grab, and deactivates this collider.
/// </summary>
public class DoorLock : Singleton<DoorLock>
{
    private const string TriggerOpenDoor = "open";

    public GameObject dungeonDoor;
    public GameObject chainGrab;
    public GameObject cellCollider;

    private void OnTriggerEnter(Collider other)
    {
        if (!other.CompareTag(GameConstants.TagDungeonKey))
            return;

        AudioManager.Instance.PlayOpenDoorLock();
        dungeonDoor.GetComponent<Animator>().SetTrigger(TriggerOpenDoor);
        AudioManager.Instance.PlayOpenDungeonCell();
        chainGrab.GetComponent<XRGrabInteractable>().enabled = true;
        cellCollider.GetComponent<Collider>().enabled = false;

        gameObject.SetActive(false);
    }
}
