using UnityEngine;
using UnityEngine.UI;public class VRKeyboardKey : MonoBehaviour
{    public void PressKey()
    {
        string key = GetComponentInChildren<Text>().text;

        if (key == "<--")
        {
            // Remove the last character. Building a new string from a slice is
            // cleaner than the original char-array loop and avoids an allocation.
            string current = VRKeyboard.Instance.InputText;
            if (current.Length > 0)
                VRKeyboard.Instance.InputText = current.Substring(0, current.Length - 1);
        }
        else
        {
            VRKeyboard.Instance.InputText += key;
        }
    }
}
