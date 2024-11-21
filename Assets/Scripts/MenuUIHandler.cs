using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
#if UNITY_EDITOR
using UnityEditor;
#endif


public class MenuUIHandler : MonoBehaviour
{
    public Button startButton;
    public Button quitButton; 
    // Start is called before the first frame update
    void Start()
    {
        startButton.onClick.AddListener(LoadMainScene);
        quitButton.onClick.AddListener(Exit);
    }

    private void LoadMainScene()
    {
        SceneManager.LoadScene(1);
    }

    private void Exit()
    {
        #if UNITY_EDITOR
                EditorApplication.ExitPlaymode();
        #else 
        Application.Quit(); 

        #endif
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
