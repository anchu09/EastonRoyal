using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class cadenaBajar : Singleton<cadenaBajar>
{
    public GameObject fotoHudMision;
    public GameObject fotoInterrogracionHudMision;
    public GameObject escaleras;
    public GameObject trampilla;
    public GameObject particulas;
    bool hecho = false;
    // Start is called before the first frame update
    public void bajarcadena()
    {
        if (!hecho)
        {
            AudioManager.instance.ReproducirTirarDeCadenaDelTecho();
            this.gameObject.GetComponent<Animator>().SetTrigger("bajar");
            escaleras.SetActive(true);
            escaleras.GetComponent<Animator>().SetTrigger("escaleras");
            AudioManager.instance.ReproducirEscalerasSaliendoDePared();
            this.GetComponent<XRGrabInteractable>().enabled = false;
            trampilla.GetComponent<XRGrabInteractable>().enabled = true;

            DataManager.instance.CurrentPlayer.cadena = true;
            DataManager.instance.CurrentPlayer.progreso += 6.66666666667;
            fotoHudMision.SetActive(true);
            fotoInterrogracionHudMision.SetActive(false);
            hecho = true;

            //yield return new WaitForSeconds(2f); // Espera 5 segundos


            particulas.SetActive(true);
        }
    }

   


}
