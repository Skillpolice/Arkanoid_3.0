using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Blocks : MonoBehaviour
{
    GameManager gameManager;
    LevelManager levelManager;
    AudioSource audioManager;

    [Header("Sounds")]
    public AudioClip soundDestroyBlock;

    [Header("Points")]
    public int points;

    [Header("Radius")]
    public bool explosive; //Взрывной блок
    public float explosionRadius; //радиус взрыва

    [Header("GameObject")]
    public GameObject particalEffects;
    public GameObject pickupPrefab;

    private void Start()
    {
        gameManager = FindObjectOfType<GameManager>();
        levelManager = FindObjectOfType<LevelManager>();
        audioManager = FindObjectOfType<AudioSource>();
        levelManager.BlockCreated();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
       audioManager.Play(); //Воспроизводит звук при коллизии
        DestroyBlock();
    }

    public void DestroyBlock()
    {
        gameManager.AddScore(points);
        levelManager.DestroyBlock();
        Destroy(gameObject);

        Instantiate(particalEffects, transform.position, Quaternion.identity);
        Instantiate(pickupPrefab, transform.position, Quaternion.identity); //создать обьект на основе прифаба

        if (explosive)
        {
            //блок взырвной - логика взрыва
            Explode();
        }
    }

    public void Explode()
    {
        int layerMask = LayerMask.GetMask("Block"); //Всё что  под LayerMask взрываем, кроме остальново (почти то же самое что искать по Тегу)
        Collider2D[] colliders = Physics2D.OverlapCircleAll(transform.position, explosionRadius, layerMask); //Найти у Collider2D коллайдера компонент с типом  Block
        foreach (Collider2D item in colliders)
        {
            Blocks block = item.GetComponent<Blocks>();
            if (block == null)
            {
                //обьект без скрипта - уничтожить
                Destroy(item.gameObject);
            }
            else
            {
                //обькт со скриптом
                block.DestroyBlock();

            }
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, explosionRadius);
    }

}
