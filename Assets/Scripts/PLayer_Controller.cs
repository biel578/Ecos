using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Scripting.APIUpdating;

public class PLayer_Controller : MonoBehaviour
{
    public Animator playerAnimator;
    private Rigidbody2D rb;
    float input_x = 0;
    float input_y = 0;
    public float speed = 6.5f;
    bool isWalking = false;
    bool facingR = true;
    bool isFiring = false;
    private Vector2 movement;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }
    // Start is called before the first frame update
    void Start()
    {
        isWalking = false;
        isFiring = false;
    }

    // Update is called once per frame
    void Update()
    {
        input_x = Input.GetAxisRaw("Horizontal");
        input_y = Input.GetAxisRaw("Vertical");
        var move = new Vector3(input_x, input_y, rb.velocity.y).normalized;
        isWalking = (input_x !=0 || input_y !=0);
        isFiring = (!isWalking);

        if (isWalking)
        {
            transform.position += move * speed * Time.deltaTime;
            playerAnimator.SetFloat("input_x", input_x);
            isFiring = false;
        }

        playerAnimator.SetBool("isWalking", isWalking);

        if(Input.GetButtonDown("Fire1")){
            move = Vector2.zero;
            rb.velocity = Vector2.zero;
            playerAnimator.SetTrigger("fire");
        }   

        if (input_x > 0 && !facingR)
        {
            flip();
        }
        if (input_x < 0 && facingR)
        {
            flip();
        }

    }

    void flip()
    {
        Vector3 currentScale = gameObject.transform.localScale;
        currentScale.x *= -1;
        gameObject.transform.localScale = currentScale;

        facingR = !facingR;
    }
    void noFire()
    {
        isFiring = false;
    }
}
