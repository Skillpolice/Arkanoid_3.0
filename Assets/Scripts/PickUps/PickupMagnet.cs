using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickupMagnet : MonoBehaviour
{
    public GameObject particalEffects;

    private void ApplyEffect()
    {
        Ball[] balls = FindObjectsOfType<Ball>();
        Pad pad = FindObjectOfType<Pad>();
        foreach (Ball item in balls)
        {
            item.ActiveteMagnet();
            Instantiate(particalEffects, transform.position, Quaternion.identity);
            pad.ActiveEffect();
        }
      
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
