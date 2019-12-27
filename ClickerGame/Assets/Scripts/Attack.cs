using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attack : MonoBehaviour
{
    // Start is called before the first frame update
    public static bool isAttacking=false;
    Animator animator;
    [SerializeField] GameObject player;
    [SerializeField] GameObject vault;
    [SerializeField] GameObject Coin;
    private SpriteRenderer mySpriteRenderer;


    float attackStart;
    void Start()
    {
        animator= GetComponent<Animator>();
        mySpriteRenderer = GetComponent<SpriteRenderer>();

    }
    void Awake(){
     attackStart =Time.time;
    }
    // Update is called once per frame
    void Update()
    {
        if(Input.GetMouseButtonDown(0)){
            if(!animator.GetBool("isAttacking")){
                animator.SetBool("isAttacking", true);
            }
        }
        else {
            animator.SetBool("isAttacking", false);
        }
        if ( animator.GetCurrentAnimatorStateInfo(0).IsName("Attack") && 
        ( animator.GetBool("grounded") && (Vector2.Distance(player.transform.position, vault.transform.position)< 2.35f)
        &&  ( (!mySpriteRenderer.flipX && player.transform.position.x < vault.transform.position.x  ) || (mySpriteRenderer.flipX && player.transform.position.x > vault.transform.position.x ) )    )
        )
            {

            if(Time.time - attackStart > .34){
                Money.cash += Money.CPH;
                attackStart=Time.time;
                if(Random.Range(1,100)<=Money.coinChance){
                    Instantiate(Coin, vault.transform);
                }
            }
        }
    }
  
        
    
}
