using System.IO;
using System;
using System.Collections.Generic;
using UnityEngine;
using System.Runtime.Serialization.Formatters.Binary;

public static class SaveSystem
{
    public static void SaveUser(SerializableUserData user)
    {
        //Creo el directorio
        if (!Directory.Exists(Application.persistentDataPath + "/data"))
        {
            Directory.CreateDirectory(Application.persistentDataPath + "/data");

        }
        Debug.Log(Application.persistentDataPath + "/data");
        //Defino la ruta de mis binarios
        string path = Application.persistentDataPath + "/data";

        int num_files = Directory.GetFiles(path, "user*", SearchOption.TopDirectoryOnly).Length;
        if (num_files > 0)
        {
            BinaryFormatter formatter = new BinaryFormatter();
            string s_value = (num_files + 1).ToString();
            string path_name = path + "/user" + s_value + ".data";
            FileStream stream = new FileStream(path_name, FileMode.Create);
            //insert this data into the file
            formatter.Serialize(stream, user);
            stream.Close();
        }
        else
        {
            BinaryFormatter formatter = new BinaryFormatter();
            string path_name = path + "/user1.data";
            FileStream stream = new FileStream(path_name, FileMode.Create);
            //insert this data into the file
            formatter.Serialize(stream, user);
            stream.Close();
        }
    }

    public static void ActualizarDatosUsuario(SerializableUserData user)
    {
       
        string path = DataManager.instance.pathCurrentPlayer;

       
            BinaryFormatter formatter = new BinaryFormatter();
            FileStream stream = new FileStream(path, FileMode.Create);
            //insert this data into the file
            formatter.Serialize(stream, user);
            stream.Close();
        
    }

    public static List<SerializableUserData> LoadUser()
    {
        string path_name = Application.persistentDataPath + "/data";
        Debug.Log("Path: " + path_name);
        int num_files = Directory.GetFiles(path_name, "*", SearchOption.TopDirectoryOnly).Length;
        if (num_files > 0)
        {
            Debug.Log("ARCHIVOS ENCONTRADOS: " + num_files);
            List<SerializableUserData> users = new List<SerializableUserData>();
            for (int i = 1; i < num_files + 1; i++)
            {
                BinaryFormatter bf = new BinaryFormatter();
                string filePath = Path.Combine(path_name, $"user{i}.data");
                if (File.Exists(filePath))
                {
                    using (FileStream fs = new FileStream(filePath, FileMode.Open))
                    {
                        SerializableUserData aux_user = bf.Deserialize(fs) as SerializableUserData;
                        users.Add(aux_user);
                    }
                }
                else
                {
                    Debug.LogWarning($"El archivo {filePath} no existe.");
                }
            }

            return users;
        }
        else
        {
            Debug.Log("No se encontraron archivos de guardado en: " + path_name);
            return new List<SerializableUserData>(); 
        }
    }

    public static SerializableUserData LoadCurrentPlayer(String name)
    {
        Debug.Log(Application.persistentDataPath + "/data");

        string path_name = Application.persistentDataPath + "/data";
        Debug.Log("Path: " + path_name);
        int num_files = Directory.GetFiles(path_name, "*", SearchOption.TopDirectoryOnly).Length;
        if (num_files > 0)
        {
            Debug.Log("ARCHIVOS ENCONTRADOS: " + num_files);
            List<SerializableUserData> users = new List<SerializableUserData>();
            List<string> paths = new List<string>();
            for (int i = 1; i < num_files + 1; i++)
            {
                BinaryFormatter bf = new BinaryFormatter();
                FileStream fs = new FileStream(path_name + "/user" + i.ToString() + ".data", FileMode.Open);

                //Reading the open flie
                SerializableUserData aux_user = bf.Deserialize(fs) as SerializableUserData;
                fs.Close();
                if (aux_user.Name.CompareTo(name)==0)
                {
                    users.Add(aux_user);
                    paths.Add(path_name + "/user" + i.ToString() + ".data");

                }
            }
            DataManager.instance.pathCurrentPlayer = paths[0];
            return users[0];

        }
        else
        {
            Debug.LogError("Save file not found in: " + path_name);
            return null;
        }
    }
}