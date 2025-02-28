using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : Singleton<AudioManager>
{
    public AudioSource musicaAmbiental1;
    public AudioSource musicaAmbiental2;
    public AudioSource encenderCerilla;
    public AudioSource encenderCandelabroConCerilla;
    public AudioSource abrirPanelDeMadera;
    public AudioSource girarCirculosDelPanelDeHuellas;
    public AudioSource abrirPuertaSecretaEstanteria;
    public AudioSource palancaGrandeClac;
    public AudioSource moverBloquesPuzzlePared;
    public AudioSource caidaDeMetalAlSuelo;
    public AudioSource abrirCeldaMazmorra;
    public AudioSource abrirCerraduraCandado;
    public AudioSource tirarDeCadenaDelTecho;
    public AudioSource escalerasSaliendoDePared;
    public AudioSource fuegoChimenea;

    public AudioSource notasRandomPiano;
    public AudioSource caerLiquidoDeBotella;
    public AudioSource abrirCerrarCajon;
    public AudioSource clavarChinchetas;
    public AudioSource abrirCerrarBaul;
    public AudioSource marcarCombinacion;
    public AudioSource moverEstatua;
    public AudioSource abrirCerrarMenus;
    public AudioSource invocarCosasDelInventario;
    public AudioSource pulsacionBotones;
    public AudioSource cambioDeNivel;
    public AudioSource caidaDeObjetosAlSuelo;
    public AudioSource cogerUnPapel;
    public AudioSource papeldesbloqueado;
    public AudioSource botellasbien;
    public AudioSource botellasmal;



    public AudioSource dondeEstoy;
    public AudioSource vozBaulAbierto;
    public AudioSource vozBebidas;
    public AudioSource vozPruebasAlgoEnComun;
    public AudioSource vozPuertaDespacho;
    public AudioSource vozSeVeBien;


    public AudioSource victoria;

    public bool bebidas = true;
    public bool algoencomun = true;
    public bool puertadespachounavez = true;
    public void ReproducidondeEstoy()
    {
        if (dondeEstoy != null)
            dondeEstoy.Play();
    }
    public void ReproducirvozBaulAbierto()
    {
        if (vozBaulAbierto != null)
            vozBaulAbierto.Play();
    }
    public void ReproducirvozBebidas()
    {
        if (bebidas == true) { 
        if (vozBebidas != null)
            vozBebidas.Play();
            bebidas = false;
    }
    }
    public void ReproducirvozPruebasAlgoEnComun()
    {


        if (algoencomun == true)
        {

            if (vozPruebasAlgoEnComun != null)
                vozPruebasAlgoEnComun.Play();
            algoencomun = false;
        }
    }
    public void ReproducirvozPuertaDespacho()
    {
        if (puertadespachounavez == true) { 
        if (vozPuertaDespacho != null)
            vozPuertaDespacho.Play();
            puertadespachounavez = false;
    }}
    public void Reproducirvictoria()
    {
        if (victoria != null)
            victoria.Play();
    }
    public void ReproducirvozSeVeBien()
    {
        if (vozSeVeBien != null)
            vozSeVeBien.Play();
    }







    public void ReproducirMusicaAmbiental1()
    {
        if (musicaAmbiental1 != null)
            musicaAmbiental1.Play();
    }


    public void Reproducirbotellasbien()
    {
        if (botellasbien != null)
            botellasbien.Play();
    }


    public void reproducirbotellasmal()
    {
        if (botellasmal != null)
            botellasmal.Play();
    }


    public void Reproducirpapeldesbloqueado()
    {
        if (papeldesbloqueado != null)
            papeldesbloqueado.Play();
    }

    public void ReproducirMusicaAmbiental2()
    {
        if (musicaAmbiental2 != null)
            musicaAmbiental2.Play();
    }

    public void ReproducirEncenderCerilla()
    {
        if (encenderCerilla != null)
            encenderCerilla.Play();
    }

    public void ReproducirEncenderCandelabroConCerilla()
    {
        if (encenderCandelabroConCerilla != null)
            encenderCandelabroConCerilla.Play();
    }

    public void ReproducirAbrirPanelDeMadera()
    {
        if (abrirPanelDeMadera != null)
            abrirPanelDeMadera.Play();
    }

    public void ReproducirGirarCirculosDelPanelDeHuellas()
    {
        if (girarCirculosDelPanelDeHuellas != null)
            girarCirculosDelPanelDeHuellas.Play();
    }

    public void ReproducirAbrirPuertaSecretaEstanteria()
    {
        if (abrirPuertaSecretaEstanteria != null)
            abrirPuertaSecretaEstanteria.Play();
    }

    public void ReproducirPalancaGrandeClac()
    {
        if (palancaGrandeClac != null)
            palancaGrandeClac.Play();
    }

    public void ReproducirMoverBloquesPuzzlePared()
    {
        if (moverBloquesPuzzlePared != null)
            moverBloquesPuzzlePared.Play();
    }

    public void ReproducirCaidaDeMetalAlSuelo()
    {
        if (caidaDeMetalAlSuelo != null)
            caidaDeMetalAlSuelo.Play();
    }

    public void ReproducirAbrirCeldaMazmorra()
    {
        if (abrirCeldaMazmorra != null)
            abrirCeldaMazmorra.Play();
    }

    public void ReproducirAbrirCerraduraCandado()
    {
        if (abrirCerraduraCandado != null)
            abrirCerraduraCandado.Play();
    }

    public void ReproducirTirarDeCadenaDelTecho()
    {
        if (tirarDeCadenaDelTecho != null)
            tirarDeCadenaDelTecho.Play();
    }

    public void ReproducirEscalerasSaliendoDePared()
    {
        if (escalerasSaliendoDePared != null)
            escalerasSaliendoDePared.Play();
    }

    public void ReproducirFuegoChimenea()
    {
        if (fuegoChimenea != null)
            fuegoChimenea.Play();
    }



    public void ReproducirNotasRandomPiano()
    {
        if (notasRandomPiano != null)
            notasRandomPiano.Play();
    }

    public void ReproducirCaerLiquidoDeBotella()
    {
        if (caerLiquidoDeBotella != null)
            caerLiquidoDeBotella.Play();
    }

    public void ReproducirAbrirCerrarCajon()
    {
        if (abrirCerrarCajon != null)
            abrirCerrarCajon.Play();
    }

    public void ReproducirClavarChinchetas()
    {
        if (clavarChinchetas != null)
            clavarChinchetas.Play();
    }

    public void ReproducirAbrirCerrarBaul()
    {
        if (abrirCerrarBaul != null)
            abrirCerrarBaul.Play();
    }

    public void ReproducirMarcarCombinacion()
    {
        if (marcarCombinacion != null)
            marcarCombinacion.Play();
    }

    public void ReproducirMoverEstatua()
    {
        if (moverEstatua != null)
            moverEstatua.Play();
    }

    public void ReproducirAbrirCerrarMenus()
    {
        if (abrirCerrarMenus != null)
            abrirCerrarMenus.Play();
    }

    public void ReproducirInvocarCosasDelInventario()
    {
        if (invocarCosasDelInventario != null)
            invocarCosasDelInventario.Play();
    }

    public void ReproducirPulsacionBotones()
    {
        if (pulsacionBotones != null)
            pulsacionBotones.Play();
    }

    public void ReproducirCambioDeNivel()
    {
        if (cambioDeNivel != null)
            cambioDeNivel.Play();
    }

    public void ReproducirCaidaDeObjetosAlSuelo()
    {
        if (caidaDeObjetosAlSuelo != null)
            caidaDeObjetosAlSuelo.Play();
    }

    public void ReproducirCogerUnPapel()
    {
        if (cogerUnPapel != null)
            cogerUnPapel.Play();
    }
}
