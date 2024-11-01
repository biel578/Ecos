using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move_Protet : MonoBehaviour
{
    private float input_y;
    #region Movimentação do jogador
    [SerializeField]
    private float velocidadeMovimento;

    [SerializeField]
    private float distanciaMinima;

    [SerializeField]
    private new Rigidbody2D rigidbody;

    [SerializeField]
    private SpriteRenderer spriteRenderer;

    [SerializeField]
    private Animator animator;
    #endregion Movimentação do jogador

    [SerializeField]
    private Transform alvo;

    [SerializeField]
    private float raioVisao;
    [SerializeField]
    private LayerMask layerAreaVisao;
    [SerializeField]
    private Color corAreaVisao;
    [SerializeField]
    private Color corDirecaoMovimento;
    // Start is called before the first frame update

    // Update is called once per frame
    void Update()
    {
        ProcurarJogador();
        if (this.alvo != null)
        {
            Mover();
        }
        else
        {
            PararMovimentacao();
        }
    }

    private void OnDrawGizmos(){
        Gizmos.color = this.corAreaVisao;
        Gizmos.DrawWireSphere(this.transform.position, this.raioVisao); // criando campo de visão visivel kkkk
        if(this.alvo != null)
        {
            Gizmos.color = this.corDirecaoMovimento;
            Gizmos.DrawLine(this.transform.position, this.alvo.position);
        }
    }

    private void ProcurarJogador()
    {
       Collider2D colisor = Physics2D.OverlapCircle(this.transform.position, this.raioVisao, this.layerAreaVisao);
       if (colisor != null) //jogador dentro da area de visão
       {
        Vector2 posicaoAtual = this.transform.position;
        Vector2 posicaoAlvo = colisor.transform.position;
        Vector2 direcao = posicaoAlvo - posicaoAtual;
        direcao = direcao.normalized;

        RaycastHit2D hit = Physics2D.Raycast(posicaoAtual, direcao);
        if(hit.transform != null)
        {
            if(hit.transform.CompareTag("Player"))
            {
                this.alvo = colisor.transform;
            }else
            {
                this.alvo = null;
            }
        }
       }
       else
       {
        this.alvo = null;
       }
    }
    private void Mover()
    {
        Vector2 posicaoAlvo = this.alvo.position;
        Vector2 posicaoAtual = this.transform.position;
        Vector2 input_y = this.alvo.position;
        float distancia = Vector2.Distance(posicaoAtual, posicaoAlvo);
        if (distancia >= this.distanciaMinima)
        {
            Vector2 direcao = posicaoAlvo - posicaoAtual;
            direcao = direcao.normalized;

            this.rigidbody.velocity = (this.velocidadeMovimento * direcao);

            if (this.rigidbody.velocity.x > 0)
            {
                this.spriteRenderer.flipX = true;
            }
            else if (this.rigidbody.velocity.x < 0)
            {
                this.spriteRenderer.flipX = false;
            }
            this.animator.SetBool("movendo", true);
        }
        else {
            PararMovimentacao();
            this.animator.SetBool("movendo", false);
        }

    }

    private void PararMovimentacao()
    {
        this.rigidbody.velocity = Vector2.zero;
        this.animator.SetBool("movendo", false);
    }
}
