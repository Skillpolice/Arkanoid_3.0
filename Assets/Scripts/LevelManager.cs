using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
    public int blockCount;
    int index;

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
        }
    }

    public void WonLevel()
    {
        blockCount--;
    }

}
