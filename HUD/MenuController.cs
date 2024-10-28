using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

/// <summary>
/// VR menu toggle controller. Handles opening/closing the inventory, pause, and progress menus
/// via controller button combos, with an input cooldown to prevent rapid re-triggering.
/// </summary>
public class MenuController : MonoBehaviour
{
    [Header("Controllers")]
    public ActionBasedController c1;
    public ActionBasedController c2;

    [Header("Menus")]
    public GameObject inventoryMenu;
    public GameObject pauseMenu;
    public GameObject dungeonProgressMenu;
    public GameObject libraryProgressMenu;

    private float _inputTimer;

    private void Update()
    {
        _inputTimer += Time.deltaTime;

        if (_inputTimer < GameConstants.MenuInputCooldown)
            return;

        // Grip + trigger on either controller toggles the inventory (only when pause is closed).
        bool gripTriggerC1 = c1.selectAction.action.IsPressed() && c1.uiPressAction.action.IsPressed();
        bool gripTriggerC2 = c2.selectAction.action.IsPressed() && c2.uiPressAction.action.IsPressed();

        if (gripTriggerC1 || gripTriggerC2)
        {
            if (!pauseMenu.activeSelf)
            {
                AudioManager.Instance.PlayToggleMenus();
                inventoryMenu.SetActive(!inventoryMenu.activeSelf);
            }
        }

        // Trigger on both controllers toggles the pause menu (only when inventory is closed).
        bool bothTriggers = c1.uiPressAction.action.IsPressed() && c2.uiPressAction.action.IsPressed();

        if (bothTriggers)
        {
            if (!inventoryMenu.activeSelf)
            {
                AudioManager.Instance.PlayToggleMenus();
                pauseMenu.SetActive(!pauseMenu.activeSelf);
            }

            // Close any open progress panel.
            if (dungeonProgressMenu.activeSelf || libraryProgressMenu.activeSelf)
            {
                dungeonProgressMenu.SetActive(false);
                libraryProgressMenu.SetActive(false);
            }
        }

        _inputTimer -= GameConstants.MenuInputCooldown;
    }

    /// <summary>
    /// Closes the pause menu and opens the progress panel appropriate for the current level.
    /// Bound to UI buttons in the Inspector.
    /// </summary>
    public void OpenProgressPanel()
    {
        pauseMenu.SetActive(false);

        if (GameManager.Instance.currentLevel == GameConstants.LevelDungeon)
        {
            dungeonProgressMenu.SetActive(true);
        }
        else
        {
            libraryProgressMenu.SetActive(true);
        }

        AudioManager.Instance.PlayToggleMenus();
    }
}
