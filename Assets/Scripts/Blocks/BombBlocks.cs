using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BombBlocks : MonoBehaviour
{
    public bool isActiveBomb;
    public float explosionRadius;

    GameManager gameManager;
    LevelManager levelManager;

    [Header("Points")]
    public int points;

    [Header("GameObject")]
    public GameObject particalEffects;

    private void Start()
    {
        gameManager = FindObjectOfType<GameManager>();
        levelManager = FindObjectOfType<LevelManager>();
        levelManager.BlockCreated();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        DestroyBlock();
    }

    public void DestroyBlock()
    {
        gameManager.AddScore(points);
        levelManager.DestroyBlock();
        Destroy(gameObject);

        Instantiate(particalEffects, transform.position, Quaternion.identity);

        if (isActiveBomb)
        {
            //блок взырвной - логика взрыва
            Explode();
        }
    }

    public void Explode()
    {
        if(isActiveBomb)
        {
            int layerMask = LayerMask.GetMask("BombBlocks"); //Всё что  под LayerMask взрываем, кроме остальново (почти то же самое что искать по Тегу)
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
        
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawWireSphere(transform.position, explosionRadius);
    }
}
