using UnityEngine;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

public static class SaveSystem
{
    public static int saveNumber = 1;

    public static void Save(Player player)
    {
        BinaryFormatter formatter = new BinaryFormatter();
        string path = SavePath(saveNumber);
        FileStream stream = new FileStream(path, FileMode.Create);

        SaveData data = new SaveData(player);

        formatter.Serialize(stream, data);
        stream.Close();
    }

    public static SaveData Load()
    {
        bool exists = false;
        string path = SavePath(saveNumber, out exists);
        if (exists)
        {
            BinaryFormatter formatter = new BinaryFormatter();
            FileStream stream = new FileStream(path, FileMode.Open);

            SaveData data = formatter.Deserialize(stream) as SaveData;
            stream.Close();

            return data;
        }
        else
        {
            Debug.LogError("Savefile not found in " + path);
            return null;
        }
    }

    public static string SavePath(int indexSave, out bool exists)
    {
        string path = Application.persistentDataPath + "/save" + indexSave + ".gif";
        exists = File.Exists(path);
        return path;
    }
    public static string SavePath(int indexSave)
    {
        string path = Application.persistentDataPath + "/save" + indexSave + ".gif";
        return path;
    }
}
