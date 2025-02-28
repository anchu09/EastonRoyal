using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cerilla : Singleton<cerilla> { 
    public GameObject fotocerilla;
    public GameObject fondo_fotocerilla;


    public GameObject fotoHudMision;
    public GameObject fotoInterrogracionHudMision;

    bool hecho = false;




    public void cerillacogida()
    {
        if (hecho == false) {
        DataManager.instance.CurrentPlayer.cerilla = true;
        DataManager.instance.CurrentPlayer.progreso = DataManager.instance.CurrentPlayer.progreso + 6.66666666667;
        fotocerilla.SetActive(true);
        fondo_fotocerilla.SetActive(false);
        fotoHudMision.SetActive(true);
        fotoInterrogracionHudMision.SetActive(false);
            hecho = true;
        }
    }
}
