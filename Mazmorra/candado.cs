using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class candado : Singleton<candado>
{
    public GameObject puertaMazmorra;
    public GameObject cadenatirar;
    public GameObject celda2;

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "llave")

        {
            AudioManager.instance.ReproducirAbrirCerraduraCandado();
            puertaMazmorra.GetComponent<Animator>().SetTrigger("abrir");
            AudioManager.instance.ReproducirAbrirCeldaMazmorra();
            cadenatirar.GetComponent<XRGrabInteractable>().enabled = true;

            this.gameObject.SetActive( false);
            celda2.GetComponent<Collider>().enabled = false;

        }
    }
}
