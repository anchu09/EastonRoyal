using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class desbloquearllaveceldabiblio : MonoBehaviour
{
    bool notaconocida = false;
    public GameObject codigoestatua;
    public GameObject codigoglobo;
    public GameObject llave;

    // Update is called once per frame
    void Update()
    {
        if (notaconocida == true && codigoestatua.activeInHierarchy == true && codigoglobo.activeInHierarchy == true)
        {
            llave.gameObject.SetActive(true);
        }
    }
   public void conocernota()
    {
        notaconocida = true;
    }
}
