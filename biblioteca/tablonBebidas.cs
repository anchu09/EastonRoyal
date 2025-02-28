using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class tablonBebidas: Singleton<tablonBebidas>
{

    public GameObject tiza1;
    public GameObject tiza2;
    public GameObject tiza3;
    public GameObject tiza4;
    public GameObject fotoHudMision;
    public GameObject fotoInterrogracionHudMision;
    public GameObject trozocodigo;
    bool hecho = false;
    public ParticleSystem partMostaza;
    public ParticleSystem partVerde;
    public ParticleSystem partAzul;
    public ParticleSystem partNaranja;
     GameObject[] arrayDeObjetos = new GameObject[4];
     int contador =0;
    float tiempopasado = 0;

    Color colorMostaza;
    Color colorVerde ;
    Color colorAzul;
    Color colorNaranja;
    Color colorOriginal;
    void Start()
    {


        var mainModule_Mostaza = partMostaza.main;
        var mainModule_Verde = partVerde.main;
        var mainModule_Azul = partAzul.main;
        var mainModule_Naranja = partNaranja.main;

       

         colorMostaza = mainModule_Mostaza.startColor.color;
         colorVerde = mainModule_Verde.startColor.color;
         colorAzul = mainModule_Azul.startColor.color;
         colorNaranja = mainModule_Naranja.startColor.color;


        arrayDeObjetos[0] = tiza1;
        arrayDeObjetos[1] = tiza2;
        arrayDeObjetos[2] = tiza3;
        arrayDeObjetos[3] = tiza4;

        colorOriginal = tiza1.GetComponent<SpriteRenderer>().material.color;

        //tiza1.GetComponent<MeshRenderer>().material.color = colorMostaza;
        //tiza2.GetComponent<MeshRenderer>().material.color = colorVerde;
        //tiza3.GetComponent<MeshRenderer>().material.color = colorAzul;
        //tiza4.GetComponent<MeshRenderer>().material.color = colorNaranja;
    }

public void pintar_Ultimo_cuadrado()
    {


        if (partMostaza.gameObject.activeInHierarchy)
        {
            arrayDeObjetos[contador].GetComponent<SpriteRenderer>().material.color = colorMostaza;
        }

        if (partVerde.gameObject.activeInHierarchy)
        {
            arrayDeObjetos[contador].GetComponent<SpriteRenderer>().material.color = colorVerde;
        }

        if (partAzul.gameObject.activeInHierarchy)
        {
            arrayDeObjetos[contador].GetComponent<SpriteRenderer>().material.color = colorAzul;
        }

        if (partNaranja.gameObject.activeInHierarchy)
        {
            arrayDeObjetos[contador].GetComponent<SpriteRenderer>().material.color = colorNaranja;
        }
        contador++;
    }

    void Update()
    {
        if(
        tiza1.GetComponent<SpriteRenderer>().material.color == colorVerde &&
        tiza2.GetComponent<SpriteRenderer>().material.color == colorMostaza &&
        tiza3.GetComponent<SpriteRenderer>().material.color == colorVerde &&
        tiza4.GetComponent<SpriteRenderer>().material.color == colorNaranja)  {



            //plinplinplin
            bebidasHechas();
                }
        else if (contador == 4)
        {

            tiempopasado += Time.deltaTime;
            if (tiempopasado >= 1.0f) {
                //meeeee erroneooooo
                AudioManager.instance.reproducirbotellasmal();
            arrayDeObjetos[0].GetComponent<SpriteRenderer>().material.color = colorOriginal;
            arrayDeObjetos[1].GetComponent<SpriteRenderer>().material.color = colorOriginal;
            arrayDeObjetos[2].GetComponent<SpriteRenderer>().material.color = colorOriginal;
            arrayDeObjetos[3].GetComponent<SpriteRenderer>().material.color = colorOriginal;
                tiempopasado = 0;
                contador = 0;
        }
}

    }

    public void bebidasHechas()
    {
        if (!hecho)
        {
            AudioManager.instance.Reproducirbotellasbien();

            float contador = 0f;
            float tiempoEspera = 1f; 

            while (contador < tiempoEspera)
            {
                contador += Time.deltaTime;
            }

            trozocodigo.gameObject.SetActive(true);
            DataManager.instance.CurrentPlayer.progreso += 6.66666666667;
            DataManager.instance.CurrentPlayer.bebidas = true;
            AudioManager.instance.Reproducirpapeldesbloqueado();

            fotoHudMision.SetActive(true);
            fotoInterrogracionHudMision.SetActive(false);
            hecho = true;
        }
    }

}
