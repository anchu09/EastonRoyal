using System.Collections;
using UnityEngine;
using UnityEngine.Events;

/// <summary>
/// Reset button for the sliding-block puzzle. On press, all ten puzzle pieces
/// snap back to their initial positions and a highlight animation propagates
/// across them in sequence so the player can see the blocks reset.
/// </summary>
public class PuzzleResetButton : Singleton<PuzzleResetButton>
{
    public GameObject[]  pieces;
    public Vector3[]     positions;
    public Quaternion[]  rotations;
    public UnityEvent    onReset;
    public Animation     pressAnimation;

    private const float HighlightDelay = 1.0f;

    private void Start()
    {
        // Cache the initial transforms so we can restore them on reset
        for (int i = 0; i < pieces.Length; i++)
        {
            positions[i] = pieces[i].transform.position;
            rotations[i] = pieces[i].transform.rotation;
        }
    }

    // Public entry point (called from the XR interaction event on the button)

    /// <summary>
    /// Snaps all puzzle pieces back to their start positions, fires the reset
    /// event, and starts the highlight chain that visually confirms the reset.
    /// </summary>
    public void ResetPuzzle()
    {
        pressAnimation.Play();

        for (int i = 0; i < pieces.Length; i++)
        {
            pieces[i].transform.position = positions[i];
            pieces[i].transform.rotation = rotations[i];
        }

        StartHighlightChain();
        onReset?.Invoke();
    }

    // Private — highlight animation chain
    //
    // Each piece briefly shows its child indicator GameObject, then hides it
    // and triggers the next piece. The chain matches the visual order the
    // player expects to see the blocks activate after a reset.

    private void StartHighlightChain()
        => StartCoroutine(RunHighlightChain());

    private IEnumerator RunHighlightChain()
    {
        // The highlight visits pieces in this order (by array index):
        // 4 → 5 → 9 → 7 → 2 → 3 → 1 → 0 → 8 → 6 → 0(again) → 5(again) → 6(again)
        int[] order = { 4, 5, 9, 7, 2, 3, 1, 0, 8, 6, 0, 5, 6 };

        foreach (int index in order)
        {
            ShowIndicator(index);
            yield return new WaitForSeconds(HighlightDelay);
            HideIndicator(index);
            yield return new WaitForSeconds(HighlightDelay);
        }
    }

    private void ShowIndicator(int index)
    {
        if (index < pieces.Length)
            pieces[index].transform.GetChild(0).gameObject.SetActive(true);
    }

    private void HideIndicator(int index)
    {
        if (index < pieces.Length)
            pieces[index].transform.GetChild(0).gameObject.SetActive(false);
    }
}
