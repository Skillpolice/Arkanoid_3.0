﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickupMultpleBall : MonoBehaviour
{
    private void ApplyEffect()
    {
        Ball[] balls = FindObjectsOfType<Ball>();
        foreach (Ball ball in balls)
        {
            ball.Duplicate();
        }

        

        //Instantiate(ball); //Instantiate - Создание нового обьекта
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
