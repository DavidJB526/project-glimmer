using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Audio : MonoBehaviour
{
    public AudioClip swordSlamDown;
    public AudioClip swordSlamWindUp;
    public AudioClip shieldOpen;
    public AudioClip shieldLoop;
    public AudioClip shieldClose;

    public AudioSource audioSource;

    
    void SwordSlamDownSound()
    {
        audioSource.PlayOneShot(swordSlamDown);
    }

    void SwordSlamWindUpSound()
    {
        audioSource.PlayOneShot(swordSlamWindUp);
    }

    void ShieldOpenSound()
    {
        audioSource.PlayOneShot(shieldOpen);
    }

    void ShieldLoopSound()
    {
        audioSource.PlayOneShot(shieldClose);
    }

    void ShieldCloseSound()
    {
        audioSource.PlayOneShot(shieldClose);
    }
}
