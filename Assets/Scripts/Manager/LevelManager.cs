using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
    public GameObject defenseButtom;

    public int blockCount;
    int index;

    public void DefActive()
    {
        defenseButtom.SetActive(true);
        StartCoroutine(TimeDestroyDefense(5));
    }

    public void BlockCreated() //считает кол-во блоков и выводит их на экран
    {
        blockCount++;
    }

    public void DestroyBlock() //Удаляет блоки и переводит на след. сцену
    {
        blockCount--;
        if (blockCount <= 0)
        {
            index = SceneManager.GetActiveScene().buildIndex;
            SceneManager.LoadScene(index + 1);

            GameManager gameManager = FindObjectOfType<GameManager>();
            gameManager.SaveBestScore();
        }
    }

    public void WonLevel()
    {
        blockCount--;
    }
    IEnumerator TimeDestroyDefense(int wall)
    {
        print("Active");
        yield return new WaitForSeconds(wall);
        defenseButtom.SetActive(false);
        print("Destroy");
    }
}
