using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class candelabro : Singleton<candelabro>
{ 
    // Start is called before the first frame update

    public GameObject foto1;
    public GameObject foto2;
    public GameObject foto3;
    public GameObject foto4;
    public GameObject tapaCaja;
    public GameObject fotocandelabro;
    public GameObject fondofotocandelabro;
    bool hecho = false;
    public GameObject fotoHudMision;
    public GameObject fotoInterrogracionHudMision;
    // Start is called before the first frame update
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "cerilla" && other.transform.gameObject.GetComponentInChildren<ParticleSystem>().isPlaying)

        {
            candelabroactivado();

            
        }
    }

    public void candelabroactivado()
    {
        if (hecho == false)
        {

            fotocandelabro.SetActive(true);
            fondofotocandelabro.SetActive(false);
            DataManager.instance.CurrentPlayer.candelabro = true;
            DataManager.instance.CurrentPlayer.progreso = DataManager.instance.CurrentPlayer.progreso + 6.66666666667;
            AudioManager.instance.ReproducirEncenderCandelabroConCerilla();
            this.GetComponentInChildren<ParticleSystem>().Play();
            this.GetComponentInChildren<Light>().enabled = true;
            this.GetComponent<XRGrabInteractable>().enabled = true;

            //activamos los xrgrab de los cilindros
            foto1.GetComponent<XRGrabInteractable>().enabled = true;
            foto2.GetComponent<XRGrabInteractable>().enabled = true;
            foto3.GetComponent<XRGrabInteractable>().enabled = true;
            foto4.GetComponent<XRGrabInteractable>().enabled = true;
            tapaCaja.GetComponent<XRGrabInteractable>().enabled = true;

            fotoHudMision.SetActive(true);
            fotoInterrogracionHudMision.SetActive(false);
            hecho = true;
        }
    }
}
