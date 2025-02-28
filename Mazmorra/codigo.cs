using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class codigo : Singleton<codigo>
{
    public GameObject fotoreferenciaCodigo;
    public GameObject fondo_fotoreferenciaCodigo;


    bool hecho = false;



    public void codigocogido()
    {
        if (hecho == false)
        {

            DataManager.instance.CurrentPlayer.referenciaCodigo = true;
            fotoreferenciaCodigo.SetActive(true);
            fondo_fotoreferenciaCodigo.SetActive(false);
            DataManager.instance.CurrentPlayer.progreso = DataManager.instance.CurrentPlayer.progreso + 6.66666666667;

            hecho = true;
        }
    }
}
