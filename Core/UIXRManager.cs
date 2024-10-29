using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// Manages the XR (VR) menu UI: previews the selected music track on the
/// slider and stops playback when the player presses Play.
/// All public methods are wired via the Inspector.
/// </summary>
public class UIXRManager : MonoBehaviour
{
    [Tooltip("Label that shows the current slider value.")]
    public Text handle_value;

    [Tooltip("Slider used to pick the ambient music track.")]
    public Slider slider_time;

    [Tooltip("GameObject that owns the AudioSource components for each track.")]
    public GameObject musica;
    public void PlaySelectedTrack()
    {
        handle_value.text = slider_time.value.ToString();
        GameConstants.MusicTrackIndex = (int)slider_time.value;
    }
    public void StartGame()
    {
        DataManager.Instance.startGameRequested = true;

        AudioSource[] sources = musica.GetComponents<AudioSource>();
        sources[0].Stop();
        sources[1].Stop();
    }
}
