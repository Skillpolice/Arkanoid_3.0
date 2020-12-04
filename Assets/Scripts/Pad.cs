using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pad : MonoBehaviour
{
    Ball ball;
    GameManager gameManager;
    public GameObject explosionActiveEffect;


    [HideInInspector]
    public bool isActiveEffetct;
    [Header("Mouse - Keyboard")]
    public bool isKeyboard;
    [Header("AutoPlay")]
    public bool autoPlay;
    [Header("Position")]
    public float maxX;

    public float padSpeed = 13f;
    float yPosition;

    void Start()
    {
        ball = FindObjectOfType<Ball>();
        gameManager = FindObjectOfType<GameManager>();

        yPosition = transform.position.y; // 3апоминаем позицию для платформы по Y
        Cursor.visible = false;
    }

    public void ActiveEffect()
    {
        isActiveEffetct = true;
        explosionActiveEffect.SetActive(true);
    }

    public void Update()
    {

        if (gameManager.isPauseActive)
        {
            //пауза активна - ничего не нужно делать
            return;
        }
        MouseKeyboard();
    }

    private void MouseKeyboard()
    {
        Vector3 padNewPosition;
        if (autoPlay)
        {
            Vector3 ballPos = ball.transform.position; //позиция мача 
            padNewPosition = new Vector3(ballPos.x, yPosition, 0); //новая позиция pad

        }
        if(isKeyboard)
        {
            //Keyboardmovement
            padNewPosition = transform.position;
            if (Input.GetKey(KeyCode.RightArrow))
            {
                padNewPosition.x += padSpeed * Time.deltaTime;
            }
            if (Input.GetKey(KeyCode.LeftArrow))
            {
                padNewPosition.x -= padSpeed * Time.deltaTime ;
            }
        }
        else
        {
            //MouseMovement
            Vector3 mouseWorldPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition); // находим координаты мыши в игровом экране координат
            padNewPosition = new Vector3(mouseWorldPosition.x, yPosition, 0); //Запоминаем двиежение платформы только  по X влево вправо и всё

        }
        padNewPosition.x = Mathf.Clamp(padNewPosition.x, -maxX, maxX);
        transform.position = padNewPosition; // Занесли координаты мыши в платфору двигаем её за мышкой
                                             //DontDestroyOnLoad(gameObject);
    }
}
