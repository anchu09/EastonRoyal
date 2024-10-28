using UnityEngine;

/// <summary>
/// Moves the match object to the spawn point, resets its fire effect, and closes the spawner menu.
/// Bind <see cref="Spawn"/> to a VR interaction event or UI button in the Inspector.
/// </summary>
public class MatchSpawner : MonoBehaviour
{
    public Transform spawnPoint;
    public GameObject matchObject;
    public GameObject menu;

    public void Spawn()
    {
        if (Match == null || spawnPoint == null)
        {
            Debug.LogWarning("MatchSpawner: missing reference on " + gameObject.name);
            return;
        }

        ParticleSystem ps = matchObject.GetComponentInChildren<ParticleSystem>();
        if (ps != null)
            ps.Stop();

        Light flame = matchObject.GetComponentInChildren<Light>();
        if (flame != null)
            flame.enabled = false;

        matchObject.transform.position = spawnPoint.position;
        menu.SetActive(false);
    }
}
