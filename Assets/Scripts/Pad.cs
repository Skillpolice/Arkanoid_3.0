using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pad : MonoBehaviour
{
    Ball ball;
    GameManager gameManager;

    public bool autoPlay;
    public float maxX;

    float yPosition;


    void Start()
    {
        ball = FindObjectOfType<Ball>();
        gameManager = FindObjectOfType<GameManager>();

        yPosition = transform.position.y; // 3апоминаем позицию для платформы по Y
        Cursor.visible = false;
    }


    public void Update()
    {

        if (gameManager.isPauseActive)
        {
            //пауза активна - ничего не нужно делать
            return;
        }

        Vector3 padNewPosition;
        if (autoPlay)
        {
            Vector3 ballPos = ball.transform.position; //позиция мача 
            padNewPosition = new Vector3(ballPos.x, yPosition, 0); //новая позиция pad
           
        }
        else
        {
            Vector3 mouseWorldPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition); // находим координаты мыши в игровом экране координат
            padNewPosition = new Vector3(mouseWorldPosition.x, yPosition, 0); //Запоминаем двиежение платформы только  по X влево вправо и всё
        
        }
        padNewPosition.x = Mathf.Clamp(padNewPosition.x, -maxX, maxX);
        transform.position = padNewPosition; // Занесли координаты мыши в платфору двигаем её за мышкой
        DontDestroyOnLoad(gameObject);
    }
}
