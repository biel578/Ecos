using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

public class bullet : MonoBehaviour
{
    public GameObject hitEffect;

    void Start()
    {
        Destroy(gameObject, 0.75f);
    }
    void OnCollisionEnter2D(Collision2D collision)
    {

        GameObject effect = Instantiate(hitEffect, transform.position, Quaternion.identity);
        Destroy(effect, 0.55f);
        Destroy(gameObject);

        if (collision.gameObject.CompareTag("protetor"))
        {
            Destroy(collision.gameObject);
        }
    }
}
