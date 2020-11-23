using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AutoPlayTest : MonoBehaviour
{

    GameManager gameManager;
    Ball ball;
    Pad pad;


    void Start()
    {
        gameManager = FindObjectOfType<GameManager>();
        ball = FindObjectOfType<Ball>();
        pad = FindObjectOfType<Pad>();
    }

    public void SpeedTestX1()
    {

    }

   
}
