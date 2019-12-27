using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jump : MonoBehaviour
{
    public float jumpHeight;
     bool isJumping = false;
    private Rigidbody2D rb2d;
    public Collider2D player;
    public Collider2D ground;
    public float jumpStartTime;
    public bool forceApplied;
    Animator animator;
    bool[] playerStates={false,true,false};
    public static string State;
    Vector2 v;

    void Start()
    {
        rb2d = GetComponent<Rigidbody2D> ();
        player= GetComponent<Collider2D>();
        ground = GameObject.FindGameObjectWithTag("Ground").GetComponent<Collider2D>();
        animator= GetComponent<Animator>();
        //starts jumping false on ground true onVault false
        animator.SetBool("grounded",true);
       

    }

    // Update is called once per frame
    void Update()
    {
        v= rb2d.velocity;
        if(isJumping){
           playerStates[0] = true;
           playerStates[1] = false;
           playerStates[2] = false;
           animator.SetBool("grounded",false);
            
             if(v.x>=1){
                v.x /= (float) 1.02;
            }
            if(v.x>=5){
                v.x=5;
            }
            else if (v.x<=-5){
                v.x=-5;
            }
            rb2d.velocity=v;
            State="inAir";
        }
        if ((Input.GetKeyDown("space")||Input.GetKeyDown("w") || Input.GetKeyDown("up"))&&!isJumping && animator.GetBool("grounded") ) 
        {
            isJumping=true;
            animator.SetBool("jumping", true);
            jumpStartTime=Time.time;
        }
        if(isJumping && (Time.time - jumpStartTime) > .1 && !forceApplied ){
            forceApplied=true;
            rb2d.AddForce(Vector2.up*jumpHeight);
            animator.SetBool("onVault", false);
            State="jumpUp";
        }


        if(isJumping && rb2d.velocity.y < 0 ){
            animator.SetBool("falling", true);   
            State="falling";     
        }
     
    }

    void OnCollisionEnter2D (Collision2D col)  
    {
        if(col.gameObject.tag=="Ground"){
            isJumping=false;
            forceApplied=false;
            playerStates[0] = false;
            playerStates[1]=true;
            animator.SetBool("grounded",true);
            animator.SetBool("jumping", false);
            animator.SetBool("falling", false);
            animator.SetBool("onVault", false);
        }
        else if(col.gameObject.tag == "Vault" && player.transform.position.y >-2.72 ){
                Money.cash += Money.CPJ;
                animator.SetBool("onVault", true);
                isJumping=true;
                forceApplied=false;
                animator.SetBool("jumping", true);
                animator.SetBool("falling", false);
                jumpStartTime=Time.time;
                playerStates[2]=true;
        }
    }
    void OnEnable(){
        rb2d.velocity=v;
        animator.SetBool("jumping", playerStates[0]);
        animator.SetBool("grounded", playerStates[1]);
        animator.SetBool("onVault", playerStates[2]);
        animator.Play(State, -1 , 0f);
    }
}
