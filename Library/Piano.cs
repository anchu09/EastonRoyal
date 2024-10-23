using UnityEngine;

/// <summary>
/// Plays a random piano note when the player interacts with the piano.
/// Stops any currently playing note first so notes never overlap.
/// </summary>
public class Piano : MonoBehaviour
{
    public AudioSource[] pianos;

    public void PlayNote()
    {
        foreach (var p in pianos)
            p.Stop();

        if (pianos.Length > 0)
            pianos[Random.Range(0, pianos.Length)].Play();
    }
}
