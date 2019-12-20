using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour
{
    private Rigidbody2D rb2d;    
    public bool moving=true;
    int value;
    void Start()
    {
        rb2d = GetComponent<Rigidbody2D> ();
        int xDirection=-1;
        if(Random.Range(0.0f,10.0f)>5){
            xDirection=1;
        }
        Vector2 added = new Vector2(Random.Range(120,240)*xDirection,Random.Range(120,240));
        rb2d.AddForce(added);
        switch (Money.vaultLevel){
            case 1:
                value=5;
                break;
            case 2:
                value=10;
                break;
            case 3:
                value=25;
                break;
        }

    }

    // Update is called once per frame
    void Update()
    {
    }
    void OnCollisionEnter2D (Collision2D col)
    {
        if (col.gameObject.tag=="Player"){
            Destroy(gameObject);
            Money.cash += value;
        }
    }
}
