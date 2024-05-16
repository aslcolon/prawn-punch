using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class KeyInput : MonoBehaviour
{


    public KeyHolder refScript1, refScript2, refScript3, refScript4, refScript5, refScript6, refScript7, refScript8;
    private int isHitP1 = 0, isHitP2 = 0;

   // private SpriteRenderer spriteRen;
   // public Sprite defSprite;
    //public Sprite hitSprite;

    // Start is called before the first frame update
    void Start()
    {
        //spriteRen = GetComponent<SpriteRenderer>();

        refScript1 = GameObject.Find("Key1").GetComponent<KeyHolder>();
        refScript2 = GameObject.Find("Key2").GetComponent<KeyHolder>();
        refScript3 = GameObject.Find("Key3").GetComponent<KeyHolder>();
        refScript4 = GameObject.Find("Key4").GetComponent<KeyHolder>();
        refScript5 = GameObject.Find("Key5").GetComponent<KeyHolder>();
        refScript6 = GameObject.Find("Key6").GetComponent<KeyHolder>();
        refScript7 = GameObject.Find("Key7").GetComponent<KeyHolder>();
        refScript8 = GameObject.Find("Key8").GetComponent<KeyHolder>();
    }

    // Update is called once per frame
    void Update()
    {
        if(isHitP1 == 0)
        {
            checkInputP1(refScript1, KeyCode.W, KeyCode.A, KeyCode.S, KeyCode.D);
        }
        else if (isHitP1 == 1)
        {
            checkInputP1(refScript2, KeyCode.W, KeyCode.A, KeyCode.S, KeyCode.D);
        }
        else if (isHitP1 == 2)
        {
            checkInputP1(refScript3, KeyCode.W, KeyCode.A, KeyCode.S, KeyCode.D);
        }

        else if (isHitP1 == 3)
        {
            checkInputP1(refScript4, KeyCode.W, KeyCode.A, KeyCode.S, KeyCode.D);
        }

        if (isHitP2 == 0)
        {
            checkInputP2(refScript5, KeyCode.UpArrow, KeyCode.LeftArrow, KeyCode.DownArrow, KeyCode.RightArrow);
        }
        else if (isHitP2 == 1)
        {
            checkInputP2(refScript6, KeyCode.UpArrow, KeyCode.LeftArrow, KeyCode.DownArrow, KeyCode.RightArrow);
        }
        else if (isHitP2 == 2)
        {
            checkInputP2(refScript7, KeyCode.UpArrow, KeyCode.LeftArrow, KeyCode.DownArrow, KeyCode.RightArrow);
        }

        else if (isHitP2 == 3)
        {
            checkInputP2(refScript8, KeyCode.UpArrow, KeyCode.LeftArrow, KeyCode.DownArrow, KeyCode.RightArrow);
        }
    }

    void checkInputP1(KeyHolder refScriptNum, KeyCode key1, KeyCode key2, KeyCode key3, KeyCode key4)
    {
        if (refScriptNum.keyDir == 1)
        {
            if (Input.GetKeyDown(key1))
            {
                isHitP1++;
                print(isHitP1);
            }
        }
        else if (refScriptNum.keyDir == 2)
        {
            if (Input.GetKeyDown(key2))
            {
                isHitP1++;
                print(isHitP1);
            }
        }
        else if (refScriptNum.keyDir == 3)
        {
            if (Input.GetKeyDown(key3))
            {
                isHitP1++;
                print(isHitP1);
            }
        }
        else if (refScriptNum.keyDir == 4)
        {
            if (Input.GetKeyDown(key4))
            {
                isHitP1++;
                print(isHitP1);
            }
        }
        else
        {
            //isHit--;
        }
    }

    void checkInputP2(KeyHolder refScriptNum, KeyCode key1, KeyCode key2, KeyCode key3, KeyCode key4)
    {
        if (refScriptNum.keyDir == 1)
        {
            if (Input.GetKeyDown(key1))
            {
                isHitP2++;
                print(isHitP2);
            }
        }
        else if (refScriptNum.keyDir == 2)
        {
            if (Input.GetKeyDown(key2))
            {
                isHitP2++;
                print(isHitP2);
            }
        }
        else if (refScriptNum.keyDir == 3)
        {
            if (Input.GetKeyDown(key3))
            {
                isHitP2++;
                print(isHitP2);
            }
        }
        else if (refScriptNum.keyDir == 4)
        {
            if (Input.GetKeyDown(key4))
            {
                isHitP2++;
                print(isHitP2);
            }
        }
        else
        {
            //isHit--;
        }
    }
}
