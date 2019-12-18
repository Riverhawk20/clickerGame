using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    //variable to store the player's movement speed
    public static float speed=15;
    //reference to rigidbody2d component of player
    private Rigidbody2D rb2d;
    public Vector2 maxSpeed= new Vector2 (30,0);
    private SpriteRenderer mySpriteRenderer;
    
    void Start()
    {
        //get and store reference to RB2D of player 
        rb2d = GetComponent<Rigidbody2D> ();
        mySpriteRenderer = GetComponent<SpriteRenderer>();
    }

    //FixedUpdate is indpendent of framrate and relies on time
    //physics
    void FixedUpdate()
    {
        //store current horizontal  input 
        float moveHorizontral = Input.GetAxis("Horizontal");
        //create movement vector
        Vector2 movement = new Vector2 (moveHorizontral,0);
        //Add force based on movement vector
        if(moveHorizontral<0){
            mySpriteRenderer.flipX = true;
        }
        else if(moveHorizontral>0){
            mySpriteRenderer.flipX = false;
        }
        if(movement.x*speed>=maxSpeed.x){
            rb2d.AddForce(maxSpeed);
        }
        else{
            rb2d.AddForce(movement*speed);        
        }
        
        
    }
    void OnCollisionEnter2D (Collision2D col)
    {
        float k=0;
        float moveHorizontral = Input.GetAxis("Horizontal");
        if (moveHorizontral>0){
            k=-1;
        }
        else {
            k=1;
        }
        if(col.gameObject.tag=="MainCamera"){
            Vector2 repel = new Vector2 (200*k, -50);
            rb2d.AddForce(repel);
        }
    }
}
