﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    AudioManager audioManager;

    [Header("Text")]
    public Text scoreText;
    public Text healthText;

    [Header("Pause - Game over")]
    public GameObject panelPause;
    public GameObject gameOver;

    [Header("Ball - Pad")]
    public Ball ball;
    public Pad pad;

    [Header("Count Life")]
    public int lifeCount;

    [Header("Sounds")]
    public AudioClip soundPauseActivate;
    public AudioClip soundPauseDeactivate;

    [HideInInspector]
    public bool isPauseActive;

    public static string keyBestSocre = "bestRecord";

    public int score;


    public void Awake() //для удаления GameManagera на разных сценах
    {
        audioManager = FindObjectOfType<AudioManager>();

        GameManager[] gameManagers = FindObjectsOfType<GameManager>();
        for (int i = 0; i < gameManagers.Length; i++)
        {
            if (gameManagers[i].gameObject != gameObject)
            {
                Destroy(gameObject);
                gameObject.SetActive(false);
                break;
            }
        }
    }

    public void Start()
    {
        scoreText.text = "Point: 000";
        DontDestroyOnLoad(gameObject);
    }

    private void Update()
    {
        PauseGame();
    }

    public void PauseGame()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (isPauseActive)
            {
                Time.timeScale = 1;
                isPauseActive = false;
                Cursor.visible = false;
                audioManager.PlaySound(soundPauseDeactivate);
            }
            else
            {
                Time.timeScale = 0;
                isPauseActive = true;
                Cursor.visible = true;
                audioManager.PlaySound(soundPauseActivate);
            }
            panelPause.SetActive(isPauseActive);
        }
    }
    

    public void AddScore(int addscore)
    {
        score += addscore;
        scoreText.text = "Point: " + score.ToString();

        //удалить после тестирования
        SaveBestScore();
    }
    public void SaveBestScore()
    {
        int oldBestScore = PlayerPrefs.GetInt(keyBestSocre); //проверяем старые очки
        if( score > oldBestScore)
        {
            PlayerPrefs.GetInt(keyBestSocre, score); //перезаписываем 
        }
    }

    public void LoseLife()
    {
        lifeCount--;
        healthText.text = "Health: " + lifeCount.ToString();

        if (lifeCount <= 0)
        {
            isPauseActive = true;
            gameOver.SetActive(true);
            Cursor.visible = true;

        }
        gameOver.SetActive(isPauseActive);
    }

    public void UpLife()
    {
        lifeCount++;
        healthText.text = "Health: " + lifeCount.ToString();
    }

    public void RestatLevel()
    {
        lifeCount = 3;
        score = 0;

        isPauseActive = false;
        gameOver.SetActive(false);

        int index = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(index);
        //DontDestroyOnLoad(gameObject);

        scoreText.text = "Point: 000";
        healthText.text = "Health: " + lifeCount.ToString();
    }

}
