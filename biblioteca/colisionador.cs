using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class colisionador : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "botella")
        {

            other.GetComponent<botellas>().setDentroCuadrado(true);
                }
    }

}
