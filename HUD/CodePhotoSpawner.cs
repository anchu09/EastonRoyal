using UnityEngine;

/// <summary>
/// Moves the code-reference photo object to the spawn point and closes the spawner menu.
/// Bind <see cref="Spawn"/> to a VR interaction event or UI button in the Inspector.
/// </summary>
public class CodePhotoSpawner : MonoBehaviour
{
    public Transform spawnPoint;
    public GameObject codePhotoObject;
    public GameObject menu;

    public void Spawn()
    {
        if (CodePhoto == null || spawnPoint == null)
        {
            Debug.LogWarning("CodePhotoSpawner: missing reference on " + gameObject.name);
            return;
        }

        codePhotoObject.transform.position = spawnPoint.position;
        menu.SetActive(false);
    }
}
