using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpikeLogic : MonoBehaviour
{

    [SerializeField] public Transform Player;
    [SerializeField] public Transform respawn;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        Player.transform.position = respawn.transform.position;
        SoundManagerScript.Playsound("death");
        DeathIncrease.scorevalue += 001;
    }
}
