using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;

public class SavedData : MonoBehaviour
{
    public int torchCount;
    public float torchLife;
    public int butteryCount;
    public float butteryLife;

    void SaveGame()
    {
        BinaryFormatter bf = new BinaryFormatter();
        FileStream file = File.Create(Application.persistentDataPath
          + "/MySaveData.dat");
        SaveData data = new SaveData();
        data.savedTorchCount = torchCount;
        data.savedTorchLife = torchLife;
        data.savedButteryCount = butteryCount;
        data.savedButteryLife = butteryLife;
        bf.Serialize(file, data);
        file.Close();
        Debug.Log("Game data saved!");
    }
}
[Serializable]
class SaveData
{
    public int savedTorchCount;
    public float savedTorchLife;
    public int savedButteryCount;
    public float savedButteryLife;
}
