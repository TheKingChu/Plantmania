using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class SaveSystem : MonoBehaviour
{
    //creation of files
    public string saveName = "SaveData_";
    [Range(0, 10)]
    public int saveDataIndex = 0;

    public void SaveData(string dataToSave)
    {
        if(WriteToFile(saveName + saveDataIndex, dataToSave))
        {
            Debug.Log("Successfully saved the data");
        }
    }

    public string LoadData()
    {
        string data = "";

        if(ReadFromFile(saveName + saveDataIndex, out data))
        {
            Debug.Log("Successfully loaded the data");
        }

        return data;
    }

    private bool WriteToFile(string fileName, string content)
    {
        var fullPath = Path.Combine(Application.persistentDataPath, fileName);

        try
        {
            File.WriteAllText(fullPath, content);
            return true;
        }
        catch (Exception exepction)
        {
            Debug.LogError("Error saving to a file" + exepction.Message);
        }

        return false;
    }

    private bool ReadFromFile(string fileName, out string content)
    {
        var fullPath = Path.Combine(Application.persistentDataPath, fileName);

        try
        {
            content = File.ReadAllText(fullPath);
            return true;
        }
        catch (Exception execption)
        {
            Debug.LogError("Error when loading the data from file" + execption.Message);
            content = "";
        }

        return false;
    }
}
