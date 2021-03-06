﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

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
    float moveHorizontral;
    //1 for right -1 for left
    int direction;


    
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
        //#if UNITY_IOS || UNITY_ANDROID
        if(direction==1){
            moveHorizontral+= Time.deltaTime*5.5f;
            if (moveHorizontral>=1) moveHorizontral=1;
        }
        else if (direction==-1){
            moveHorizontral-=Time.deltaTime*5.5f;
            if (moveHorizontral<=-1) moveHorizontral=-1;
        }
        /*
        #else
        //store current horizontal  input 
        moveHorizontral = Input.GetAxis("Horizontal");
        #endif*/
        //create movement vector
        Vector2 movement = new Vector2 (moveHorizontral,0);
        Vector2 v= rb2d.velocity;
        //Add force based on movement vector
        if(moveHorizontral<0){
            mySpriteRenderer.flipX = true;
            animator.SetBool("running", true);
            Jump.State="running";
        }
        else if(moveHorizontral>0){
            mySpriteRenderer.flipX = false;
            animator.SetBool("running", true);
            Jump.State="running";
        }
        else{
            animator.SetBool("running", false);
            //v.x and v.y is 0 the state is idle
            if(v.y==0){
               // Jump.State = "Idle";
            }
            if(v.x>=1){
                v.x--;
            }
            else if(v.x<=-1){
                v.x++;
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
            //this is where force is added from pressing left or right
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
    public void mobileRight(){
        direction=1;
    }
    public void mobileLeft(){
        direction=-1;
    }
    public void releaseMobileButton(){
        moveHorizontral=0;
        direction=0;
    }
}
