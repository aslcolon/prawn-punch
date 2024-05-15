using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyInput : MonoBehaviour
{

    //private SpriteRenderer spriteRen;
    //public Sprite defSprite;
    //public Sprite hitSprite;

    //public KeyCode keyToPress;

    // Start is called before the first frame update
    void Start()
    {
        //spriteRen = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.y < 1.5)
        {
            floatKey();
        }  
    }

    void floatKey()
    {

        float incY = transform.position.y + 1;
        float moveRate = 2;
        var change = moveRate * Time.deltaTime;

        transform.position = Vector3.MoveTowards(transform.position, new Vector3(transform.position.x, incY), change);
    }
}
