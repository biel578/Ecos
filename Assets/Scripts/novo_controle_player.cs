using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor.Tilemaps;
using UnityEngine;

public class novo_controle_player : MonoBehaviour
{
    public Animator animator;
    private Rigidbody2D rb;
    bool facingR = true;
    public float speed = 2.5f;
    private bool isFire;
    RaycastHit leftCheck;
    RaycastHit rightCheck;
    private float xVelocity;
    private float yVelocity;
    Vector2 moviment;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if(isFire == false){
            float input_x = Input.GetAxis("Horizontal");
            float input_y = Input.GetAxis("Vertical");
            moviment = new Vector2(input_x, input_y);
            
            if (input_x > 0 && !facingR)
        {
            flip();
        }
        if (input_x < 0 && facingR)
        {
            flip();
        }
        if(Input.GetButtonDown("Fire1")){
            isFire = true;
            animator.SetTrigger("fire");
        }
    }
    }
    void flip()
    {
        Vector3 currentScale = gameObject.transform.localScale;
        currentScale.x *= -1;
        gameObject.transform.localScale = currentScale;

        facingR = !facingR;
    }
    private void FixedUpdate()
    {
        if(isFire==false)
        {
            xVelocity = moviment.normalized.x * speed;
            yVelocity = moviment.normalized.y * speed;
            rb.velocity = new Vector2(xVelocity, yVelocity);
        }
    }
    private void LateUpdate()
    {
        //animator.SetTrigger("Die");
        animator.SetFloat("xVelocity", Mathf.Abs(xVelocity));
        animator.SetFloat("yVelocity", Mathf.Abs(yVelocity));

        if(animator.GetCurrentAnimatorStateInfo(0).IsTag("fire"))
        {
            isFire = true;
        }else
        {
            isFire = false;
        }
    }
}
