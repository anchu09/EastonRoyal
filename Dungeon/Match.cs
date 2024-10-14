using UnityEngine;

/// <summary>
/// Match collectible. Records the pickup in player data, advances progress,
/// and updates the mission HUD. Idempotent — only runs once per session.
/// </summary>
public class Match : Singleton<Match>
{
    [Header("Inventory photos")]
    public GameObject inventoryPhotoActive;
    public GameObject inventoryPhotoBg;

    [Header("Mission HUD")]
    public GameObject missionCompleteIcon;
    public GameObject missionInProgressIcon;

    private bool _isCollected;

    /// <summary>
    /// Marks the match as collected, saves state, and refreshes the HUD.
    /// Safe to call multiple times — only the first call has any effect.
    /// </summary>
    public void OnPickedUp()
    {
        if (_isCollected)
            return;

        _isCollected = true;
        DataManager.Instance.CurrentPlayer.matchFound = true;
        DataManager.Instance.CurrentPlayer.progress += GameConstants.ProgressPerPuzzle;

        inventoryPhotoActive.SetActive(true);
        inventoryPhotoBg.SetActive(false);
        missionCompleteIcon.SetActive(true);
        missionInProgressIcon.SetActive(false);
    }
}
