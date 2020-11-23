using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AutoPlayTest : MonoBehaviour
{
    GameManager gameManager;
    Pad pad;

    void Start()
    {
        gameManager = FindObjectOfType<GameManager>();
        pad = FindObjectOfType<Pad>();
    }
    public void SpeedTestX1()
    {
        if (gameManager.isPauseActive)
        {
            Time.timeScale = 1;
            IsPause();
        }
        gameManager.panelPause.SetActive(gameManager.isPauseActive); //проверяет в каком состоянии находится пауза TRUE / FALSE
    }
    public void SpeedTestX2()
    {
        if (gameManager.isPauseActive)
        {
            Time.timeScale = 2;
            IsPause();
        }
        gameManager.panelPause.SetActive(gameManager.isPauseActive); //проверяет в каком состоянии находится пауза TRUE / FALSE
    }

    public void SpeedTestX3()
    {
        if (gameManager.isPauseActive)
        {
            Time.timeScale = 3;
            IsPause();
        }
        gameManager.panelPause.SetActive(gameManager.isPauseActive); //проверяет в каком состоянии находится пауза TRUE / FALSE
    }
    public void SpeedTestX4()
    {
        if (gameManager.isPauseActive)
        {
            Time.timeScale = 4;
            IsPause();
        }
        gameManager.panelPause.SetActive(gameManager.isPauseActive); //проверяет в каком состоянии находится пауза TRUE / FALSE
    }

    private void IsPause()
    {
        pad.autoPlay = true;
        gameManager.isPauseActive = false;
        gameManager.PauseGame();
        Cursor.visible = false;
    }

    public void AutoPlayCheck()
    {
        if (gameManager.isPauseActive)
        {
            Time.timeScale = 1;
            pad.autoPlay = false;
            gameManager.isPauseActive = false;
            gameManager.PauseGame();
            Cursor.visible = false;

        }

        gameManager.panelPause.SetActive(gameManager.isPauseActive);
    }
}
