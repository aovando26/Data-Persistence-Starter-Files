using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    //public string playerName;
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
        bestPlayer = args;
    }

    [System.Serializable]
    class SaveData
    {
        public string bestPlayer;
        public int bestScore;
    }

    public void SaveBest()
    {
        SaveData data = new SaveData();

        data.bestPlayer = bestPlayer;
        data.bestScore = bestScore;

        // transform instance to JSON 
        string json = JsonUtility.ToJson(data);

        // write string to a file 
        File.WriteAllText(Application.persistentDataPath + "/savefile.json", json);
    }

    public void LoadBest()
    {
        string path = Application.persistentDataPath + "/savefile.json";
        if (File.Exists(path))
        {
            // read content 
            string json = File.ReadAllText(path);

            // transform it back into SaveData instance
            SaveData data = JsonUtility.FromJson<SaveData>(json);

            // set playerbest 
            bestPlayer = data.bestPlayer;
            bestScore = data.bestScore;
        }
    }
}
