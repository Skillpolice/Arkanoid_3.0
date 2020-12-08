using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PickupDefense : MonoBehaviour
{
    LevelManager levelManager;
    AudioManager audioManager;

    [Header("Audio")]
    public AudioClip defenseSound;

    public int defenseLife = 2;
    bool isActiveDefense;


    public void ApplyEffect()
    {
        levelManager = FindObjectOfType<LevelManager>();
        audioManager = FindObjectOfType<AudioManager>();
        levelManager.DefActive();
        audioManager.PlaySound(defenseSound);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Pad"))
        {
            //TODO применение эффекта
            //вызов функции 

            ApplyEffect();
            Destroy(gameObject);
        }
    }
}
