using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class botonPuzle : Singleton<botonPuzle>
{
    public GameObject[] piezas;
    public Vector3[] posiciones;
    public Quaternion[] rotaciones;
    public UnityEvent resetJuego;
    public Animation apretarboton;
    
    // Start is called before the first frame update
    void Start()
    {

        for (int i=0; i < 10; i++) {

            posiciones[i] = piezas[i].transform.position;
            rotaciones[i]= piezas[i].transform.rotation;

        }
    }
    
    public void resetearJuego()
    {
        apretarboton.Play();

        for (int i = 0; i < 10; i++)
        {
            piezas[i].transform.position = posiciones[i];
            piezas[i].transform.rotation = rotaciones[i];
        }
        cambio_colores_bloques();




    }

     void activarObjetoSecundario0()
    {
        piezas[0].transform.GetChild(0).gameObject.SetActive(true);
        Invoke("DesactivarObjetoSecundario0", 1.0f);

      
    }
     void activarObjetoSecundario02()
    {
        piezas[0].transform.GetChild(0).gameObject.SetActive(true);
        Invoke("DesactivarObjetoSecundario02", 1.0f);


    }
     void activarObjetoSecundario1()
    {
        piezas[1].transform.GetChild(0).gameObject.SetActive(true);
        Invoke("DesactivarObjetoSecundario1", 1.0f);

      
    }

     void activarObjetoSecundario2()
    {
        piezas[2].transform.GetChild(0).gameObject.SetActive(true);
        Invoke("DesactivarObjetoSecundario2", 1.0f);

       
    }

     void activarObjetoSecundario3()
    {
        piezas[3].transform.GetChild(0).gameObject.SetActive(true);
        Invoke("DesactivarObjetoSecundario3", 1.0f);



    
}

     void activarObjetoSecundario4()
    {
        piezas[4].transform.GetChild(0).gameObject.SetActive(true);
        Invoke("DesactivarObjetoSecundario4", 1.0f);


    }

     void activarObjetoSecundario42()
    {
        piezas[4].transform.GetChild(0).gameObject.SetActive(true);

        Invoke("DesactivarObjetoSecundario42", 1.0f);



    }
     void activarObjetoSecundario43()
    {
        piezas[4].transform.GetChild(0).gameObject.SetActive(true);

        Invoke("DesactivarObjetoSecundario43", 1.0f);



    }
     void activarObjetoSecundario44()
    {
        piezas[4].transform.GetChild(0).gameObject.SetActive(true);

        Invoke("DesactivarObjetoSecundario44", 1.0f);



    }
     void activarObjetoSecundario5()
    {
        piezas[5].transform.GetChild(0).gameObject.SetActive(true);
        Invoke("DesactivarObjetoSecundario5", 1.0f);

        
    }
    void activarObjetoSecundario51()
    {
        piezas[5].transform.GetChild(0).gameObject.SetActive(true);
        Invoke("DesactivarObjetoSecundario51", 1.0f);


    }
    void activarObjetoSecundario6()
    {
        piezas[6].transform.GetChild(0).gameObject.SetActive(true);
        Invoke("DesactivarObjetoSecundario6", 1.0f);
    }
    void activarObjetoSecundario61()
    {
        piezas[6].transform.GetChild(0).gameObject.SetActive(true);
        Invoke("DesactivarObjetoSecundario61", 1.0f);
    }

    void activarObjetoSecundario7()
    {
        piezas[7].transform.GetChild(0).gameObject.SetActive(true);

        Invoke("DesactivarObjetoSecundario7", 1.0f);

        
    }

     void activarObjetoSecundario8()
    {
        piezas[8].transform.GetChild(0).gameObject.SetActive(true);
        Invoke("DesactivarObjetoSecundario8", 1.0f);
    }
     void activarObjetoSecundario9()
    {
        piezas[9].transform.GetChild(0).gameObject.SetActive(true);

        Invoke("DesactivarObjetoSecundario9", 1.0f);

        

    }

  


     void DesactivarObjetoSecundario0()
    {
        piezas[0].transform.GetChild(0).gameObject.SetActive(false);
        //doble_hor_arriba
        Invoke("activarObjetoSecundario8", 1.0f);
    }
     void DesactivarObjetoSecundario02()
    {
        piezas[0].transform.GetChild(0).gameObject.SetActive(false);
        //doble_hor_arriba
        Invoke("activarObjetoSecundario51", 1.0f);
    }
     void DesactivarObjetoSecundario1()
    {
        piezas[1].transform.GetChild(0).gameObject.SetActive(false);
        //pequeño2
        Invoke("activarObjetoSecundario0", 1.0f);
        
    }

     void DesactivarObjetoSecundario2()
    {
        piezas[2].transform.GetChild(0).gameObject.SetActive(false);
        Invoke("activarObjetoSecundario3", 1.0f);

    }

     void DesactivarObjetoSecundario3()
    {
        piezas[3].transform.GetChild(0).gameObject.SetActive(false);


        //grande
        Invoke("activarObjetoSecundario1", 1.0f);
 
    }

     void DesactivarObjetoSecundario4()
    {
        piezas[4].transform.GetChild(0).gameObject.SetActive(false);

        //pequeño4
        Invoke("activarObjetoSecundario5", 1.0f);
        


    }
     void DesactivarObjetoSecundario42()
    {
        piezas[4].transform.GetChild(0).gameObject.SetActive(false);


        //pequeño3
        Invoke("activarObjetoSecundario9", 1.0f);
        

    }
     void DesactivarObjetoSecundario43()
    {
        piezas[4].transform.GetChild(0).gameObject.SetActive(false);


        //pequeño3
        Invoke("activarObjetoSecundario6", 1.0f);


    }
     void DesactivarObjetoSecundario44()
    {
        piezas[4].transform.GetChild(0).gameObject.SetActive(false);


        //acaba


    }
     void DesactivarObjetoSecundario5()
    {
        piezas[5].transform.GetChild(0).gameObject.SetActive(false);
        //doble_hor_abajo
        Invoke("activarObjetoSecundario42", 1.0f);
       
    }
    void DesactivarObjetoSecundario51()
    {
        piezas[5].transform.GetChild(0).gameObject.SetActive(false);
        //doble_hor_abajo
        Invoke("activarObjetoSecundario61", 1.0f);

    }

    void DesactivarObjetoSecundario6()
    {
        piezas[6].transform.GetChild(0).gameObject.SetActive(false);
        Invoke("activarObjetoSecundario02", 1.0f);

    }
    void DesactivarObjetoSecundario61()
    {
        piezas[6].transform.GetChild(0).gameObject.SetActive(false);
//acaba
    }
    void DesactivarObjetoSecundario7()
    {
        piezas[7].transform.GetChild(0).gameObject.SetActive(false);
        //pequeño1
        Invoke("activarObjetoSecundario2", 1.0f);
      
    }

     void DesactivarObjetoSecundario8()
    {
        piezas[8].transform.GetChild(0).gameObject.SetActive(false);
        Invoke("activarObjetoSecundario43", 1.0f);

    }
     void DesactivarObjetoSecundario9()
    {
        piezas[9].transform.GetChild(0).gameObject.SetActive(false);

        //doble_vertical_derecha
        Invoke("activarObjetoSecundario7", 1.0f);
       
    }


    void cambio_colores_bloques()
    {

        /*
        0 - peq2
        1 - grande
        2 - peq1
        3 - doble_hor_arriba
        4 - doble_hor_abajo
        5 - peq4
        6 - principal
        7 - doble vertical derecha
        8 - doble vertical izq
        9 - peq3

            */
        //doble_hor_abajo
        Invoke("activarObjetoSecundario4", 1.0f);
        

    }
    
}
