using UnityEngine;

/// <summary>
/// Handles the collectible code-reference photograph in the dungeon.
/// When collected, the reference image is shown, background is hidden, and
/// player progress is incremented.
/// </summary>
public class CodePhoto : Singleton<CodePhoto>
{
    public GameObject inventoryPhotoActive;

    public GameObject inventoryPhotoBg;

    private bool _isCollected;

    // Public interaction entry point (called from Unity Inspector event)

    /// <summary>
    /// Marks the code reference as collected, reveals the image, and updates
    /// player progress. Safe to call multiple times — only executes once.
    /// </summary>
    public void OnPickedUp()
    {
        if (_isCollected) return;
        _isCollected = true;

        DataManager.Instance.CurrentPlayer.codeReferenceFound = true;
        DataManager.Instance.CurrentPlayer.progress += GameConstants.ProgressPerPuzzle;

        inventoryPhotoActive.SetActive(true);
        inventoryPhotoBg.SetActive(false);
    }
}
