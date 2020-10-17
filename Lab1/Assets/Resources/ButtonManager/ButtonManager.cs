using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonManager : MonoBehaviour
{

    public AudioSource audioButtonSrc;
    public AudioClip buttonClick;

    public void ButtonPlaySoundClick()
    {
        audioButtonSrc.PlayOneShot(buttonClick);
    }

    public void ButtonMoveScene(string level)
    {
        SceneManager.LoadScene(level);
    }

    public void Quit()
    {
        Debug.Log("LEFT THE GAME");
        Application.Quit();
    }
}
