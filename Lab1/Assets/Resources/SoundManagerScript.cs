using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManagerScript : MonoBehaviour
{
    public static AudioClip jumpSound, deathSound;
    static AudioSource audioScr;
    private void Start()
    {
        jumpSound = Resources.Load<AudioClip>("Jump");
        deathSound = Resources.Load<AudioClip>("Death");

        audioScr = GetComponent<AudioSource>();
    }

    public static void Playsound(string clip)
    {
        switch (clip)
        {
            case "jump":
                audioScr.PlayOneShot(jumpSound);
                break;

            case "death":
                audioScr.PlayOneShot(deathSound);
                break;
        }
    }
}