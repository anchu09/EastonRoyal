using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class candadobaul : MonoBehaviour
{

    public GameObject menu;
    public void abrir_cerrar_menu_candado()
    {

        if (menu.active == true)
        {
            menu.SetActive(false);
        }
        else
        {

            menu.SetActive(true);
        }


    }
    }


