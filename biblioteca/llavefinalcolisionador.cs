using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class llavefinalcolisionador : Singleton<llavefinalcolisionador>
{
    public GameObject canvasFinal;
    public GameObject fotoHudMision;
    public GameObject fotoInterrogracionHudMision;
    bool hecho = false;

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "llavefinal")
        {

            finalJuego();
          
        }
    }
    public void finalJuego()
    {
        if (hecho == false)
        {
            canvasFinal.SetActive(true);
            DataManager.instance.CurrentPlayer.juegoAcabado = true;
            DataManager.instance.CurrentPlayer.progreso = DataManager.instance.CurrentPlayer.progreso + 6.66666666667;
            fotoHudMision.SetActive(true);
            fotoInterrogracionHudMision.SetActive(false);
            AudioManager.instance.Reproducirvictoria();
            hecho = true;
        }
    }
}
