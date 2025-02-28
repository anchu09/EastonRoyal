using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class baulhud : Singleton<baulhud>
{

    public Text digito1;
    public Text digito2;
    public Text digito3;
    public Text digito4;
    public GameObject fotoHudMision;
    public GameObject fotoInterrogracionHudMision;
    Animator animadorbaul;
    public GameObject baul;
    bool hecho = false;

    private void Start()
    {
        animadorbaul = baul.GetComponent<Animator>();
    }
    int ParseToInt(string text)
    {
        int resultado = 0;
        if (int.TryParse(text, out resultado))
        {
            return resultado;
        }
        else
        {
            Debug.LogError("Error al parsear la cadena de texto a un entero.");
            return 0; 
        }
    }

    public void subir1()
    {

        int numeroParseado = ParseToInt(digito1.text);

        if (numeroParseado == 9)
        {
            numeroParseado = 0;
        }
        else
        {
            numeroParseado = numeroParseado + 1;

        }
        digito1.text = numeroParseado.ToString();
    }

    public void subir2()
    {
        int numeroParseado = ParseToInt(digito2.text);

        if (numeroParseado == 9)
        {
            numeroParseado = 0;
        }
        else
        {
            numeroParseado = numeroParseado + 1;

        }
        digito2.text = numeroParseado.ToString();
    }

    public void subir3()
    {
        int numeroParseado = ParseToInt(digito3.text);

        if (numeroParseado == 9)
        {
            numeroParseado = 0;
        }
        else
        {
            numeroParseado = numeroParseado + 1;

        }
        digito3.text = numeroParseado.ToString();
    }

    public void subir4()
    {
        int numeroParseado = ParseToInt(digito4.text);

        if (numeroParseado == 9)
        {
            numeroParseado = 0;
        }
        else
        {
            numeroParseado = numeroParseado + 1;

        }

        digito4.text = numeroParseado.ToString();
    }


    public void bajar1()
    {
        int numeroParseado = ParseToInt(digito1.text);

        if (numeroParseado == 0)
        {
            numeroParseado = 9;
        }
        else
        {
            numeroParseado = numeroParseado - 1;

        }

        digito1.text = numeroParseado.ToString();
    }

    public void bajar2()
    {
        int numeroParseado = ParseToInt(digito2.text);

        if (numeroParseado == 0)
        {
            numeroParseado = 9;
        }
        else
        {
            numeroParseado = numeroParseado - 1;

        }

        digito2.text = numeroParseado.ToString();
    }

    public void bajar3()
    {
        int numeroParseado = ParseToInt(digito3.text);

        if (numeroParseado == 0)
        {
            numeroParseado = 9;
        }
        else
        {
            numeroParseado = numeroParseado - 1;

        }

        digito3.text = numeroParseado.ToString();
    }

    public void bajar4()
    {
        int numeroParseado = ParseToInt(digito4.text);

        if (numeroParseado == 0)
        {
            numeroParseado = 9;
        }
        else
        {
            numeroParseado = numeroParseado - 1;

        }

        digito4.text = numeroParseado.ToString();
    }

    private void Update()
    {
        if(
            digito1.text == "4" &&
            digito2.text == "7" &&
            digito3.text == "1" &&
            digito4.text == "5"
            )
        {
            baulHecho();
            AudioManager.instance.ReproducirvozBaulAbierto();
        }
    }
    public void baulHecho()
    {
        if (hecho == false)
        {
            baul.GetComponent<Animator>().SetTrigger("abrirbaul");
            AudioManager.instance.ReproducirAbrirCerrarBaul();
            DataManager.instance.CurrentPlayer.BaulAbierto = true;
            DataManager.instance.CurrentPlayer.progreso = DataManager.instance.CurrentPlayer.progreso + 6.66666666667;
            fotoHudMision.SetActive(true);
            fotoInterrogracionHudMision.SetActive(false);
            hecho = true;
        }
    }
}
