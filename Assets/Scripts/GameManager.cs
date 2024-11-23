using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    public string playerName;

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

    }

    // Update is called once per frame
    void Update()
    {

    }
    public void SubmitName(string args)
    {
        playerName = args;
        //Debug.Log(playerName);
    }

    //[System.Serializable]
    //class SaveData
    //{
    //    public string playerName { get; private set; }
    //}

    //public void SaveName()
    //{
    //    SaveData data = new SaveData();

    //    data.playerName = playerName;

    //    // transform instance to JSON
    //    string json = JsonUtility.ToJson(data);

    //    // write string to a file
    //    File.WriteAllText(Application.persistentDataPath + "/savefile.json", json);
    //}

    //// reversal of the SaveColor method
    //public void LoadName()
    //{
    //    string path = Application.persistentDataPath + "/savefile.json";
    //    if (File.Exists(path))
    //    {
    //        // read its content
    //        string json = File.ReadAllText(path);

    //        // transform it back into SaveData instance 
    //        SaveData data = JsonUtility.FromJson<SaveData>(json);

    //        // set player name
    //        data.playerName = playerName;
    //    }
    //}
}
