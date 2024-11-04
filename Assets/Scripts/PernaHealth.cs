using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PernaHealth : MonoBehaviour
{
    public int currentHealth;
    public int maxHealth = 20;
void Start()
{
    currentHealth = maxHealth;
}
    public void ChangeHealth(int amount)
    {
        currentHealth += amount;

        if(currentHealth < 0)
        {
            gameObject.SetActive(false);
        }
    }
    void TakeDamage(int amount)
    {
        currentHealth -= amount;

        if(currentHealth <=0 )
        {
            Destroy(gameObject);
        }
    }
    private void OnTriggerEnter2D(Collider collision)
    {
        if (collision.tag != "lama")
        {
            gameObject.transform.parent = collision.gameObject.transform;
            Destroy(gameObject);
            GetComponent<CircleCollider2D>().enabled = false;
        }
    }
}