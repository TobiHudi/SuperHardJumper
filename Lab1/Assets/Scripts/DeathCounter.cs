using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DeathCounter : MonoBehaviour
{

    
    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("Dead");
    }
}
