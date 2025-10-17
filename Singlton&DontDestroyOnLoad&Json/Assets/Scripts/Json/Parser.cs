using System.Collections;
using System.Collections.Generic;
using System.IO;
using Newtonsoft.Json;
using UnityEditor.SceneManagement;
using UnityEngine;
using UnityEditor;
[System.Serializable]
public class Data
{
    public string Name { get; private set; }
    public string Description { get; private set; }

    public Data(string name, string description)
    {
        Name = name;
        Description = description;
    }
}

[System.Serializable]
public class DataBase
{
    public List<Data> DataInstances { get; private set; } = new List<Data>();
}

public static class CSVUtils
{
    private const string _resourcesFolderName = "Resources";
    private const string _csvFileName = "JsonConfig.csv";
    private const string _jsonFileName = "DataBase.txt";
    public static void ParseCSV(DataBase dataBase, string csvFileName, string jsonFileName)
    {
        //to csv
        string csvFilePath = Path.Combine(Application.dataPath, _resourcesFolderName,
            csvFileName);

        using (StreamWriter writer = new(csvFilePath))
        {
            writer.WriteLine("Name, Description");
            foreach(Data data in dataBase.DataInstances)
            {
                writer.WriteLine($"{data.Name},{data.Description}");
            }
            writer.Close();
        }

        //to json
        string jsonFilePath = Path.Combine(Application.dataPath, _resourcesFolderName,
            jsonFileName);
        string json = JsonConvert.SerializeObject(dataBase);
        using (StreamWriter writer = new(jsonFilePath))
        {
            writer.WriteLine(json);
            writer.Close();
        }
    }

    [MenuItem("Json Tools/Read and parse CSV")]
    public static void ReadCSV()
    {
        DataBase dataBase = new DataBase();

        string csvFilePath = Path.Combine(Application.dataPath, _resourcesFolderName,
            _csvFileName);

        if(!File.Exists(csvFilePath)) return;
        
        string[] lines = File.ReadAllLines(csvFilePath);
        for (int i = 0; i < lines.Length; i++)
        {
            string[] values = lines[i].Split(',');

            string name = values[0].Trim();
            string description = values[1].Trim();
            Data data = new(name, description);
            dataBase.DataInstances.Add(data);
        }

        string json = JsonConvert.SerializeObject(dataBase);
        string jsonFilePath = Path.Combine(Application.dataPath, _resourcesFolderName,
            _jsonFileName);
        File.WriteAllText(jsonFilePath, json);
    }
    [MenuItem("Json Tools/Read and debug JSON")]
    public static bool TryReadJson(out DataBase dataBase)
    {
        dataBase = new();
        string jsonFilePath = Path.Combine(Application.dataPath, _resourcesFolderName,
            _jsonFileName);

        if(!File.Exists(jsonFilePath)) return false; 

        string json = File.ReadAllText(jsonFilePath);
        dataBase = JsonConvert.DeserializeObject<DataBase>(json);

        foreach(Data data in dataBase.DataInstances)
        {
            Debug.Log($"{data.Name}: {data.Description}");
        }
        return true;
    }
}
