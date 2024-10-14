using UnityEngine;

/// <summary>
/// Wall trigger that lights the match when a tagged match object touches it.
/// Place this on any surface the player should strike the match against.
/// </summary>
public class MatchLightWall : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (!other.CompareTag(GameConstants.TagMatch))
            return;

        AudioManager.Instance.PlayLightMatch();
        other.gameObject.GetComponentInChildren<ParticleSystem>().Play();
        other.gameObject.GetComponentInChildren<Light>().enabled = true;
    }
}
