using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cilindroGir3 : MonoBehaviour
{
    public Animator animacionGirar;

    public void lanzarAnimacion()
    {
        animacionGirar.SetTrigger("giro3");
    }
}
