using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

[Serializable]
public class SerializableUserData 
{

    public string Name { get; set; }
    public string  tiempoJuego { get; set; }
    public double progreso { get; set; }

    public bool cerilla { get; set; }
    public bool candelabro { get; set; }

    public bool panelLuces { get; set; }
    public bool palanca { get; set; }
    public bool puzleGrande { get; set; }
    public bool llave { get; set; }
    public bool cadena { get; set; }
    public bool nota { get; set; }//falta con el icono del hud
    public bool referenciaCodigo { get; set; }


    public bool bebidas { get; set; }
    public bool libros { get; set; }
    public bool globo { get; set; }
    public bool estatua { get; set; }
    public bool BaulAbierto { get; set; }
    public bool juegoAcabado { get; set; }
    public bool NotaEscritorioEncontrada { get; set; }
    public bool llavejaulaaparecida { get; set; }
    public bool NotaCajonTroncosCogida { get; set; }
    public bool NotaJaula { get; set; }


    public SerializableUserData(string _name)
    {
        this.Name = _name; 
        this.tiempoJuego = "00:00:00";
        this.progreso = 0;

        this.cerilla = false;
        this.candelabro = false;

        this.panelLuces = false;
        this.palanca = false;
        this.puzleGrande = false;
        this.llave = false;
        this.cadena = false;
        this.nota = false;
        this.referenciaCodigo = false;


        this.bebidas = false;

        this.libros = false;
        this.globo = false;
        this.estatua = false;
        this.BaulAbierto = false;
        this.juegoAcabado = false;


        this.NotaEscritorioEncontrada = false;

        this.llavejaulaaparecida = false;
        this.NotaCajonTroncosCogida = false;

        this.NotaJaula = false;
    }

}
