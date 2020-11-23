using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickupMagnet : MonoBehaviour
{
    private void ApplyEffect()
    {
        Ball[] balls = FindObjectsOfType<Ball>();
        Pad pad = FindObjectOfType<Pad>();
        foreach (Ball item in balls)
        {
            item.ActiveteMagnet();
        }

        
        //ball.RestartBall();
        //float randX = Random.Range(0, 0);
        //Vector2 ballManget = new Vector2(randX, 5).normalized * ball.speedBall;
        //ball.rb.velocity = ballManget;

        //if (pad.autoPlay)
        //{
        //    ball.RestartBall();
        //    ball.StartBall();
        //}
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
