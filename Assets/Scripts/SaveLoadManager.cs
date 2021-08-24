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

    private string PATH;
    private void Awake() {
        PATH = Application.persistentDataPath;
    }
    public void SaveGame() {
        //在bottom中被调用
        Debug.Log(PATH);
        if (!Directory.Exists(PATH + "/SaveData")) {
            Directory.CreateDirectory(PATH + "/SaveData");
        }

        SaveData(inventoryBag, nameof(inventoryBag));
        SaveData(item1, nameof(item1));
        SaveData(item2, nameof(item2));
    }
    private void SaveData<T>(T so, string name) {
        BinaryFormatter formatter = new BinaryFormatter();
        FileStream file = File.Create(PATH + "/SaveData/" + name + ".bin");
        string json = JsonUtility.ToJson(so);
        formatter.Serialize(file, json);
        file.Close();
    }
    public void LoadGame() {
        //在bottom中被调用
        LodData(inventoryBag, nameof(inventoryBag));
        LodData(item1, nameof(item1));
        LodData(item2, nameof(item2));

        InventoryManager.UpdateGUI();
    }
    private void LodData<T>(T so, string name) {
        BinaryFormatter formatter = new BinaryFormatter();
        if (File.Exists(PATH + "/SaveData/" + name + ".bin")) {
            FileStream file = File.Open(PATH + "/SaveData/" + name + ".bin", FileMode.Open);
            string json = (string)formatter.Deserialize(file);
            JsonUtility.FromJsonOverwrite(json, so);
            file.Close();
        }
    }
}
