using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class paredEncenderCerilla : MonoBehaviour
{
    

    // Update is called once per frame
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "cerilla")
        {
            AudioManager.instance.ReproducirEncenderCerilla();
            other.transform.gameObject.GetComponentInChildren<ParticleSystem>().Play();
            other.transform.gameObject.GetComponentInChildren<Light>().enabled = true;
        }
    }
}
