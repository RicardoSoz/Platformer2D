using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour{

    public float runSpeed = 2;
    public float jumpSpeed = 4;
    Rigidbody2D rigibody2D;

    // Start is called before the first frame update
    void Start(){
        rigibody2D = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void FixedUpdate(){

        if (Input.GetKey("d") || Input.GetKey("right")){

            rigibody2D.velocity = new Vector2(runSpeed, rigibody2D.velocity.y);

        } 
        else if (Input.GetKey("a") || Input.GetKey("left")){
            rigibody2D.velocity = new Vector2(-runSpeed, rigibody2D.velocity.y);
        }
        else if (Input.GetKey("w") && CheckGround.isGrounded || Input.GetKey("up") && CheckGround.isGrounded)
        {
            rigibody2D.velocity = new Vector2(-rigibody2D.velocity.x,jumpSpeed);
        }
        else
        {
            rigibody2D.velocity = new Vector2(0, rigibody2D.velocity.y);
        }

    }
}
