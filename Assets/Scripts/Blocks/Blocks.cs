using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Blocks : MonoBehaviour
{
    GameManager gameManager;
    LevelManager levelManager;

    [Header("Points")]
    public int points;

    [Header("Radius")]
    public bool explosive; //Взрывной блок
    public bool explosionRadius; //радиус взрыва

    [Header("GameObject")]
    public GameObject particalEffects;
    public GameObject pickupPrefab;
   

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
        Instantiate(pickupPrefab, transform.position, Quaternion.identity); //создать обьект на основе прифаба
        
    }
}
