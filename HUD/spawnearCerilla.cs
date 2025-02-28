using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class spawnearCerilla : MonoBehaviour
{
    public Transform posicion_spawneo;
    public GameObject cerilla;
    public GameObject menu;

    

    public void spawnear()
    {
        menu.SetActive(false);
        cerilla.GetComponentInChildren<ParticleSystem>().Stop();
        cerilla.GetComponentInChildren<Light>().enabled=false;
        cerilla.transform.position = posicion_spawneo.position;

    }
 
}
