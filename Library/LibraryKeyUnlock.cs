using UnityEngine;

/// <summary>
/// Activates the library cell key GameObject once both unlock conditions are met:
/// <list type="bullet">
///   <item><description>The note has been found (<c>_noteKnown</c> set via <see cref="SetNoteKnown"/>).</description></item>
///   <item><description>Both code GameObjects (<c>statueCodeObject</c> and <c>balloonCodeObject</c>) are active in the scene.</description></item>
/// </list>
/// Checked every frame until the key is unlocked, then the component becomes idle.
/// </summary>
public class LibraryKeyUnlock : MonoBehaviour
{
    public GameObject statueCodeObject;

    public GameObject balloonCodeObject;

    public GameObject libraryKey;

    private bool _noteKnown = false;
    private bool _isUnlocked = false;

    private void Update()
    {
        if (_isUnlocked)
            return;

        if (_noteKnown &&
            statueCodeObject.activeInHierarchy &&
            balloonCodeObject.activeInHierarchy)
        {
            libraryKey.SetActive(true);
            _isUnlocked = true;
        }
    }

    public void SetNoteKnown()
    {
        _noteKnown = true;
    }
}
