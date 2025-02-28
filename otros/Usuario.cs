using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Usuario : MonoBehaviour
{
    public Text t_name;
    public Text t_tiempoJuego;
    public Text t_progreso;
    public Text t_cerilla;
    public Text t_candelabro;
    public Text t_panelLuces;
    public Text t_palanca;
    public Text t_puzleGrande;
    public Text t_llave;
    public Text t_cadena;
    public Text t_nota;
    public Text t_referenciaCodigo;
    public Text t_bebidas;
    public Text t_libros;
    public Text t_globo;
    public Text t_estatua;
    public Text t_BaulAbierto;
    public Text t_juegoAcabado;
    public Text t_NotaEscritorioEncontrada;
    public Text t_llavejaulaaparecida;
    public Text t_NotaCajonTroncosCogida;
    public Text t_NotaJaula;


    internal void SetData(string name,string tiempoJuego, double progreso, bool cerilla, bool candelabro, bool panelLuces, bool palanca, bool puzleGrande, bool llave, bool cadena, bool nota, bool referenciaCodigo, bool bebidas, bool libros, bool globo, bool estatua, bool baulAbierto, bool juegoAcabado, bool notaEscritorioEncontrada, bool llavejaulaaparecida, bool notaCajonTroncosCogida, bool notaJaula)
    {
        t_name.text = name;
        t_tiempoJuego.text = tiempoJuego;
        t_progreso.text = progreso.ToString();
        t_cerilla.text = cerilla.ToString();
        t_candelabro.text = candelabro.ToString();
        t_panelLuces.text = panelLuces.ToString();
        t_palanca.text = palanca.ToString();
        t_puzleGrande.text = puzleGrande.ToString();
        t_llave.text = llave.ToString();
        t_cadena.text = cadena.ToString();
        t_nota.text = nota.ToString();
        t_referenciaCodigo.text = referenciaCodigo.ToString();
        t_bebidas.text = bebidas.ToString();
        t_libros.text = libros.ToString();
        t_globo.text = globo.ToString();
        t_estatua.text = estatua.ToString();
        t_BaulAbierto.text = baulAbierto.ToString();
        t_juegoAcabado.text = juegoAcabado.ToString();
        t_NotaEscritorioEncontrada.text = notaEscritorioEncontrada.ToString();
        t_llavejaulaaparecida.text = llavejaulaaparecida.ToString();
        t_NotaCajonTroncosCogida.text = notaCajonTroncosCogida.ToString();
        t_NotaJaula.text = notaJaula.ToString();
    }
}
