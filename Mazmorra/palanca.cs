using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.XR.Interaction.Toolkit;

public class palanca : Singleton<palanca>
{
    public GameObject[] fichaspuzle;
    public GameObject[] luces;
    public GameObject botonrestart;
   public  GameObject ofsetpalanca;
    public GameObject fotoHudMision;
    public GameObject fotoInterrogracionHudMision;

    bool hecho = false;
    // Start is called before the first frame update
    public void abrirLucesGenerales()
    {
        if (hecho == false)
        {

            ofsetpalanca.GetComponent<Animator>().SetTrigger("palanca");


            //actuvar todos los xrgrab del puzle

            for (int i = 0; i < 10; i++)
            {
                fichaspuzle[i].GetComponent<XRGrabInteractable>().enabled = true;
            }


            for (int i = 0; i < luces.Length ; i++)
            {

                luces[i].SetActive(true);
            }



            botonrestart.GetComponent<XRGrabInteractable>().enabled = true;
            AudioManager.instance.ReproducirPalancaGrandeClac();
            DataManager.instance.CurrentPlayer.palanca = true;
            DataManager.instance.CurrentPlayer.progreso = DataManager.instance.CurrentPlayer.progreso + 6.66666666667;
            fotoHudMision.SetActive(true);
            fotoInterrogracionHudMision.SetActive(false);
            hecho = true;
            AudioManager.instance.ReproducirvozSeVeBien();

        }
    }
}
