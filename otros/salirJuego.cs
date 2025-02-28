using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class salirJuego : MonoBehaviour
{
    // Start is called before the first frame update
 public void salir()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene("Inicio");
    }
}
