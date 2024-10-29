using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// Manages the VR on-screen keyboard: owns the current input string and keeps
/// the visible InputField in sync. Use <see cref="ToggleKeyboard"/> to show or
/// hide the keyboard panel.
/// </summary>
public class VRKeyboard : Singleton<VRKeyboard>
{
    public string InputText;

    [Tooltip("InputField that displays the current contents of InputText.")]
    public InputField inputText;

    [Tooltip("Root GameObject of the keyboard panel to show/hide.")]
    public GameObject keyboardPanel;

    private void Start()
    {
        InputText = string.Empty;
    }

    private void Update()
    {
        // Mirror InputText into the visible field every frame. Driven from Update
        // rather than on each keypress so the display stays correct even if
        // InputText is modified from outside this class.
        inputText.text = InputText;
    }
    public void ToggleKeyboard()
    {
        keyboardPanel.SetActive(!keyboardPanel.activeSelf);
    }
}
