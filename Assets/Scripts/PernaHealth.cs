using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PernaHealth : MonoBehaviour
{
    public int currentHealth;
    public int maxHealth = 20;
    private bool hasTakenDamage = false;

    void Start()
    {
        currentHealth = maxHealth;
    }

    public void ChangeHealth(int amount)
    {
        currentHealth += amount;

        if (currentHealth <= 0)
        {
            Destroy(gameObject);
        }
    }

    private void OnTriggerStay2D(Collider2D collider)
    {
        if (collider.tag != "lama" && !hasTakenDamage)
        {
            GetComponent<CircleCollider2D>().enabled = false;

            hasTakenDamage = true;

            ChangeHealth(-5);
        }
    }

    private IEnumerator LoadSceneAfterDelay(float delay)
    {
        yield return new WaitForSeconds(delay);
        SceneManager.LoadScene("Game Over Tela");
    }
}


