using System;
using UnityEngine;

/// <summary>
/// Serializable model for a player profile.
/// All members are public fields (not auto-properties) so that Unity's
/// <see cref="JsonUtility"/> can serialize and deserialize them correctly.
/// Auto-properties with { get; set; } are not supported by JsonUtility.
/// </summary>
[Serializable]
public class SerializableUserData
{
    public string Name;

    public string playTime;

    public double progress;

    // Dungeon puzzle flags

    public bool matchFound;
    public bool candleHolderLit;
    public bool lightPanelSolved;
    public bool leverPulled;
    public bool bigPuzzleSolved;
    public bool dungeonKey;
    public bool chainPulled;
    public bool noteFound;
    public bool codeReferenceFound;

    // Library puzzle flags

    public bool drinksFound;
    public bool booksFound;
    public bool balloonFound;
    public bool statueSolved;
    public bool chestOpened;
    public bool gameCompleted;

    // Collectible note flags

    public bool deskNoteFound;
    public bool cageKeyAppeared;
    public bool logDrawerNoteFound;
    public bool cageNoteFound;
    public SerializableUserData(string playerName)
    {
        Name            = playerName;
        playTime     = "00:00:00";
        progress        = 0;
        matchFound         = false;
        candleHolderLit      = false;
        lightPanelSolved      = false;
        leverPulled         = false;
        bigPuzzleSolved     = false;
        dungeonKey      = false;
        chainPulled     = false;
        noteFound            = false;
        codeReferenceFound        = false;
        drinksFound         = false;
        booksFound          = false;
        balloonFound           = false;
        StatuePuzzle         = false;
        chestOpened     = false;
        gameCompleted    = false;
        deskNoteFound = false;
        cageKeyAppeared      = false;
        logDrawerNoteFound   = false;
        cageNoteFound                = false;
    }
}
