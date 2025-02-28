using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.UI;

public class DataManager : Singleton<DataManager>
{
    public GameObject usuarioPrefab;
    public GameObject usuariosPadre;
    public String nameCurrentPlayer;
    public InputField nombreInputField;
    public float milisecs;
    public int secs;
    public List<SerializableUserData> usersdatalist = new List<SerializableUserData>();
    public SerializableUserData CurrentPlayer { get; set; }
    public bool botonApretado=false;
    public List<string> nombres;
    public string pathCurrentPlayer;
    public int autoguardado;
    /*TODO
     * 1. Metodo Insert -> Insertar un usuario creando un objeto serializable
     * 2. Metodo GetData -> Cargar la información de todos los Usuarios en una lista.
     * 3. Metodo UIData -> Mostrar datos de todos los usuarios en la interfaz.
     */
    private void Start()
    {
        ShowDataUI();

        secs = 0;
        autoguardado = 0;


         milisecs = 0;

    }
    private void Update()
    {
        milisecs += Time.deltaTime;
        if (milisecs > 1)
        {

             nameCurrentPlayer = nombreInputField.text;

            secs++;
            milisecs = 0;
            autoguardado++;

        }
      
        if (botonApretado == true){
            if (!nombres.Contains(nameCurrentPlayer))
            {
                Insert();
            }
            getCurrentPlayer();
            UnityEngine.SceneManagement.SceneManager.LoadScene("EastonRoyal");
           
            botonApretado = false;
        }
        
        if (autoguardado >60)
        {
            SaveSystem.ActualizarDatosUsuario(CurrentPlayer);
            autoguardado = 0;
        }
    }
    void Awake()
    {



        DontDestroyOnLoad(this.gameObject);
    }
    void Insert()
    {
        SerializableUserData ser_user = new SerializableUserData(nameCurrentPlayer);
        Debug.Log(ser_user);
        SaveSystem.SaveUser(ser_user);
    }

    public void getCurrentPlayer()
    {
        CurrentPlayer= SaveSystem.LoadCurrentPlayer(nameCurrentPlayer);

    }

    List<SerializableUserData> GetData()
    {
        return SaveSystem.LoadUser();
    }





void ShowDataUI()
    {
        usersdatalist = GetData();
        if (usersdatalist != null && usersdatalist.Count > 0)
        {
            nombres = new List<string>(usersdatalist.Count);

            for (int i = 0; i < usersdatalist.Count; i++)
            {
                nombres.Add(usersdatalist[i].Name);
            }

            for (int i = 0; i < usersdatalist.Count; i++)
            {
                Instantiate(usuarioPrefab, usuariosPadre.transform);
                usuariosPadre.transform.GetChild(
                    usuariosPadre.transform.childCount - 1).GetComponent<Usuario>().SetData(
                        usersdatalist[i].Name,
                        usersdatalist[i].tiempoJuego,
                        usersdatalist[i].progreso,
                        usersdatalist[i].cerilla,
                        usersdatalist[i].candelabro,
                        usersdatalist[i].panelLuces,
                        usersdatalist[i].palanca,
                        usersdatalist[i].puzleGrande,
                        usersdatalist[i].llave,
                        usersdatalist[i].cadena,
                        usersdatalist[i].nota,
                        usersdatalist[i].referenciaCodigo,
                        usersdatalist[i].bebidas,
                        usersdatalist[i].libros,
                        usersdatalist[i].globo,
                        usersdatalist[i].estatua,
                        usersdatalist[i].BaulAbierto,
                        usersdatalist[i].juegoAcabado,
                        usersdatalist[i].NotaEscritorioEncontrada,
                        usersdatalist[i].llavejaulaaparecida,
                        usersdatalist[i].NotaCajonTroncosCogida,
                        usersdatalist[i].NotaJaula
                    );
            }
        }
        else
        {
            Debug.Log("No hay usuarios para mostrar en la UI.");
            // Opcional: Puedes manejar la UI para indicar que no hay datos disponibles
        }
    }
}
