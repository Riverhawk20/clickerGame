using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Vault : MonoBehaviour
{
    Animator animator;
    int health;
    public static bool destroy;
    string state;
    void Start()
    {
      animator = GetComponent<Animator>(); 
      destroy=false;
    }
    void OnAwake(){
        state="Blue";
    }

    // Update is called once per frame
    void Update()
    {
        if (destroy){
            DestroyVault();
            destroy=false;
        }
    }
    void OnEnable(){
        animator.SetBool(state, true);
    }
    public void DestroyVault(){
        switch (Money.vaultLevel){
            case 1:
                animator.SetBool("Blue", true);
                animator.SetBool("Green", false);
                animator.SetBool("Orange", false);
                animator.SetBool("Yellow", false);
                state="Blue";
                break;
            case 2:
                animator.SetBool("Blue", false);
                animator.SetBool("Green", true);
                animator.SetBool("Orange", false);
                animator.SetBool("Yellow", false);
                state="Green";
                break;
            case 3:
                animator.SetBool("Blue", false);
                animator.SetBool("Green", false);
                animator.SetBool("Orange", true);
                animator.SetBool("Yellow", false);
                state="Orange";
                break;
            case 4:
                animator.SetBool("Blue", false);
                animator.SetBool("Green", false);
                animator.SetBool("Orange", false);
                animator.SetBool("Yellow", true);
                state="Yellow";
                break;
        } 
    }
}
