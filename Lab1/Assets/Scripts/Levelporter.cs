using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Levelporter : MonoBehaviour
{
    public string level;
    public void OnTriggerEnter2D(Collider2D collision)
    {
        SceneManager.LoadScene(level);
    }
}
