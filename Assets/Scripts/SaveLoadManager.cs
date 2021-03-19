using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

public class SaveLoadManager : MonoBehaviour
{
    public InventoryBag inventoryBag;
    public InventoryItem item1;
    public InventoryItem item2;
    public void SaveGame() {
        Debug.Log(Application.persistentDataPath);
        if (!Directory.Exists(Application.persistentDataPath + "/SaveData")) {
            Directory.CreateDirectory(Application.persistentDataPath + "/SaveData");
        }
        BinaryFormatter formatter = new BinaryFormatter();
        FileStream file1 = File.Create(Application.persistentDataPath + "/SaveData/inventoryBag.bin");
        FileStream file2 = File.Create(Application.persistentDataPath + "/SaveData/item1.bin");
        FileStream file3 = File.Create(Application.persistentDataPath + "/SaveData/item2.bin");
        string json1 = JsonUtility.ToJson(inventoryBag);
        string json2 = JsonUtility.ToJson(item1);
        string json3 = JsonUtility.ToJson(item2);
        formatter.Serialize(file1, json1);
        formatter.Serialize(file2, json2);
        formatter.Serialize(file3, json3);
        file1.Close();
        file2.Close();
        file3.Close();
    }
    public void LoadGame() {
        BinaryFormatter formatter = new BinaryFormatter();
        if(File.Exists(Application.persistentDataPath + "/SaveData/inventoryBag.bin")) {
            FileStream file = File.Open(Application.persistentDataPath + "/SaveData/inventoryBag.bin", FileMode.Open);
            JsonUtility.FromJsonOverwrite((string)formatter.Deserialize(file), inventoryBag);
            file.Close();
        }
        if (File.Exists(Application.persistentDataPath + "/SaveData/item1.bin")) {
            FileStream file = File.Open(Application.persistentDataPath + "/SaveData/item1.bin", FileMode.Open);
            JsonUtility.FromJsonOverwrite((string)formatter.Deserialize(file), item1);
            file.Close();
        }
        if (File.Exists(Application.persistentDataPath + "/SaveData/item2.bin")) {
            FileStream file = File.Open(Application.persistentDataPath + "/SaveData/item2.bin", FileMode.Open);
            JsonUtility.FromJsonOverwrite((string)formatter.Deserialize(file), item2);
            file.Close();
        }
        InventoryManager.UpdateGUI();
    }
}
