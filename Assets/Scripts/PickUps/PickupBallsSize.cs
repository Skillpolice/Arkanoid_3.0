using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickupBallsSize : MonoBehaviour
{
    public float speedKoef;
    private void ApplyEffect()
    {
        Ball[] balls = FindObjectsOfType<Ball>();
        foreach (Ball ball in balls)
        {
            ball.MultiplySpeed(speedKoef);
            float randX = Random.Range(0.2f, 2f);
            ball.transform.localScale = new Vector3(randX, randX); //Изменение размера мяча
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
