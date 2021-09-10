using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenuUIHandler : MonoBehaviour
{
    public InputField userInput;
    // Start is called before the first frame update
    void Start()
    {
     
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void StartGame() {
        //нужно получить имя и установить его
        Debug.Log(userInput.text);
        if (userInput.text != "") {
            Manager.Instance.setName(userInput.text);
        } else {
            Manager.Instance.setName("Noname");
        }
        SceneManager.LoadScene(1);
    }
    public void ExitGame() {
#if UNITY_EDITOR
        EditorApplication.ExitPlaymode();
#else
        Application.Quit(); // original code to quit Unity player
#endif
    }
}
