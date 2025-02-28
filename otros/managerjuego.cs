using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class managerjuego : MonoBehaviour
{

    //declaramos todos los campos del hud de todo el rato
    public Text tiempoDeJuego;
    public Text progreso;




    public GameObject mazmorra;
    public GameObject biblioteca;
    public Transform localizacionInicioBiblioteca;
    public AudioSource musicanormal;
    public AudioSource musicajuego;
    public GameObject teleportObjeto;

    string tiempoJuego = "";
    public int segundosJuego = 0;
    public int minutosJuego = 0;
    public int horasJuego = 0;
    float milisecs;

    public bool juegoEmpezado;

    //    //declaramos todos los campos del hud de compraventa

    //    // Start is called before the first frame update
    void Start()
    {

        juegoEmpezado = true;
        tiempoJuego = DataManager.instance.CurrentPlayer.tiempoJuego; //hh:mm:ss
        //string[] partesTiempo = tiempoJuego.Split(':');



        //horasJuego = int.TryParse(partesTiempo[0], out horasJuego) ? horasJuego : 0;
        //minutosJuego = int.TryParse(partesTiempo[1], out minutosJuego) ? minutosJuego : 0;
        //segundosJuego = int.TryParse(partesTiempo[2], out segundosJuego) ? segundosJuego : 0;
        //DataManager.instance.CurrentPlayer.progreso = 0;



        // troncosTexto.text = DataManager.instance.CurrentPlayer.misiones_sec.ToString();

        //activo todo lo conseguidode la mazmorra si la ubicacion es la biblioteca. sino no activo nada desde el principio       






        //if (DataManager.instance.CurrentPlayer.cerilla == true)
        //{
        //    cerilla.instance.cerillacogida();

        //}
        //if (DataManager.instance.CurrentPlayer.candelabro == true)
        //{
        //    candelabro.instance.candelabroactivado();

        //}

        //if (DataManager.instance.CurrentPlayer.referenciaCodigo == true)
        //{
        //    codigo.instance.codigocogido();

        //}


        //if (DataManager.instance.CurrentPlayer.panelLuces == true)
        //{
        //    PanelLuces.instance.acabarJuegoLucesGir();

        //}

        //if (DataManager.instance.CurrentPlayer.palanca == true)
        //{
        //    palanca.instance.abrirLucesGenerales();

        //}
        //if (DataManager.instance.CurrentPlayer.puzleGrande == true)
        //{
        //    animaciones_puzle.instance.puzleacabado();

        //}
        //if (DataManager.instance.CurrentPlayer.nota == true)
        //{
        //    notaCogida.instance.coger_notaMazmorra();
        //}





        //if (DataManager.instance.CurrentPlayer.cadena == true)
        //{
        //    mazmorra.SetActive(false);
        //    biblioteca.SetActive(true);

        //    cadenaBajar.instance.bajarcadena();
        //}
        //if (DataManager.instance.CurrentPlayer.bebidas == true)
        //{
        //    tablonBebidas.instance.bebidasHechas();
        //}
        //if (DataManager.instance.CurrentPlayer.libros == true)
        //{
        //    notaCogida.instance.coger_notaLibros();
        //}
        //if (DataManager.instance.CurrentPlayer.globo == true)
        //{
        //    chincheta.instance.chinchetaHecha();
        //}
        //if (DataManager.instance.CurrentPlayer.estatua == true)
        //{
        //    estatua.instance.estatuahecha();

        //}
        //if (DataManager.instance.CurrentPlayer.BaulAbierto == true)
        //{
        //    baulhud.instance.baulHecho();
        //}
        //if (DataManager.instance.CurrentPlayer.juegoAcabado == true)
        //{
        //    llavefinalcolisionador.instance.finalJuego();

        //}
        //if (DataManager.instance.CurrentPlayer.NotaEscritorioEncontrada == true)
        //{
        //    notaCogida.instance.coger_notaEscritorio();
        //}

        //if (DataManager.instance.CurrentPlayer.NotaCajonTroncosCogida == true)
        //{
        //    notaCogida.instance.coger_notaTroncos();
        //}
        //if (DataManager.instance.CurrentPlayer.NotaJaula == true)
        //{
        //    notaCogida.instance.coger_notaJaula();
        //}



        //if (DataManager.instance.CurrentPlayer.cadena == true)
        //{


        //    teleportObjeto.transform.position = localizacionInicioBiblioteca.position;

        //}

    }

    //    // Update is called once per frame
    //    void Update()
    //    {



    //        milisecs += Time.deltaTime;
    //        if (milisecs > 1)
    //        {
    //            milisecs = 0;

    //            segundosJuego++;
    //            if (segundosJuego == 60)
    //            {
    //                minutosJuego++;
    //                segundosJuego = 0;
    //                if (minutosJuego == 60)
    //                {
    //                    horasJuego++;
    //                    minutosJuego = 0;
    //                }
    //            }


    //            tiempoDeJuego.text = horasJuego.ToString("00") + ":" + minutosJuego.ToString("00") + ":" + segundosJuego.ToString("00");
    //            progreso.text = DataManager.instance.CurrentPlayer.progreso.ToString() + "%";
    //        }


    //    }





}
