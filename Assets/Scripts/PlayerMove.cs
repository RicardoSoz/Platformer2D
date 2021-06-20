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

    // Start is called before the first frame update
    void Start(){
        rigibody2D = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void FixedUpdate(){

        if (Input.GetKey("d")){
            //Left
            rigibody2D.velocity = new Vector2(runSpeed, rigibody2D.velocity.y);

        } 
        else if (Input.GetKey("a")){
            //Right
            rigibody2D.velocity = new Vector2(-runSpeed, rigibody2D.velocity.y);
        }
        else if (Input.GetKey("w") && CheckGround.isGrounded)
        {   //Jump
            rigibody2D.velocity = new Vector2(-rigibody2D.velocity.x,jumpSpeed);
        }
        else
        {   //Static
            rigibody2D.velocity = new Vector2(0, rigibody2D.velocity.y);
        }


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
