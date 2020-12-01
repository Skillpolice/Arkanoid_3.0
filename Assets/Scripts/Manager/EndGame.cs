using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class EndGame : MonoBehaviour
{
    public Text resulText;
    public GameManager gameManager;

    private void Start()
    {
        gameManager = FindObjectOfType<GameManager>();
        resulText.text = "Life: " + gameManager.lifeCount + "   /  Score: " + gameManager.score;
    }

   public void RestartGame()
    {
        SceneManager.LoadScene(0);
    }
}
