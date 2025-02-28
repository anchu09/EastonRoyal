using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cilindroGir4 : MonoBehaviour
{
    public Animator animacionGirar;

    public void lanzarAnimacion()
    {
        animacionGirar.SetTrigger("giro4");
    }
}
