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
    private Vector2 movement;
    private bool facingR = true;
    private bool isFire = false;


    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }
    // Start is called before the first frame update
    void Start()
    {
        isWalking = false;
        isFire = false;
    }

    // Update is called once per frame
    void Update()
    {
        if(isFire == true){
            isWalking = false;
        }
        input_x = Input.GetAxisRaw("Horizontal");
        input_y = Input.GetAxisRaw("Vertical");
        isWalking = (input_x !=0 || input_y !=0);
        if(isWalking)
        {
            var move = new Vector3(input_x, input_y, rb.velocity.y).normalized;
            transform.position += move * speed * Time.deltaTime;
            playerAnimator.SetFloat("input_x", input_x);
            playerAnimator.SetFloat("input_y", input_y);
            isFire = false;
        }
        playerAnimator.SetBool("isWalking", isWalking);

        
        reset();
        
        isFire = false;   
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

    void reset()
    {
        if (Input.GetButtonDown("Fire1")){
            playerAnimator.SetTrigger("fire");
            isFire = true;
        }
    }
}
