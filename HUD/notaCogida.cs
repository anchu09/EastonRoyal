using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class notaCogida : Singleton<notaCogida>
{
    // Start is called before the first frame update
     bool notaestanteria = false;
     bool notaJaula = false;
     bool notaTroncos = false;
     bool notaMazmorra = false;


    public GameObject foto_hud_notaestanteria;
    public GameObject foto_hud_notaJaula;
    public GameObject foto_hud_notaTroncos;
    public GameObject foto_hud_notaMazmorra;

    public GameObject fondo_foto_hud_notaestanteria;
    public GameObject fondo_foto_hud_notaJaula;
    public GameObject fondo_foto_hud_notaTroncos;
    public GameObject fondo_foto_hud_notaMazmorra;



    
    public void coger_notaLibros()
    {
        if (notaestanteria == false)
        {

            foto_hud_notaestanteria.SetActive(true);
            fondo_foto_hud_notaestanteria.SetActive(false);
            DataManager.instance.CurrentPlayer.libros = true;
            DataManager.instance.CurrentPlayer.progreso = DataManager.instance.CurrentPlayer.progreso + 6.66666666667;
            notaestanteria = true;
        }
    }

    public void coger_notaEscritorio()
    {

        DataManager.instance.CurrentPlayer.NotaEscritorioEncontrada = true;

    }

    public void coger_notaJaula()
    {
        if (notaJaula == false)
        {
            foto_hud_notaJaula.SetActive(true);
        fondo_foto_hud_notaJaula.SetActive(false);
        DataManager.instance.CurrentPlayer.NotaJaula= true;
        DataManager.instance.CurrentPlayer.progreso = DataManager.instance.CurrentPlayer.progreso + 6.66666666667;
            notaJaula = true;

        }
    }

    public void coger_notaTroncos()
        {
            if (notaTroncos == false)
            {
                foto_hud_notaTroncos.SetActive(true);
        fondo_foto_hud_notaTroncos.SetActive(false);
        DataManager.instance.CurrentPlayer.NotaCajonTroncosCogida = true;
        DataManager.instance.CurrentPlayer.progreso = DataManager.instance.CurrentPlayer.progreso + 6.66666666667;
            notaTroncos = true;

        }
    }

    public void coger_notaMazmorra()
            {
                if (notaMazmorra == false)
                {
                    foto_hud_notaMazmorra.SetActive(true);
        fondo_foto_hud_notaMazmorra.SetActive(false);
        DataManager.instance.CurrentPlayer.nota = true;
        DataManager.instance.CurrentPlayer.progreso = DataManager.instance.CurrentPlayer.progreso + 6.66666666667;
            notaMazmorra = true;

        }
    }

}
