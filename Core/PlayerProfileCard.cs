using UnityEngine;
using UnityEngine.UI;

public class PlayerProfileCard : MonoBehaviour
{
    public Text t_name;
    public Text t_playTime;
    public Text t_progress;
    public Text t_matchFound;
    public Text t_candleHolderLit;
    public Text t_lightPanelSolved;
    public Text t_leverPulled;
    public Text t_bigPuzzleSolved;
    public Text t_dungeonKey;
    public Text t_chainPulled;
    public Text t_noteFound;
    public Text t_codeReferenceFound;
    public Text t_drinksFound;
    public Text t_booksFound;
    public Text t_balloonFound;
    public Text t_statueSolved;
    public Text t_chestOpened;
    public Text t_gameCompleted;
    public Text t_deskNoteFound;
    public Text t_dungeonKeyjaulaaparecida;
    public Text t_logDrawerNoteFound;
    public Text t_cageNoteFound;

    internal void SetData(SerializableUserData data)
    {
        t_name.text                    = data.Name;
        t_playTime.text             = data.playTime;
        t_progress.text                = data.progress.ToString("F1");
        t_matchFound.text                 = data.matchFound.ToString();
        t_candleHolderLit.text              = data.candleHolderLit.ToString();
        t_lightPanelSolved.text              = data.lightPanelSolved.ToString();
        t_leverPulled.text                 = data.leverPulled.ToString();
        t_bigPuzzleSolved.text             = data.bigPuzzleSolved.ToString();
        t_dungeonKey.text                   = data.dungeonKey.ToString();
        t_chainPulled.text                  = data.chainPulled.ToString();
        t_noteFound.text                    = data.noteFound.ToString();
        t_codeReferenceFound.text        = data.codeReferenceFound.ToString();
        t_drinksFound.text                 = data.drinksFound.ToString();
        t_booksFound.text                  = data.booksFound.ToString();
        t_balloonFound.text                   = data.balloonFound.ToString();
        t_statueSolved.text                 = data.statueSolved.ToString();
        t_chestOpened.text             = data.chestOpened.ToString();
        t_gameCompleted.text            = data.gameCompleted.ToString();
        t_deskNoteFound.text = data.deskNoteFound.ToString();
        t_dungeonKeyjaulaaparecida.text     = data.cageKeyAppeared.ToString();
        t_logDrawerNoteFound.text  = data.logDrawerNoteFound.ToString();
        t_cageNoteFound.text               = data.cageNoteFound.ToString();
    }
}
