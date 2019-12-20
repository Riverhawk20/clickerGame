using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jump : MonoBehaviour
{
    public float jumpHeight;
    private bool isJumping = false;
    private Rigidbody2D rb2d;
    public Collider2D player;
    public Collider2D ground;
    public float jumpStartTime;
    public bool forceApplied;
    Animator animator;

    void Start()
    {
        rb2d = GetComponent<Rigidbody2D> ();
        player= GetComponent<Collider2D>();
        ground = GameObject.FindGameObjectWithTag("Ground").GetComponent<Collider2D>();
        animator= GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if(isJumping){
           animator.SetBool("grounded",false);
            Vector2 v= rb2d.velocity;
             if(v.x>=1){
                v.x /= (float) 1.02;
            }
            rb2d.velocity=v;
        }
        if ((Input.GetKeyDown("space")||Input.GetKeyDown("w") || Input.GetKeyDown("up"))&&!isJumping)
        {
            isJumping=true;
            animator.SetBool("jumping", true);
            jumpStartTime=Time.time;
        }
        if(isJumping && (Time.time - jumpStartTime) > .2 && !forceApplied){
            forceApplied=true;
            rb2d.AddForce(Vector2.up*jumpHeight);
        }


        if(isJumping && rb2d.velocity.y < 0 ){
            animator.SetBool("falling", true);
        }
     
    }

    void OnCollisionEnter2D (Collision2D col)
    {
        if(col.gameObject.tag == "Vault"||col.gameObject.tag=="Ground"){
            isJumping=false;
            forceApplied=false;
            animator.SetBool("grounded",true);
            animator.SetBool("jumping", false);
            animator.SetBool("falling", false);
        }
    }
}
