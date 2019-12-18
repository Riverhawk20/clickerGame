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
    void Start()
    {
        rb2d = GetComponent<Rigidbody2D> ();
        player= GetComponent<Collider2D>();
        ground = GameObject.FindGameObjectWithTag("Ground").GetComponent<Collider2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if ((Input.GetKeyDown("space")||Input.GetKeyDown("w") || Input.GetKeyDown("up"))&&!isJumping)
        {
            rb2d.AddForce(Vector2.up*jumpHeight);
            isJumping=true;
        }
    }

    void OnCollisionEnter2D (Collision2D col)
    {
        if(col.gameObject.tag == "Vault"||col.gameObject.tag=="Ground"){
            isJumping=false;
        }
    }
}
