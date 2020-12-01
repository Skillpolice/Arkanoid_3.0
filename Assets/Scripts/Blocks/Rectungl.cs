using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rectungl : MonoBehaviour
{
    GameManager gameManager;
    LevelManager levelManager;
    SpriteRenderer spriteRenderer;
    AudioManager audioManager;

    public GameObject particalEffects;
    public GameObject pickupPrefab;
    public Sprite[] sprites;

    [Header("Sounds")]
    public AudioClip soundDestroyBlock;

    public float explosionRadius;
    bool isActive;
    bool isOnOff;

    [Tooltip("Кол-во очков")] public int points;
    [Tooltip("Кол-во жизней")] public int blockHealth;

    private void Start()
    {
        gameManager = FindObjectOfType<GameManager>(); //нати обьект у которого есть ссылка GameManager  и полжить в переменную gameMaanger
        levelManager = FindObjectOfType<LevelManager>();
        levelManager.BlockCreated();
        spriteRenderer = GetComponent<SpriteRenderer>();
        audioManager = FindObjectOfType<AudioManager>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        for (int i = 0; i < sprites.Length; i++)
        {
            spriteRenderer.sprite = sprites[i];
            i++;
        }

        if (isOnOff)
        {
            RectungleDestroyBlock();
        }
        else
        {
            RectungleBlockHealth();
        }
    }

    public void RectungleBlockHealth()
    {
        blockHealth--;
        if (blockHealth <= 0)
        {
            BlockDestroy();
        }
    }

    public void RectungleDestroyBlock()
    {
        BlockDestroy();
        if (isActive)
        {
            Explode();
        }
    }

    public void Explode()
    {
        int layerMask = LayerMask.GetMask("BlockRectungleBomb"); //Всё что  под LayerMask взрываем, кроме остальново (почти то же самое что искать по Тегу)
        Collider2D[] colliders = Physics2D.OverlapCircleAll(transform.position, explosionRadius, layerMask); //Найти у Collider2D коллайдера компонент с типом  Block
        foreach (Collider2D item in colliders)
        {
            Rectungl block = item.GetComponent<Rectungl>();
            if (block == null)
            {
                print("NULL");
                //обьект без скрипта - уничтожить
                Destroy(item.gameObject);
            }
            else
            {
                //обькт со скриптом
                block.RectungleDestroyBlock();
                print("SCRIPT");
            }
        }
    }

    private void BlockDestroy()
    {
        audioManager.PlaySound(soundDestroyBlock);
        gameManager.AddScore(points);
        levelManager.DestroyBlock();
        Destroy(gameObject);

        Instantiate(particalEffects, transform.position, Quaternion.identity);
        Instantiate(pickupPrefab, transform.position, Quaternion.identity);

    }
}
