using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cilindroGiratorio : MonoBehaviour
{
    public Animator animacionGirar;
        
        public void lanzarAnimacion()
    {
        animacionGirar.SetTrigger("giro");
    }
}
