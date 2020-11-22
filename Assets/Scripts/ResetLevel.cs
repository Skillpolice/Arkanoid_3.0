using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResetLevel : MonoBehaviour
{
    GameManager gameManager;
    Ball ball;

    public GameObject particalEffects;

    int lifeCount;

    private void Start()
    {
        gameManager = FindObjectOfType<GameManager>(); //нахождение других перенных - методов других скриптов
        ball = FindObjectOfType<Ball>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Ball")) //если тег совпадает с названием выполняем код ниже
        {
            //else ball life--
            gameManager.LoseLife();
            ball.RestartBall();
            Instantiate(particalEffects, transform.position, Quaternion.identity); //применяем эффекты к блокам и применяем их на позиции блоков
        }
        else
        {
            //если не мяч - уничтожаем обьект
            Destroy(collision.gameObject);
        }


    }


}
