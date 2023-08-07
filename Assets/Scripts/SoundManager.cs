using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public static AudioClip cutSound, enemySound, fluffySound, stuckSound, gameOverSound, biteSound;
    static AudioSource audioSource;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();

        cutSound = Resources.Load<AudioClip>("Cut");
        enemySound = Resources.Load<AudioClip>("Enemy");
        fluffySound = Resources.Load<AudioClip>("Fluffy");
        stuckSound = Resources.Load<AudioClip>("Stuck");
        gameOverSound = Resources.Load<AudioClip>("GameOver");
        biteSound = Resources.Load<AudioClip>("Bite");
    }

    public static void PlaySound (string clip)
    {
        switch (clip)
        {
            case "Cut": audioSource.PlayOneShot(cutSound);
                break;
            case "Enemy":
                audioSource.PlayOneShot(enemySound);
                break;
            case "Fluffy":
                audioSource.PlayOneShot(fluffySound);
                break;
            case "Stuck":
                audioSource.PlayOneShot(stuckSound);
                break;
            case "GameOver":
                audioSource.PlayOneShot(gameOverSound);
                break;
            case "Bite":
                audioSource.PlayOneShot(biteSound);
                break;
        }
    }
}
