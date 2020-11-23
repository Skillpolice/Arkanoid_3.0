﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    //Ссылка на обьект 
    public Rigidbody2D rb; // доступ к обьекту из unity // и перетаскиваем обьект (скрипт мяча) на обьект в Unity , что бы получить его же Rigidbody
    Pad pad; //ссылка(скрипт) на платформу, что бы мячь ездил вместе с платформой

    [HideInInspector]
    public bool isStarted;
    [HideInInspector]
    public bool IsMagnetActive;

    public float speedBall;
  
    float yPosition;
    float xDelta;


    private void Start()
    {
        pad = FindObjectOfType<Pad>();

        yPosition = transform.position.y;
        xDelta = transform.position.x - pad.transform.position.x; //прилипание мяча в позиции платформы

        if (pad.autoPlay)
        {
            StartBall();
        }
    }

    private void Update()
    {
        if (isStarted)
        {

        }
        else
        {
            //двигаться вместе с платформой
            Vector3 padPosition = pad.transform.position; //позиция платформы 
            Vector3 ballNewPosition = new Vector3(padPosition.x + xDelta, yPosition, 0); //новая позиция меча
            transform.position = ballNewPosition;

            if (Input.GetMouseButtonDown(0)) //нажатие мыши left для полета меча
            {
                StartBall();
            }
        }
    }

    public void StartBall() //
    {
        float randX = Random.Range(0, 0);
        Vector2 force = new Vector2(randX, 5).normalized * speedBall;
        rb.velocity = force;   //создаем дивежие меча по координатам через AddForce
        isStarted = true;
    }
    public void RestartBall()
    {
        isStarted = false;
        rb.velocity = Vector2.zero;
    }

    //public void MultiplySpeed(float speedKoef)
    //{
    //    speedBall *= speedKoef;
    //    rb.velocity = rb.velocity.normalized * speedBall;
    //}

    public void Duplicate()
    {
        Ball originalBall = this;
        Ball newBall =  Instantiate(originalBall);
        newBall.StartBall();

        if(IsMagnetActive)
        {
            newBall.ActiveteMagnet();
        }
    }

    public void ActiveteMagnet()
    {
        IsMagnetActive = true;
    }

    private void OnCollisionEnter2D(Collision2D collision) //Магнитизм мяча !!!
    {

        if (IsMagnetActive && collision.gameObject.CompareTag("Pad"))
        {
            yPosition = transform.position.y;
            xDelta = transform.position.x - pad.transform.position.x; //прилипание мяча в позиции платформы
            RestartBall();
        }
    }

}
