using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    //variable to store the player's movement speed
    public static float speed=25;
    //reference to rigidbody2d component of player
    private Rigidbody2D rb2d;
    private SpriteRenderer mySpriteRenderer;
    Animator animator;
    public int maxV = 8;
    Vector2 oldV;

    
    void Start()
    {
        //get and store reference to RB2D of player 
        rb2d = GetComponent<Rigidbody2D>();
        animator= GetComponent<Animator>();
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
        Vector2 v= rb2d.velocity;
        //Add force based on movement vector
        if(moveHorizontral<0){
            mySpriteRenderer.flipX = true;
            animator.SetBool("running", true);
        }
        else if(moveHorizontral>0){
            mySpriteRenderer.flipX = false;
            animator.SetBool("running", true);
        }
        else{
            animator.SetBool("running", false);
            if(v.x>=1){
                v.x--;
            }
            rb2d.velocity= v;
        }
        if(rb2d.velocity.x >= maxV || rb2d.velocity.x <= -1*maxV){
            if(v.x < 0){
                v.x = maxV * -1;
            }
            else{
                v.x= maxV;
            }
            rb2d.velocity = v;

        }
        else{
            if(animator.GetCurrentAnimatorStateInfo(0).IsName("inAir")){
                Vector2 jumpMultiplier = new Vector2((float) .5 ,1);
                rb2d.AddForce(movement*speed*jumpMultiplier);        
            }
            else{
                rb2d.AddForce(movement*speed);        
            }
        }
        oldV= rb2d.velocity;
    
        
        
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
        if(col.gameObject.tag=="Money"){
            rb2d.velocity=oldV;
        }
      
    }
}
