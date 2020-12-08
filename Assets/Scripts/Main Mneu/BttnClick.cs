using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BttnClick : MonoBehaviour
{
    public AudioSource audioSource;
    public AudioClip targetSound;
    public AudioClip clickSound;

    public void HoverSound()
    {
        audioSource.PlayOneShot(targetSound);
    }
    public void ClickSound()
    {
        audioSource.PlayOneShot(clickSound);
    }
}
