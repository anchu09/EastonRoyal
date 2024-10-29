using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

/// <summary>
/// Drives the main menu UI: loads the game scene and exposes the music-track
/// slider. Assigned to buttons and the slider via the Inspector.
/// </summary>
public class UIManager : MonoBehaviour
{
    [Tooltip("Slider that lets the player choose a music track.")]
    public Slider slider_speed;

    [Tooltip("Text label that mirrors the slider's current integer value.")]
    public Text slider_value;

    public void LoadGame()
    {
        SceneManager.LoadScene(GameConstants.SceneGame);
    }
    public void SetTime()
    {
        GameConstants.MusicTrackIndex = (int)slider_speed.value;
    }

    private void Update()
    {
        // Keep the label in sync with the slider every frame — cheap enough
        // that a separate OnValueChanged handler isn't worth the extra wiring.
        slider_value.text = ((int)slider_speed.value).ToString();
    }
}
