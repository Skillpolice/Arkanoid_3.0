using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
    public GameObject defenseButtom;
    public PolygonCollider2D defButtom;
    public SpriteRenderer sprButtom;


    public int blockCount;
    int index;
    int def = 1;

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
        print("12");
        yield return new WaitForSeconds(wall);
        defenseButtom.SetActive(false);
        print("345");
    }
}
