using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//So I can just use Text instead of UnityEngine.UI.Text
using UnityEngine.UI;

public class Buttons : MonoBehaviour
{
    Text text;
    Image image;
    // Start is called before the first frame update
    void Start()
    {
        text = transform.Find("text").GetComponent<Text>();
        image = transform.Find("image").GetComponent<Image>();
        print(image);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void hovering(){
        print("Hovering");
        text.enabled= true;
        image.enabled= true;
    }
    public void notHovering(){
        text.enabled=false;
        image.enabled=true;
    }
}
