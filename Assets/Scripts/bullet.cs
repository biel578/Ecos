using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.Video;

public class bullet : MonoBehaviour
{
    private int vidas = 20;
    public GameObject hitEffect;

    void Start()
    {
        Destroy(gameObject, 0.75f);
    }
    void OnCollisionEnter2D(Collision2D collision)
    {
        if(!collision.gameObject.CompareTag("UI")){
            GameObject effect = Instantiate(hitEffect, transform.position, Quaternion.identity);
            Destroy(effect, 0.55f);
            Destroy(gameObject);
        }
        if(collision.gameObject.CompareTag("perna"))
        {
            GameObject effect = Instantiate(hitEffect, transform.position, Quaternion.identity);
            Destroy(effect, 0.55f);
            for(int i = 0; i<=20;)
            {
                Destroy(collision.gameObject);
                i++;
            }
        }

        if (collision.gameObject.CompareTag("protetor"))
        {
            Destroy(collision.gameObject);
        }


    }
}
