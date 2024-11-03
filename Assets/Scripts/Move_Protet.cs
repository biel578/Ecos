using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.XR;

public class Move_Protet : MonoBehaviour
{
    private float input_y;
    public float speed;
    private bool insideTrigger = false;
    private bool outsideTrigger = false;
    [SerializeField]
    private new Rigidbody2D rigidbody;

    [SerializeField]
    private SpriteRenderer spriteRenderer;

    [SerializeField]
    private Animator animator;
    public heart_system heart;
    // Start is called before the first frame update
    

    // Update is called once per frame
    void Update()
    {
        if(insideTrigger)
        {
            Debug.Log("Dentro do trigger");
        }
        else if(outsideTrigger)
        {
            Debug.Log("Fora do trigger!");
        }
    }
    private void OnTriggerStay2D(Collider2D collider)
    {
        if(collider.CompareTag("Player"))
        {
            insideTrigger = true;
            outsideTrigger = false;
            Vector2 PosicaoAtual = this.transform.position;
            Vector2 PosicaoPlayer = collider.transform.position;

            transform.position = Vector2.Lerp(PosicaoPlayer, PosicaoAtual, speed);

            Vector2 direcao = PosicaoPlayer - PosicaoAtual;
            direcao = direcao.normalized;
            
            int valorX = Mathf.RoundToInt(direcao.normalized.x);
            if (valorX > 0)
            {
                this.spriteRenderer.flipX = true;
            }
            else if (valorX < 0)
            {
                this.spriteRenderer.flipX = false;
            }
            this.animator.SetBool("movendo", true);
        }
    }
    private void OnTriggerExit2D(Collider2D collider)
    {
        if (collider.CompareTag("Player"))
        {
            insideTrigger = false;
            outsideTrigger = true;
            PararMovimentacao();
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            for(int i = 0; i < 2; i++)
            {
                heart.vida--;
                heart.HealthLogic();
            }
            this.animator.SetBool("movendo", false);
            PararMovimentacao();
            
        }
    }
    private void PararMovimentacao()
    {
        this.rigidbody.velocity = Vector2.zero;
        this.animator.SetBool("movendo", false);
    }
}
