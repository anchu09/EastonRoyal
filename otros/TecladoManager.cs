using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TecladoManager : Singleton<TecladoManager>
{
    public string contenido;
    public InputField inputText;
    public GameObject teclado;
    // Start is called before the first frame update
    void Start()
    {
        contenido = "";

    }

    // Update is called once per frame
    void Update()
    {
        inputText.text = contenido;

    }
    public void abrirCerrarteclado()
    {
        if (teclado.active == false)
        {
            teclado.SetActive(true);


        }
        else
        {
            teclado.SetActive(false);

        }
    }
}
