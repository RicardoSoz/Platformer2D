using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour{

    public float runSpeed = 2;
    public float jumpSpeed = 4;
    public float fallMultiplier = 0.5f;
    public float lowJumpMultiplier = 1f;
    public bool betterJump = false;

    Rigidbody2D rigibody2D;
    //Arrastrar el SpriteRenderer al menu del srcipt dentro de Frog para cambiar la orentación de la animación 
    public SpriteRenderer spriteRenderer;
    //Arrastrar el Animator al menu del script dentro de Frog para pasar de Idle a Run
    public Animator animator;

    // Start is called before the first frame update
    void Start(){
        rigibody2D = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void FixedUpdate(){

        //Right--------------------------------------------------------------------------------------------
        if (Input.GetKey("d"))
        {
            rigibody2D.velocity = new Vector2(runSpeed, rigibody2D.velocity.y);
            spriteRenderer.flipX = false;
            animator.SetBool("Run", true);
        }
        //else if (Input.GetKey("d") && Input.GetKey("w") && CheckGround.isGrounded)
        //{
        //    rigibody2D.velocity = new Vector2(runSpeed, rigibody2D.velocity.y);
        //    rigibody2D.velocity = new Vector2(-rigibody2D.velocity.x, jumpSpeed);
        //    spriteRenderer.flipX = false;
        //}

        //Left--------------------------------------------------------------------------------------------
        else if (Input.GetKey("a"))
        {
            rigibody2D.velocity = new Vector2(-runSpeed, rigibody2D.velocity.y);
            spriteRenderer.flipX = true;
            animator.SetBool("Run", true);
        }
        //else if (Input.GetKey("a") && Input.GetKey("w") && CheckGround.isGrounded)
        //{
        //    rigibody2D.velocity = new Vector2(-runSpeed, rigibody2D.velocity.y);
        //    rigibody2D.velocity = new Vector2(-rigibody2D.velocity.x, jumpSpeed);
        //    spriteRenderer.flipX = true;
        //}
        //Static--------------------------------------------------------------------------------------------
        else
        {
            rigibody2D.velocity = new Vector2(0, rigibody2D.velocity.y);
            animator.SetBool("Run", false);
        }

        //Jump--------------------------------------------------------------------------------------------
        if (Input.GetKey("w") && CheckGround.isGrounded)
        {
            rigibody2D.velocity = new Vector2(-rigibody2D.velocity.x,jumpSpeed);
        }
        //Jump animation
        if (CheckGround.isGrounded)
        {
            animator.SetBool("Jump", false);
        }

        if (!CheckGround.isGrounded)
        {
            animator.SetBool("Run", false);
            animator.SetBool("Jump", true);
        }


        //Increase the jump
        if (betterJump)
        {
            if (rigibody2D.velocity.y < 0)
            {
                rigibody2D.velocity += Vector2.up * Physics2D.gravity.y * (fallMultiplier) * Time.deltaTime;
            }

            if (rigibody2D.velocity.y > 0 && !Input.GetKey("w"))
            {
                rigibody2D.velocity += Vector2.up * Physics2D.gravity.y * (lowJumpMultiplier) * Time.deltaTime;
            }
        }
    }
}
