using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rectungl : MonoBehaviour
{
    Blocks blocks;
    GameManager gameManager;
    LevelManager levelManager;
    SpriteRenderer spriteRenderer;

    public GameObject particalEffects;
    public GameObject pickupPrefab;
    public Sprite[] sprites;

    [Tooltip("Кол-во очков")] public int points;
    [Tooltip("Кол-во жизней")] public int blockHealth;

    private void Start()
    {
        blocks = FindObjectOfType<Blocks>();
        gameManager = FindObjectOfType<GameManager>(); //нати обьект у которого есть ссылка GameManager  и полжить в переменную gameMaanger
        levelManager = FindObjectOfType<LevelManager>();
        levelManager.BlockCreated();
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {

        blockHealth--;
        for (int i = 0; i < sprites.Length; i++)
        {
            spriteRenderer.sprite = sprites[i];
            i++;
        }
        
        if (blockHealth <= 0)
        {
            
            gameManager.AddScore(points);
            levelManager.DestroyBlock();
            Destroy(gameObject);

            Instantiate(particalEffects, transform.position, Quaternion.identity);
            Instantiate(pickupPrefab, transform.position, Quaternion.identity);
        }

    }
}
