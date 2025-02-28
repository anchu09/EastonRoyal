using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class chincheta : Singleton<chincheta>
{
    bool hecho = false;
    public GameObject papelcodigo;
    public GameObject cajonfotos;
    Animator animacionchincheta;
    public GameObject fotoHudMision;
    public GameObject fotoInterrogracionHudMision;
    private void Start()
    {
        animacionchincheta=this.GetComponentInChildren<Animator>();
    }
    public void lanzar_animacion_chincheta()
    {
        animacionchincheta.SetTrigger("pinchar");
        if (this.tag == "chincheta_buena"&& cajonfotos.GetComponent<cajonesEscritorio>().tocadas==true)
        {
            chinchetaHecha();
        }
    }

    public void chinchetaHecha()
    {
        if (hecho == false)
        {
            papelcodigo.SetActive(true);
            AudioManager.instance.Reproducirpapeldesbloqueado();
            DataManager.instance.CurrentPlayer.globo = true;
            DataManager.instance.CurrentPlayer.progreso = DataManager.instance.CurrentPlayer.progreso + 6.66666666667;

            fotoHudMision.SetActive(true);
            fotoInterrogracionHudMision.SetActive(false);

            hecho = true;
        }
    }
}
