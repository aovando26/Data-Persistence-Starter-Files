using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;


#if UNITY_EDITOR
using UnityEditor;
#endif


public class MenuUIHandler : MonoBehaviour
{
    public Button startButton;
    public Button quitButton;
    public TMP_InputField nameInputField;
    public TextMeshProUGUI placeHolderText; 

    // Start is called before the first frame update
    void Start()
    {
        startButton.onClick.AddListener(LoadMainScene);
        quitButton.onClick.AddListener(Exit);

        // listener
        nameInputField.onEndEdit.AddListener(GameManager.Instance.SubmitName);
    }

    private void LoadMainScene()
    {
        if (string.IsNullOrWhiteSpace(nameInputField.text))
        {
            Debug.Log("Please enter your name");
            // change and and font to bold
            placeHolderText.color = Color.red;

            // FontStyles is an enum,(0,1,2...) 
            // the | operator mergers the styles so that both bold and italic are applied
            placeHolderText.fontStyle = FontStyles.Bold | FontStyles.Italic;

        }
        else
        {
            SceneManager.LoadScene(1);
        }
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
