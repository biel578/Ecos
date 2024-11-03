using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class trigger_damage : MonoBehaviour
{
    public heart_system heart;
    public PLayer_Controller playerAnimator;
    
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            heart.vida--;
            playerAnimator.playerAnimator.SetTrigger("TakeDamage");
        }
    }

}
