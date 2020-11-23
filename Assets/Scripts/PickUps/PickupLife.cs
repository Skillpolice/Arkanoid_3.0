using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickupLife : MonoBehaviour
{
    private void ApplyEffect()
    {
        GameManager gameManager = FindObjectOfType<GameManager>();

        //int randLife = Random.Range(0, 1);
        bool boolValue = (Random.Range(0, 2) == 0);
        if (boolValue)
        {
            print(true);
            gameManager.LoseLife();
        }
        else
        {
            print(false);
            gameManager.UpLife();
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
