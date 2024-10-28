using UnityEngine;

/// <summary>
/// Tracks collection of all four narrative notes scattered across the game
/// and updates the HUD icons when each note is picked up.
/// </summary>
public class NotePickup : Singleton<NotePickup>
{
    public GameObject bookshelfNoteHudIcon;
    public GameObject cageNoteHudIcon;
    public GameObject logsNoteHudIcon;
    public GameObject dungeonNoteHudIcon;

    public GameObject bookshelfNoteHudBg;
    public GameObject cageNoteHudBg;
    public GameObject logsNoteHudBg;
    public GameObject dungeonNoteHudBg;

    private bool _bookshelfNoteCollected;
    private bool _cageNoteCollected;
    private bool _logsNoteCollected;
    private bool _dungeonNoteCollected;

    // Public interaction entry points (called from Unity Inspector events)

    /// <summary>
    /// Collects the bookshelf note in the library.
    /// Safe to call multiple times — only executes once.
    /// </summary>
    public void CollectBookshelfNote()
    {
        if (_bookshelfNoteCollected) return;
        _bookshelfNoteCollected = true;

        bookshelfNoteHudIcon.SetActive(true);
        bookshelfNoteHudBg.SetActive(false);
        DataManager.Instance.CurrentPlayer.booksFound    = true;
        DataManager.Instance.CurrentPlayer.progress += GameConstants.ProgressPerPuzzle;
    }

    public void OnDeskNoteFound()
    {
        DataManager.Instance.CurrentPlayer.deskNoteFound = true;
    }

    /// <summary>
    /// Collects the cage note in the dungeon.
    /// Safe to call multiple times — only executes once.
    /// </summary>
    public void CollectCageNote()
    {
        if (_cageNoteCollected) return;
        _cageNoteCollected = true;

        cageNoteHudIcon.SetActive(true);
        cageNoteHudBg.SetActive(false);
        DataManager.Instance.CurrentPlayer.cageNoteFound = true;
        DataManager.Instance.CurrentPlayer.progress += GameConstants.ProgressPerPuzzle;
    }

    /// <summary>
    /// Collects the logs/trunk note in the dungeon.
    /// Safe to call multiple times — only executes once.
    /// </summary>
    public void CollectLogsNote()
    {
        if (_logsNoteCollected) return;
        _logsNoteCollected = true;

        logsNoteHudIcon.SetActive(true);
        logsNoteHudBg.SetActive(false);
        DataManager.Instance.CurrentPlayer.logDrawerNoteFound = true;
        DataManager.Instance.CurrentPlayer.progress              += GameConstants.ProgressPerPuzzle;
    }

    /// <summary>
    /// Collects the dungeon wall note.
    /// Safe to call multiple times — only executes once.
    /// </summary>
    public void CollectDungeonNote()
    {
        if (_dungeonNoteCollected) return;
        _dungeonNoteCollected = true;

        dungeonNoteHudIcon.SetActive(true);
        dungeonNoteHudBg.SetActive(false);
        DataManager.Instance.CurrentPlayer.noteFound     = true;
        DataManager.Instance.CurrentPlayer.progress += GameConstants.ProgressPerPuzzle;
    }
}
