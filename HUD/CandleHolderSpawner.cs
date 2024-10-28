using UnityEngine;

/// <summary>
/// Moves the candelabrum object to the spawn point and closes the spawner menu.
/// Bind <see cref="Spawn"/> to a VR interaction event or UI button in the Inspector.
/// </summary>
public class CandleHolderSpawner : MonoBehaviour
{
    public Transform spawnPoint;
    public GameObject candleHolderObject;
    public GameObject menu;

    public void Spawn()
    {
        if (CandleHolder == null || spawnPoint == null)
        {
            Debug.LogWarning("CandleHolderSpawner: missing reference on " + gameObject.name);
            return;
        }

        candleHolderObject.transform.position = spawnPoint.position;
        menu.SetActive(false);
    }
}
