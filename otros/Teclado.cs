using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Teclado : MonoBehaviour
{
   
    
    // Start is called before the first frame update
    void Start()
    {

    }
    void Update()
    {
    }

    // Update is called once per frame
    public void escribirLetra()
    {
        
        string letra = this.gameObject.GetComponentInChildren<Text>().text;
        if (System.String.Compare(letra, "<--") == 0)
        {
            char[] aux = TecladoManager.instance.contenido.ToCharArray();
            int tam = aux.Length;
            string aux2 = "";
            for (int i =0; i < tam-1; i++)
            {
                aux2+= aux[i];
            }
            TecladoManager.instance.contenido = aux2.ToString();


        }
        else
        {
            TecladoManager.instance.contenido = TecladoManager.instance.contenido + letra;
        }
    }
}
