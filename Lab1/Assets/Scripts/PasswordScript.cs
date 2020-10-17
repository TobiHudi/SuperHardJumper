using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PasswordScript : MonoBehaviour
{
    [SerializeField]
    public InputField mainInputField;
    public string myText;

    public void SendPassword()
    {
        myText = mainInputField.text;
        if (myText == "vorarlberg")
        {
            Debug.Log("Correct!!!");
            SceneManager.LoadScene("SkinChanger");
        }
        else
        {
            Debug.Log("Wrong");
        }
    }
    private void Update()
    {
        
    }
}
