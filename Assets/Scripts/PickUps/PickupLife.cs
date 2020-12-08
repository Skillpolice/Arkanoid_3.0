using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickupLife : MonoBehaviour
{
    AudioManager audioManager;

    [Header("GameObject")]
    public GameObject particalEffectsLifeUp;
    public GameObject particalEffectsLifDown;

    [Header("Audio")]
    public AudioClip lifeUp;
    public AudioClip lifeDown;

    private void ApplyEffect()
    {
        GameManager gameManager = FindObjectOfType<GameManager>();
        audioManager = FindObjectOfType<AudioManager>();

        bool boolValue = (Random.Range(0, 2) == 0);
        if (boolValue)
        {
            print(true);
            gameManager.LoseLife();
            Instantiate(particalEffectsLifDown, transform.position, Quaternion.identity);
            audioManager.PlaySound(lifeDown);
        }
        else
        {
            print(false);
            gameManager.UpLife();
            Instantiate(particalEffectsLifeUp, transform.position, Quaternion.identity);
            audioManager.PlaySound(lifeUp);
        }

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
