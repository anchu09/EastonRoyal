using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public Slider slider_speed;
    public Text slider_value;
    public void LoadGame()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene(1);
    }

    public void SetTime()
    {
        Configuration.time = (int)slider_speed.value;
    }

    private void Update()
    {
        slider_value.text = ((int)slider_speed.value).ToString();
    }
}
