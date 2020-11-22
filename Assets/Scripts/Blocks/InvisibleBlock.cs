using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InvisibleBlock : MonoBehaviour
{
    GameManager gameManager;
    LevelManager levelManager;

    public SpriteRenderer spriteRenderer;

    public int points;
    public int blockHealth;
    public int invisBlockStrike;

    private void Start()
    {
        gameManager = FindObjectOfType<GameManager>();
        spriteRenderer = GetComponent<SpriteRenderer>(); // GetComponent - ищет компонент на котором весит скрипт обьекта
        levelManager = FindObjectOfType<LevelManager>();
        levelManager.BlockCreated();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        invisBlockStrike--;
        if(invisBlockStrike == 1)
        {
            spriteRenderer.enabled = !spriteRenderer.enabled;
        }

        blockHealth--;
        if(blockHealth <= 0)
        {
            gameManager.AddScore(points);
            levelManager.DestroyBlock();
            Destroy(gameObject);
        }
    }

}
