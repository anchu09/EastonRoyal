using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cajon_nota2 : MonoBehaviour
{
    bool primera_vez = true;
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "llavecajon")
        {
              this.GetComponentInParent<Animator>().SetTrigger("cajon");
            
        }
    }
}
