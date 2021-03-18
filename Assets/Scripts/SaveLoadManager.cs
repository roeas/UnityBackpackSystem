using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

public class SaveLoadManager : MonoBehaviour
{
    public InventoryBag InventoryBag;
    public void SaveGame() {
        Debug.Log(Application.persistentDataPath);
        if (!Directory.Exists(Application.persistentDataPath + "/SaveData")) {
            Directory.CreateDirectory(Application.persistentDataPath + "/SaveData");
        }
        BinaryFormatter formatter = new BinaryFormatter();
        FileStream file = File.Create((Application.persistentDataPath + "/SaveData/inventoryBag.bin"));
        string json = JsonUtility.ToJson(InventoryBag);
        formatter.Serialize(file, json);
        file.Close();
    }
    public void LoadGame() {
        BinaryFormatter formatter = new BinaryFormatter();
        if(File.Exists(Application.persistentDataPath + "/SaveData/inventoryBag.bin")) {
            FileStream file = File.Open(Application.persistentDataPath + "/SaveData/inventoryBag.bin", FileMode.Open);
            JsonUtility.FromJsonOverwrite((string)formatter.Deserialize(file), InventoryBag);
            file.Close();
        }
    }
}
