using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    //Ссылка на обьект 
    Pad pad; //ссылка(скрипт) на платформу, что бы мячь ездил вместе с платформой\
    AudioSource audioSource;
    public GameObject explosionEffect;
    public AudioClip explosionModeSound; 
    public Rigidbody2D rb; // доступ к обьекту из unity // и перетаскиваем обьект (скрипт мяча) на обьект в Unity , что бы получить его же Rigidbody

    [HideInInspector]
    public bool isStarted;
    [HideInInspector]
    public bool IsMagnetActive;

    public float explosionRadius;
    public bool isActiveBall; //активен ли режим взрыва

    public float speedBall;
  
    float yPosition;
    float xDelta;

    private void Awake()
    {
        //поиск компонентов на этом GameObject лучше делать в Awake
        rb = GetComponent<Rigidbody2D>();
        pad = FindObjectOfType<Pad>();

        audioSource = GetComponent<AudioSource>();
    }

    private void Start()
    {
        yPosition = transform.position.y;
        xDelta = transform.position.x - pad.transform.position.x; //прилипание мяча в позиции платформы

        if (pad.autoPlay)
        {
            StartBall();
        }
    }

    private void Update()
    {
        if (isStarted)
        {

        }
        else
        {
            //двигаться вместе с платформой
            Vector3 padPosition = pad.transform.position; //позиция платформы 
            Vector3 ballNewPosition = new Vector3(padPosition.x + xDelta, yPosition, 0); //новая позиция меча
            transform.position = ballNewPosition;

            if (Input.GetMouseButtonDown(0) || Input.GetKey(KeyCode.UpArrow)) //нажатие мыши left для полета меча
            {
                StartBall();
            }
        }
        //DontDestroyOnLoad(gameObject);
    }

    public void StartBall() //
    {
        float randX = Random.Range(0, 0);
        Vector2 force = new Vector2(randX, 5).normalized * speedBall;
        rb.velocity = force;   //создаем дивежие меча по координатам через AddForce
        isStarted = true;
    }
    public void RestartBall()
    {
        isStarted = false;
        rb.velocity = Vector2.zero;
    }

    //public void MultiplySpeed(float speedKoef)
    //{
    //    speedBall *= speedKoef;
    //    rb.velocity = rb.velocity.normalized * speedBall;
    //}

    public void Duplicate()
    {
        Ball originalBall = this;
        Ball newBall =  Instantiate(originalBall);
        newBall.StartBall();

        if(IsMagnetActive)
        {
            newBall.ActiveteMagnet();
        }
        if(isActiveBall)
        {
            newBall.ExplosiveBall();
        }
    }

    public void ActiveteMagnet()
    {
        IsMagnetActive = true;
        pad.ActiveEffect();
    }

    public  void ExplosiveBall()
    {
        isActiveBall = true;
        explosionEffect.SetActive(true);
        audioSource.clip = explosionModeSound;
 
    }

    private void OnCollisionEnter2D(Collision2D collision) //Магнитизм мяча !!!
    {
        audioSource.Play(); //Воспроизводит звук при коллизии


        if (IsMagnetActive && collision.gameObject.CompareTag("Pad"))
        {
            yPosition = transform.position.y;
            xDelta = transform.position.x - pad.transform.position.x; //прилипание мяча в позиции платформы
            RestartBall();
        }
        if(isActiveBall && collision.gameObject.CompareTag("BlockRectungle"))
        {
            if (isActiveBall)
            {
                //блок взырвной - логика взрыва
                Explode();
            }
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
                print("NULL 1");
                //обьект без скрипта - уничтожить
                Destroy(item.gameObject);
            }
            else
            {
                //обькт со скриптом
                block.RectungleDestroyBlock();
                print("SCRIPT 1");
            }
        }
    }


    private void OnDrawGizmos()
    {
        Gizmos.color = Color.blue;
        Gizmos.DrawWireSphere(transform.position, explosionRadius);
    }

}
