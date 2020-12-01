using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickupLife : MonoBehaviour
{
    [Header("GameObject")]
    public GameObject particalEffectsLifeUp;
    public GameObject particalEffectsLifDowne;
    public GameObject pickupPrefab;


    private void ApplyEffect()
    {
        GameManager gameManager = FindObjectOfType<GameManager>();
        bool boolValue = (Random.Range(0, 2) == 0);
        if (boolValue)
        {
            print(true);
            gameManager.LoseLife();
            Instantiate(particalEffectsLifDowne, transform.position, Quaternion.identity);          
        }
        else
        {
            print(false);
            gameManager.UpLife();
            Instantiate(particalEffectsLifeUp, transform.position, Quaternion.identity);          
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
