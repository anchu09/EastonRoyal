using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class botonSalir : MonoBehaviour
{
    public void salir()
    {
        // Destruir instancias singleton antes de cargar "Inicio"
        if (DataManager.instance != null)
        {
            Destroy(DataManager.instance.gameObject);
        }

        if (AudioManager.instance != null)
        {
            Destroy(AudioManager.instance.gameObject);
        }

        if (GameManager.instance != null)
        {
            Destroy(GameManager.instance.gameObject);
        }

        // Añade destrucción de otros singletons si los tienes
        // Ejemplo:
        // if (OtroSingleton.instance != null)
        // {
        //     Destroy(OtroSingleton.instance.gameObject);
        // }

        // Cargar la escena "Inicio"
        SceneManager.LoadScene("Inicio");
    }
}

