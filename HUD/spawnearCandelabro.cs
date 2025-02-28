using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class spawnearCandelabro : MonoBehaviour
{
    // Start is called before the first frame update
    public Transform posicion_spawneo;
    public GameObject candelabro;
    public GameObject menu;
    public void spawnear()
    {
        menu.SetActive(false);
    candelabro.transform.position = posicion_spawneo.position;

    }
}
