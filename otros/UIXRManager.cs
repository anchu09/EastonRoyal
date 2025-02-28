using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIXRManager : MonoBehaviour
{
    public Text handle_value;
    public Slider slider_time;
    public GameObject musica;
    public void ChangeTimeValue()
    {
        handle_value.text = slider_time.value.ToString();
        Parameters.time = (int)slider_time.value;
    }

    /// <summary>
    /// Methodo asignado al boton "Jugar"
    /// </summary>
    public void LoadGameScene()
    {
        DataManager.instance.botonApretado = true;
        musica.GetComponents<AudioSource>()[0].Stop();
        musica.GetComponents<AudioSource>()[1].Stop();
    }
}
