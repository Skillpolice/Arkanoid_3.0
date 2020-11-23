using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickupPadSize : MonoBehaviour
{
    private void ApplyEffect()
    {
        //изменение платформы
        float randX = Random.Range(0.5f, 1.5f);
        Pad pad = FindObjectOfType<Pad>();
        pad.transform.localScale = new Vector3(randX, 1, 0);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Pad"))
        {
            //TODO применение эффекта
            //вызов функции 

            ApplyEffect();
            Destroy(gameObject);
        }
    }


}
