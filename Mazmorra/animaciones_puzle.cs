using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class animaciones_puzle : Singleton<animaciones_puzle>
{

    public GameObject pequeno2;
    public GameObject grande;
    public GameObject pequeno1;
    public GameObject doble_hor_arriba;
    public GameObject doble_hor_abajo;
    public GameObject pequeno4;
    public GameObject doble_vertical_derecha;
    public GameObject doble_vertical_izq;
    public GameObject pequeno3;
    public GameObject principal;
    public GameObject llave;
    public GameObject boton_restart;
    public GameObject fotoHudMision;
    public GameObject fotoInterrogracionHudMision;
    Animator animat_pequeno2;
    Animator animat_grande;
    Animator animat_pequeno1;
    Animator animat_pedoble_hor_arriba;
    Animator animat_doble_hor_abajo;
    Animator animat_pequeno4;
    Animator animat_doble_vertical_derecha;
    Animator animat_doble_vertical_izq;
    Animator animat_pequeno3;
    Animator animat_principal;
    bool hecho = false;
    int actual = 0;
    bool se_puede = true;
    //cuando le doy a uno se lanza la corrutina que lo pone a false y cuando se acaba la corrutina se pone a true 

    string[] orden = new string[] { "doble_hor_abajo", "pequeno4", "doble_hor_abajo", "pequeno3", "doble_vertical_derecha", "pequeno1", "doble_hor_arriba", "grande", "pequeno2", "doble_vertical_izq", "doble_hor_abajo", "principal", "pequeno2", "pequeno4", "principal" };
    private void Start()
    {

        animat_pequeno2 = pequeno2.GetComponent<Animator>();
        animat_grande = grande.GetComponent<Animator>();
        animat_pequeno1 = pequeno1.GetComponent<Animator>();
        animat_pedoble_hor_arriba = doble_hor_arriba.GetComponent<Animator>();
        animat_doble_hor_abajo = doble_hor_abajo.GetComponent<Animator>();
        animat_pequeno4 = pequeno4.GetComponent<Animator>();
        animat_doble_vertical_derecha = doble_vertical_derecha.GetComponent<Animator>();
        animat_doble_vertical_izq = doble_vertical_izq.GetComponent<Animator>();
        animat_pequeno3 = pequeno3.GetComponent<Animator>();
        animat_principal = principal.GetComponent<Animator>();

    }


    public void fun_pequeno2()
    {
        if (se_puede == true)
        {
            if (actual == 8)
            {
                se_puede = false;
                StartCoroutine(recoil(1.0f));
                actual++;

                animat_pequeno2.SetTrigger("1_peq2");
            }
            else if (actual == 12)
            {
                se_puede = false;
                StartCoroutine(recoil(1.0f));
                actual++;

                animat_pequeno2.SetTrigger("2_peq2");
            }
            else
            {
                actual = 0;
                se_puede = false;
                StartCoroutine(recoil(1.0f));

                reset();


            }
        }
    }
    public void fun_grande()
    {
        if (se_puede == true)
        {

            if (actual == 7)
            {
                se_puede = false;
                StartCoroutine(recoil(1.0f));
                actual++;

                animat_grande.SetTrigger("grande");
            }
            else
            {
                se_puede = false;
                StartCoroutine(recoil(1.0f));
                actual = 0;
                reset();
            }
        }
    }
    public void fun_pequeno1()
    {
        if (se_puede == true)
        {

            if (actual == 5)
            {
                se_puede = false;
                StartCoroutine(recoil(1.0f));
                actual++;

                animat_pequeno1.SetTrigger("1_peq1");
            }
            else
            {
                se_puede = false;
                StartCoroutine(recoil(1.0f));
                actual = 0;
                reset();


            }
        }
    }
    public void fun_doble_hor_arriba()
    {
        if (se_puede == true)
        {

            if (actual == 6)
            {
                se_puede = false;
                StartCoroutine(recoil(1.0f));
                actual++;

                animat_pedoble_hor_arriba.SetTrigger("primera");
            }
            else
            {
                se_puede = false;
                StartCoroutine(recoil(1.0f));

                actual = 0;
                reset();
            }
        }
    }
    public void fun_doble_hor_abajo()
    {
        if (se_puede == true)
        {

            if (actual == 0)
            {
                se_puede = false;
                StartCoroutine(recoil(1.0f));
                actual++;

                animat_doble_hor_abajo.SetTrigger("1_azul_abajo");
            }
            else if (actual == 2)
            {

                se_puede = false;
                StartCoroutine(recoil(1.0f));
                actual++;

                animat_doble_hor_abajo.SetTrigger("2_azul_abajo");
            }
            else if (actual == 10)
            {
                se_puede = false;
                StartCoroutine(recoil(1.0f));
                actual++;

                animat_doble_hor_abajo.SetTrigger("3_doble_hor_abajo");
            }
            else
            {
                se_puede = false;
                StartCoroutine(recoil(1.0f));

                actual = 0;
                reset();
            }
        }
    }
    public void fun_pequeno4()
    {
        if (se_puede == true)
        {

            if (actual == 1)
            {
                se_puede = false;
                StartCoroutine(recoil(1.0f));
                actual++;

                animat_pequeno4.SetTrigger("1_peq4");
            }
            else if (actual == 13)
            {
                se_puede = false;
                StartCoroutine(recoil(1.0f));
                actual++;

                animat_pequeno4.SetTrigger("2_peq4");
            }
            else
            {
                se_puede = false;
                StartCoroutine(recoil(1.0f));


                actual = 0;
                reset();
            }
        }
    }
    public void fun_doble_vertical_derecha()
    {
        if (se_puede == true)
        {

            if (actual == 4)
            {
                se_puede = false;
                StartCoroutine(recoil(1.0f));
                actual++;

                animat_doble_vertical_derecha.SetTrigger("1_doble_vertical_derecha");
            }
            else
            {
                se_puede = false;
                StartCoroutine(recoil(1.0f));


                actual = 0;
                reset();
            }
        }
    }
    public void fun_doble_vertical_izq()
    {
        if (se_puede == true)
        {

            if (actual == 9)
            {
                se_puede = false;
                StartCoroutine(recoil(1.0f));
                actual++;

                animat_doble_vertical_izq.SetTrigger("1_doble_vert_izq");
            }
            else
            {
                se_puede = false;
                StartCoroutine(recoil(1.0f));


                actual = 0;
                reset();
            }
        }
    }
    public void fun_pequeno3()
    {
        if (se_puede == true)
        {

            if (actual == 3)
            {
                se_puede = false;
                StartCoroutine(recoil(1.0f));
                actual++;

                animat_pequeno3.SetTrigger("1_peq3");
            }
            else
            {


                se_puede = false;
                StartCoroutine(recoil(1.0f));


                actual = 0;
                reset();
            }
        }
    }
    public void fun_principal()
    {
        if (se_puede == true)
        {

            if (actual == 11)
            {
                se_puede = false;
                StartCoroutine(recoil(1.0f));
                actual++;

                animat_principal.SetTrigger("primera_principal");
            }
            else if (actual == 14)
            {
                se_puede = false;
                StartCoroutine(recoil(1.0f));


                actual++;
                animat_principal.SetTrigger("2_2");
                puzleacabado();
            }
            else
            {
                se_puede = false;
                StartCoroutine(recoil(1.0f));


                actual = 0;
                reset();
            }
        }
    }
    IEnumerator recoil(float delay)
    {
        yield return new WaitForSeconds(delay);
        se_puede = true;
    }
    public void reset()
    {
        actual = 0;

        animat_pequeno2.SetTrigger("reset");
        animat_grande.SetTrigger("reset");
        animat_pequeno1.SetTrigger("reset");
        animat_pedoble_hor_arriba.SetTrigger("reset");
        animat_doble_hor_abajo.SetTrigger("reset");
        animat_pequeno4.SetTrigger("reset");
        animat_doble_vertical_derecha.SetTrigger("reset");
        animat_doble_vertical_izq.SetTrigger("reset");
        animat_pequeno3.SetTrigger("reset");
        animat_principal.SetTrigger("reset");


        
    }

    public void puzleacabado()
    {
        if (hecho == false)
        {

            llave.SetActive(true);
            AudioManager.instance.ReproducirCaidaDeMetalAlSuelo();
            pequeno2.GetComponent<Collider>().enabled = false;
            grande.GetComponent<Collider>().enabled = false;
            pequeno1.GetComponent<Collider>().enabled = false;
            doble_hor_arriba.GetComponent<Collider>().enabled = false;
            doble_hor_abajo.GetComponent<Collider>().enabled = false;
            pequeno4.GetComponent<Collider>().enabled = false;
            doble_vertical_derecha.GetComponent<Collider>().enabled = false;
            doble_vertical_izq.GetComponent<Collider>().enabled = false;
            pequeno3.GetComponent<Collider>().enabled = false;
            principal.GetComponent<Collider>().enabled = false;
            boton_restart.GetComponent<Collider>().enabled = false;
            DataManager.instance.CurrentPlayer.puzleGrande = true;
            DataManager.instance.CurrentPlayer.progreso = DataManager.instance.CurrentPlayer.progreso + 6.66666666667;
            fotoHudMision.SetActive(true);
            fotoInterrogracionHudMision.SetActive(false);

            hecho = true;
        }
    }
}
