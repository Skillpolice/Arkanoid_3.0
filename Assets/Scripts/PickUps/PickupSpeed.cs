using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickupSpeed : MonoBehaviour
{
    public float speedKoef;

    private void ApplyEffect()
    {
        Ball ball = FindObjectOfType<Ball>();

        ball.speedBall = Random.Range(6, 15);
        ball.StartBall();

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
