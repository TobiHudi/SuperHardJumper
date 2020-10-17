using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DeathIncrease : MonoBehaviour
{
    public static int scorevalue = 000;
    Text deathcount;

    // Start is called before the first frame update
    void Start()
    {
        deathcount = GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        deathcount.text = "Deathcount: " + scorevalue;
    }
}
