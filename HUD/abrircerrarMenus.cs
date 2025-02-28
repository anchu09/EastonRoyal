using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class abrircerrarMenus : MonoBehaviour
{
    public ActionBasedController c1;
    public ActionBasedController c2;
    public GameObject menuInventario;
    public GameObject menuPausa;
    public GameObject menuProgresoMazmorra;
    public GameObject menuProgresoBiblioteca;




    private float tiempoPasado;

    void Update()
    {
        tiempoPasado += Time.deltaTime;

        if (tiempoPasado >= 0.5f)
        {

               

                if ((c1.selectAction.action.IsPressed() && c1.uiPressAction.action.IsPressed())|| (c2.selectAction.action.IsPressed() && c2.uiPressAction.action.IsPressed()))
                {
                AudioManager.instance.ReproducirAbrirCerrarMenus();

                if (menuPausa.active == false)
                {
                    if (menuInventario.active == false)
                    {
                        menuInventario.SetActive(true);
                    }
                    else
                    {
                        menuInventario.SetActive(false);

                    }
                }
            }
           

                if (c1.uiPressAction.action.IsPressed() && c2.uiPressAction.action.IsPressed())
                {
                AudioManager.instance.ReproducirAbrirCerrarMenus();

                if (menuInventario.active == false)
            {
                    if (menuPausa.active == false)
                    {
                        menuPausa.SetActive(true);

                    }
                    else
                    {
                        menuPausa.SetActive(false);
                    }
                }


            }



            if (c1.uiPressAction.action.IsPressed() && c2.uiPressAction.action.IsPressed())
            {
                if (menuProgresoMazmorra.active == true|| menuProgresoBiblioteca.active == true)
                {

                    menuProgresoMazmorra.SetActive(false);
                    menuProgresoBiblioteca.SetActive(false);


                }

            }


            tiempoPasado -= 0.5f;
            }
        }
    public void abrir_panel_progreso()
    {
        




        menuPausa.SetActive(false);
        if (GameManager.instance.nivel_actual == "mazmorra")
        {

            menuProgresoMazmorra.SetActive(true);
            AudioManager.instance.ReproducirAbrirCerrarMenus();


        }
        else
        {
            menuProgresoBiblioteca.SetActive(true);
            AudioManager.instance.ReproducirAbrirCerrarMenus();

        }
    }

}


