using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour
{
    private Rigidbody2D rb2d;    
    public bool moving=true;
    double value;
    float spawnTime;
    private SpriteRenderer mySpriteRenderer;
    public string state;
    public bool inMagnet;
    bool hitGround;
    Animator animator;
    Collider2D col2D;
    

    void Start()
    {
        inMagnet=false;
        spawnTime = Time.time;
        hitGround=false;
        rb2d = GetComponent<Rigidbody2D> ();
        animator = GetComponent<Animator>();
        col2D = GetComponent<Collider2D>();
        
        int xDirection=-1;
        if(Random.Range(0.0f,10.0f)>5){
            xDirection=1;
        }
        Vector2 added = new Vector2(Random.Range(120,240)*xDirection,Random.Range(120,240));
        rb2d.AddForce(added);
        //If lucky Coin
        if(Random.Range(1,100) <= Money.luckyChance){
            value=Money.luckyValue;
            animator.SetBool("lucky", true);
            state="lucky";
        }
        else{
            switch (Money.vaultLevel){
            case 1:
                value=5;
                animator.SetBool("bronze", true);
                state="bronze";
                break;
            case 2:
                value=10;
                animator.SetBool("silver", true);
                state="silver";
                break;
            case 3:
                value=25;
                break;
            case 4:
                value=50;
                animator.SetBool("diamond", true);
                state="diamond";
                break;
            }   
        }      
        mySpriteRenderer = GetComponent<SpriteRenderer>();
        StartCoroutine(Blink());
        
    }
    void OnEnable(){
        animator.SetBool(state, true);
    }
    // Update is called once per frame
    void FixedUpdate()
    {
        if(Time.time - spawnTime >= 7.0){
            Destroy(gameObject);
        }
        if (inMagnet && hitGround){
            Vector2 direction = (transform.position - GameObject.Find("Player").transform.position).normalized;
            float travelSpeed = 8.0f;
            rb2d.velocity = -direction * travelSpeed;
        }
        
    }
    IEnumerator Blink (){
        yield return new WaitForSeconds(4.0f);
        while(true){
            mySpriteRenderer.enabled = false;
            yield return new  WaitForSeconds(0.2f);
            mySpriteRenderer.enabled = true;
            yield return new  WaitForSeconds(0.2f);
        }    
    }
    void OnCollisionEnter2D (Collision2D col)
    {
        if (col.gameObject.tag=="Player"){
            Destroy(gameObject);
            Money.cash += value;
        }
        if (col.gameObject.tag == "Ground"){
            hitGround = true;
        }
    }
    void OnTriggerExit2D(Collider2D col){
        if (col.gameObject.tag == "Magnet"){
            inMagnet=false;
            if (hitGround) rb2d.velocity = Vector2.zero;
        }
    }
    void OnTriggerEnter2D(Collider2D col){
        print (col.gameObject.tag);
        if(col.gameObject.tag == "Magnet"){
            inMagnet=true;
        }
        else inMagnet=false;
    }
}
