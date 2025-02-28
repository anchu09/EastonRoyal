using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class piano : MonoBehaviour
{


    public AudioSource[] pianos;
    public void reproducir_piano()
    {

        for (int i = 0; i < pianos.Length; i++)
        {
            pianos[i].Stop();
        }

        int numeroAleatorio = Random.Range(0, pianos.Length);
        pianos[numeroAleatorio].Play();
    }

}
