using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PickupDefense : MonoBehaviour
{
    LevelManager levelManager;

    public int defenseLife;

    public float timer, coolDown;


    private void Update()
    {
        if (timer > 0)
        {
            timer -= Time.deltaTime;
        }
        if (timer <= 0)
        {
            print("END");
            timer = coolDown;
        }

    }
    public void ApplyEffect()
    {
        levelManager = FindObjectOfType<LevelManager>();
        defenseLife--;
        if (defenseLife <= 0)
        {
            levelManager.defenseButtom.SetActive(true);
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
