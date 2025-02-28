using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spawnearCodigo : MonoBehaviour
{
    // Start is called before the first frame update
    public Transform posicion_spawneo;
    public GameObject codigo;
    public GameObject menu;



    public void spawnear()
    {
        menu.SetActive(false);

        codigo.transform.position = posicion_spawneo.position;

    }
}
