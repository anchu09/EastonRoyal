using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class estatua : Singleton<estatua>
{


    public Animator hombro1;
    public Animator biceps1;
    public Animator antebrazo1;
    public Animator mano1;
    public Animator dedo;
    public Animator biceps2;
    public Animator antebrazo2;
    public Animator mano2;
    public Animator cabeza;
    public Animator pierna;
    public Animator pie;
    bool hecho = false;
    string animacion_hombro1;
    string animacion_biceps1;
    string animacion_antebrazo1;
    string animacion_mano1;
    string animacion_dedo;
    string animacion_biceps2;
    string animacion_antebrazo2;
    string animacion_mano2;
    string animacion_cabeza;
    string animacion_pierna;
    string animacion_pie;
    public GameObject fotoHudMision;
    public GameObject fotoInterrogracionHudMision;
    public GameObject papelcodigo;

    bool se_puede = true;

    // Start is called before the first frame update
    void Start()
    {
        //int hombro1_aleatorio = Random.Range(1, 3);
       // hombro1.SetTrigger("" + hombro1_aleatorio);

        int biceps1_aleatorio = Random.Range(1, 3);
        biceps1.SetTrigger("" + biceps1_aleatorio);


        //int antebrazo1_aleatorio = Random.Range(1, 3);
        //antebrazo1.SetTrigger("" + antebrazo1_aleatorio);

        //int mano1_aleatorio = Random.Range(1, 3);
        //mano1.SetTrigger("" + mano1_aleatorio);

        //int dedo_aleatorio = Random.Range(1, 3);
        //dedo.SetTrigger("" + dedo_aleatorio);

        int biceps2_aleatorio = Random.Range(1, 3);
        biceps2.SetTrigger("" + biceps2_aleatorio);

        //int antebrazo2_aleatorio = Random.Range(1, 3);
        //antebrazo2.SetTrigger("" + antebrazo2_aleatorio);

        //int mano2_aleatorio = Random.Range(1, 3);
        //mano2.SetTrigger("" + mano2_aleatorio);

        int cabeza_aleatorio = Random.Range(1, 4);
        cabeza.SetTrigger("" + cabeza_aleatorio);

        int pierna_aleatorio = Random.Range(1, 3);
        pierna.SetTrigger("" + pierna_aleatorio);

        //int pie_aleatorio = Random.Range(1, 3);
        //pie.SetTrigger("" + pie_aleatorio);


    }


    public void cambiohombro1()
    {
        if (se_puede == true)
        {
            se_puede = false;

            hombro1.SetTrigger("cambio");
            Invoke("resetbolean", 2.0f);

        }
    }


    public void cambiobiceps1()
    {
        if (se_puede == true)
        {
            se_puede = false;

            biceps1.SetTrigger("cambio");
            Invoke("resetbolean", 2.0f);


        }
    }

    public void cambioantebrazo1()
    {
        if (se_puede == true)
        {
            se_puede = false;

            antebrazo1.SetTrigger("cambio");
            Invoke("resetbolean", 2.0f);

        }
    }

    public void cambiomano1()
    {
        if (se_puede == true)
        {
            se_puede = false;

            mano1.SetTrigger("cambio");
            Invoke("resetbolean", 2.0f);


        }
    }

    public void cambiodedo()
    {
        if (se_puede == true)
        {
            se_puede = false;

            dedo.SetTrigger("cambio");
            Invoke("resetbolean", 2.0f);


        }
    }

    public void cambiobiceps2()
    {
        if (se_puede == true)
        {
            se_puede = false;

            biceps2.SetTrigger("cambio");
            Invoke("resetbolean", 2.0f);


        }
    }

    public void cambioantebrazo2()
    {
        if (se_puede == true)
        {
            se_puede = false;

            antebrazo2.SetTrigger("cambio");
            Invoke("resetbolean", 2.0f);


        }
    }

    public void cambiomano2()
    {
        if (se_puede == true)
        {
            se_puede = false;

            mano2.SetTrigger("cambio");
            Invoke("resetbolean", 2.0f);


        }
    }

    public void cambiocabeza()
    {
        if (se_puede == true)
        {
            se_puede = false;

            cabeza.SetTrigger("cambio");
            Invoke("resetbolean", 2.0f);


        }
    }

    public void cambiopierna()
    {
        if (se_puede == true)
        {
            se_puede = false;

            pierna.SetTrigger("cambio");
            Invoke("resetbolean", 2.0f);


        }
    }

    public void cambiopie()
    {
        if (se_puede == true)
        {
            se_puede = false;

            pie.SetTrigger("cambio");
            Invoke("resetbolean", 2.0f);


        }
    }
    // Update is called once per frame
    void Update()
    {
        try
        {
            //Debug.Log(hombro1.GetCurrentAnimatorClipInfo(0)[0].clip.name);
            // Debug.Log(biceps1.GetCurrentAnimatorClipInfo(0)[0].clip.name);
            // Debug.Log(antebrazo1.GetCurrentAnimatorClipInfo(0)[0].clip.name);
            // Debug.Log(mano1.GetCurrentAnimatorClipInfo(0)[0].clip.name);
            // Debug.Log(dedo.GetCurrentAnimatorClipInfo(0)[0].clip.name);
            // Debug.Log(biceps2.GetCurrentAnimatorClipInfo(0)[0].clip.name);
            // Debug.Log(antebrazo2.GetCurrentAnimatorClipInfo(0)[0].clip.name);
            // Debug.Log(mano2.GetCurrentAnimatorClipInfo(0)[0].clip.name);
            // Debug.Log(cabeza.GetCurrentAnimatorClipInfo(0)[0].clip.name);
            // Debug.Log(pierna.GetCurrentAnimatorClipInfo(0)[0].clip.name);
            // Debug.Log(pie.GetCurrentAnimatorClipInfo(0)[0].clip.name);
            // Debug.Log("-----------------------");


            if (
            // hombro1.GetCurrentAnimatorClipInfo(0)[0].clip.name == "buena" &&
            biceps1.GetCurrentAnimatorClipInfo(0)[0].clip.name == "biceps1_buena" &&
            // antebrazo1.GetCurrentAnimatorClipInfo(0)[0].clip.name == "antebrazo1_buena" &&
            //  mano1.GetCurrentAnimatorClipInfo(0)[0].clip.name == "mano1_buena" &&
            // dedo.GetCurrentAnimatorClipInfo(0)[0].clip.name == "dedo_buena" &&
            biceps2.GetCurrentAnimatorClipInfo(0)[0].clip.name == "biceps2buena" &&
            // antebrazo2.GetCurrentAnimatorClipInfo(0)[0].clip.name == "antebrazo2_buena" &&
            // mano2.GetCurrentAnimatorClipInfo(0)[0].clip.name == "mano2_buena" &&
            cabeza.GetCurrentAnimatorClipInfo(0)[0].clip.name == "cabeza_buena" &&
            pierna.GetCurrentAnimatorClipInfo(0)[0].clip.name == "pierna_buena" 
            // pie.GetCurrentAnimatorClipInfo(0)[0].clip.name == "buena"


                )
            {

                estatuahecha();

            }
        }
        catch (System.IndexOutOfRangeException ex)
        {
            // Manejo de la excepción de división entre cero
        }


    }
    public void estatuahecha()
    {
        if (hecho == false)
        {
            papelcodigo.SetActive(true);
            DataManager.instance.CurrentPlayer.progreso = DataManager.instance.CurrentPlayer.progreso + 6.66666666667;
            DataManager.instance.CurrentPlayer.estatua = true;
            AudioManager.instance.Reproducirpapeldesbloqueado();

            fotoHudMision.SetActive(true);
            fotoInterrogracionHudMision.SetActive(false);
            hecho = true;
        }
    }

    public void resetbolean()
    {
        se_puede = true;

    }

}
