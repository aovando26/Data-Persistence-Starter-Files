using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    // starting player - current
    public string playerName;
    public int score; 

    // high score user info 
    public string bestPlayer;
    public int bestScore; 

    private void Awake()
    {
        if (Instance != null)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;

        DontDestroyOnLoad(gameObject);
    }

    // Start is called before the first frame update
    void Start()
    {
        LoadBest();
    }

    // Update is called once per frame
    void Update()
    {

    }
    public void SubmitName(string args)
    {
        playerName = args;
    }

    [System.Serializable]
    class SaveData
    {
        public string bestPlayer;
        public int bestScore;
    }

    public void SaveBest(string playerName, int score)
    {
        SaveData data = new SaveData();

        data.bestPlayer = playerName;
        data.bestScore = score;

        // transform instance to JSON 
        string json = JsonUtility.ToJson(data);

        // write string to a file 
        try
        {
            File.WriteAllText(Application.persistentDataPath + "/savefile.json", json);
        }
        catch (Exception e)
        {
            Debug.LogError($"Failed to save data: {e.Message}");
        }
    }

    public void LoadBest()
    {
        string path = Application.persistentDataPath + "/savefile.json";
        if (File.Exists(path))
        {
            // READ CONTENT
            string json = File.ReadAllText(path);

            // transform it back into SaveData instance
            SaveData data = JsonUtility.FromJson<SaveData>(json);

            // set playerbest 
            bestPlayer = data.bestPlayer;
            bestScore = data.bestScore;
        }
        else
        {
            Debug.LogWarning("Unable to locate file");
        }
    }
}