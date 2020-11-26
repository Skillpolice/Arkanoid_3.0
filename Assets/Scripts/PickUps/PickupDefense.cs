using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickupDefense : MonoBehaviour
{

    LevelManager levelManager;
  
    public void ApplyEffect()
    {
        levelManager = FindObjectOfType<LevelManager>();
        levelManager.defenseButtom.SetActive(true);

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
