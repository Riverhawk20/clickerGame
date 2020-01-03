using UnityEngine;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

public static class SaveSystem 
{
    public static void SaveMoney (Money money){
        BinaryFormatter formatter= new BinaryFormatter();
        string path = Path.Combine(Application.persistentDataPath, "save.data");
        FileStream stream = new FileStream(path, FileMode.Create);

        SaveData data = new SaveData(money);

        formatter.Serialize(stream, data);
        stream.Close();
    }

    public static SaveData LoadData (){
        string path = Path.Combine(Application.persistentDataPath, "save.data");
        if(File.Exists(path)){
            BinaryFormatter formatter = new BinaryFormatter();
            FileStream stream = new FileStream(path, FileMode.Open);
            SaveData data = formatter.Deserialize(stream) as SaveData;
            stream.Close();
            return data;
        }
        else{
            Debug.LogError("Save File not found in " + path);
            return null;
        }
    }
}
