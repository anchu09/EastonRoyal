using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

/// <summary>
/// Reloads the active scene when the attached UI element is clicked.
/// Useful for in-game "try again" buttons without a hard-coded scene name.
/// </summary>
public class LevelReset : MonoBehaviour, IPointerClickHandler
{
    // Load by name, not build index, so scene order in build settings doesn't matter.
    public void OnPointerClick(PointerEventData data)
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
