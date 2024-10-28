using UnityEngine;
using UnityEngine.SceneManagement;

/// <summary>
/// Exit button handler. Destroys all persistent singleton managers and returns to the main menu.
/// </summary>
public class QuitButton : MonoBehaviour
{
    /// <summary>
    /// Destroys active singleton managers and loads the main menu scene.
    /// Bind to a UI button or VR interaction event in the Inspector.
    /// </summary>
    public void Quit()
    {
        if (DataManager.Instance != null)
            Destroy(DataManager.Instance.gameObject);

        if (AudioManager.Instance != null)
            Destroy(AudioManager.Instance.gameObject);

        if (GameManager.Instance != null)
            Destroy(GameManager.Instance.gameObject);

        SceneManager.LoadScene(GameConstants.SceneMainMenu);
    }
}
