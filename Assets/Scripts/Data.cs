using UnityEngine;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;

//Clasa in care sunt incarcate datele salvate\\
[System.Serializable]
public class Data
{
    public static Data saved = new Data();

    public int uridium;
    public int credits;
    public int greenKeys;

    //Salveaza toate variabilile in fisierul "game_data.save"\\
    public static void Save()
    {
        SaveLoad.Save();
    }

    //Incarca toate variabilile in fisierul "game_data.save"\\
    public static void Load()
    {
        SaveLoad.Load();
    }
}

public static class SaveLoad
{

    public static void Save()
    {
        BinaryFormatter bf = new BinaryFormatter();
        FileStream file = File.Create(Application.persistentDataPath + "/game_data.save");
        bf.Serialize(file, Data.saved);
        file.Close();
    }

    public static void Load()
    {
        if (File.Exists(Application.persistentDataPath + "/game_data.save"))
        {
            BinaryFormatter bf = new BinaryFormatter();
            FileStream file = File.Open(Application.persistentDataPath + "/game_data.save", FileMode.Open);
            Data.saved = (Data)bf.Deserialize(file);
            file.Close();
        }
    }
}