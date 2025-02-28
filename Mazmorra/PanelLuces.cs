using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class PanelLuces : Singleton<PanelLuces>
{
    public GameObject foto1;
    public GameObject foto2;
    public GameObject foto3;
    public GameObject foto4;
    public GameObject fotoHudMision;
    public GameObject fotoInterrogracionHudMision;
    bool hecho = false;
    public GameObject offset_lleva_el_animator;
    Animator anim;
    public GameObject cosacollider;

    public GameObject libreria;

    float milisecs;

    // Start is called before the first frame update
    private void Start()
    {
        anim = offset_lleva_el_animator.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {

        milisecs += Time.deltaTime;
        if (milisecs > 1)
        {
            milisecs = 0;

            // abajo arriba derecha izquierda
            if (foto1.transform.rotation.z > 0.48f && foto1.transform.rotation.z < 0.52f&& foto2.transform.rotation.z < -0.48f && foto2.transform.rotation.z > -0.52f&& foto3.transform.rotation.z > -0.01f && foto3.transform.rotation.z < 0.01f&& foto4.transform.rotation.z > 0.69f && foto4.transform.rotation.z < 0.71f)
            {




                acabarJuegoLucesGir();
            }



        }
    }

    public void lanzaranimacionpuerta()
    {
        anim.SetTrigger("tapa");
        cosacollider.GetComponent<BoxCollider>().enabled=false  ;
    }


    public void acabarJuegoLucesGir()
    {



        if (hecho == false)
        {


            libreria.GetComponent<Animator>().SetTrigger("abrirlib");

            AudioManager.instance.ReproducirAbrirPuertaSecretaEstanteria();





            //desactivar paneles rotaciones

            foto1.GetComponent<XRGrabInteractable>().enabled = false;
            foto2.GetComponent<XRGrabInteractable>().enabled = false;
            foto3.GetComponent<XRGrabInteractable>().enabled = false;
            foto4.GetComponent<XRGrabInteractable>().enabled = false;

            DataManager.instance.CurrentPlayer.panelLuces = true;
            DataManager.instance.CurrentPlayer.progreso = DataManager.instance.CurrentPlayer.progreso + 6.66666666667;

            fotoHudMision.SetActive(true);
            fotoInterrogracionHudMision.SetActive(false);
            hecho = true;
        }
    }
}

