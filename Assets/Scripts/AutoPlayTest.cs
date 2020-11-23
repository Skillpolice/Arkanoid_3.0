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
        if (gameManager.isPauseActive)
        {
            Time.timeScale = 1;
            pad.autoPlay = true;
            gameManager.isPauseActive = false;
            gameManager.PauseGame();
        }
        gameManager.panelPause.SetActive(gameManager.isPauseActive); //проверяет в каком состоянии находится пауза TRUE / FALSE
    }
    public void SpeedTestX2()
    {
        if(gameManager.isPauseActive)
        {
            Time.timeScale = 2;
            pad.autoPlay = true;
            gameManager.isPauseActive = false;
            gameManager.PauseGame();
        }
        gameManager.panelPause.SetActive(gameManager.isPauseActive); //проверяет в каком состоянии находится пауза TRUE / FALSE
    }

    public void SpeedTestX3()
    {
        if (gameManager.isPauseActive)
        {
            Time.timeScale = 3;
            pad.autoPlay = true;
            gameManager.isPauseActive = false;
            gameManager.PauseGame();
        }
        gameManager.panelPause.SetActive(gameManager.isPauseActive); //проверяет в каком состоянии находится пауза TRUE / FALSE
    }
}
