using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cilindroGir2 : MonoBehaviour
{
    public Animator animacionGirar;




    public void lanzarAnimacion()
    {
        animacionGirar.SetTrigger("giro2");
    }
}
