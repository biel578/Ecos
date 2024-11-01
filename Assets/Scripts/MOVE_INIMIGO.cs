using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MOVE_INIMIGO : MonoBehaviour
{
    [SerializeField]
    private Transform alvo;

    [SerializeField]
    private float velocidadeMovimento;

    [SerializeField]
    private Rigidbody2D myrigidbody;
    // Update is called once per frame
    void Update()
    {
        Vector2 posicaoAlvo = this.alvo.position;
        Vector2 posicaoAtual = this.transform.position;
        Vector2 direcao = posicaoAlvo - posicaoAtual;
        direcao = direcao.normalized;
        
        this.myrigidbody.velocity = (this.velocidadeMovimento * direcao);

    }
}
