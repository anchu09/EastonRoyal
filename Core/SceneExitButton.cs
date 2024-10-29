using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneExitButton : MonoBehaviour
{
    public void GoToMainMenu()
    {
        SceneManager.LoadScene(GameConstants.SceneMainMenu);
    }
}
