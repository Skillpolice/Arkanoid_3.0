﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InvisibleBlock : MonoBehaviour
{
    GameManager gameManager;
    LevelManager levelManager;

    public SpriteRenderer spriteRenderer;
    public Sprite[] sprites;

    [Header("GameObject")]
    public GameObject particalEffects;
    public GameObject pickupPrefab;
    public GameObject pickupEffectActive;
    
    public int points;
    public int blockHealth;
    public int invisBlockStrike;

    private void Start()
    {
        gameManager = FindObjectOfType<GameManager>();
        spriteRenderer = GetComponent<SpriteRenderer>(); // GetComponent - ищет компонент на котором весит скрипт обьекта
        levelManager = FindObjectOfType<LevelManager>();
        levelManager.BlockCreated();
        spriteRenderer.GetComponent<SpriteRenderer>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        
        invisBlockStrike--;
        if(invisBlockStrike == 2)
        {
            spriteRenderer.enabled = !spriteRenderer.enabled;
        }
        if(invisBlockStrike == 1)
        {
            pickupEffectActive.SetActive(true);
            for (int i = 0; i < sprites.Length; i++)
            {
                spriteRenderer.sprite = sprites[i];
                i++;
            }
        }
       

        blockHealth--;
        if(blockHealth <= 0)
        {
            gameManager.AddScore(points);
            levelManager.DestroyBlock();
            Destroy(gameObject);
            Instantiate(particalEffects, transform.position, Quaternion.identity);
            Instantiate(pickupPrefab, transform.position, Quaternion.identity); //создать обьект на основе прифаба
        }

    }

}
