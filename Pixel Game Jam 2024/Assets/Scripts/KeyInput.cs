using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class KeyInput : MonoBehaviour
{

    // Declare KeyHolder to reference KeyHolder script integers
    public KeyHolder[] refScript = new KeyHolder[8];

    // Declare strings of the key holder names
    private string[] holdName = { "Key1", "Key2", "Key3", "Key4", "Key5", "Key6", "Key7", "Key8" };

    // Declare and initialize holdCount integers that will determine which key holder is active
    private int holdCountP1 = 0, holdCountP2;

   // private SpriteRenderer spriteRen;
   // public Sprite defSprite;
    //public Sprite hitSprite;

    // Start is called before the first frame update
    void Start()
    {
        //spriteRen = GetComponent<SpriteRenderer>();

        // Initialize holdCount integer for P2
        holdCountP2 = holdName.Length / 2;

        // Initialize refScript as KeyHolder components attached to each key holder
        for (int i = 0; i < refScript.Length; i++)
        {
            refScript[i] = GameObject.Find(holdName[i]).GetComponent<KeyHolder>();
        }
    }

    // Update is called once per frame
    void Update()
    {

        // Check P1 key input for ascending key holder
        for(int i = 0; i < holdName.Length / 2; i++)
        {
            if(holdCountP1 == i)
            {
                checkInputP1(refScript[i], KeyCode.W, KeyCode.A, KeyCode.S, KeyCode.D);
                break;
            }
        }

        // Check P2 key input for ascending key holder
        for(int j = holdName.Length / 2; j < holdName.Length; j++)
        {
            if(holdCountP2 == j)
            {
                checkInputP2(refScript[j], KeyCode.UpArrow, KeyCode.LeftArrow, KeyCode.DownArrow, KeyCode.RightArrow);
                break;
            }
        }

    }

    // Check if key input matches key displayed for P1
    void checkInputP1(KeyHolder refScriptNum, KeyCode key1, KeyCode key2, KeyCode key3, KeyCode key4)
    {
        // If keyDir integer declared from KeyHolder script 
        if(refScriptNum.keyDir == 1)
        {
            if(Input.GetKeyDown(key1))
            {
                holdCountP1++;
                print(holdCountP1);
            }
            else if(Input.GetKeyDown(key2) || Input.GetKeyDown(key3) || Input.GetKeyDown(key4)) 
            {
                holdCountP1 = 0;
                print(holdCountP1);
            }
        }
        else if (refScriptNum.keyDir == 2)
        {
            if (Input.GetKeyDown(key2))
            {
                holdCountP1++;
                print(holdCountP1);
            }
            else if (Input.GetKeyDown(key1) || Input.GetKeyDown(key3) || Input.GetKeyDown(key4))
            {
                holdCountP1 = 0;
                print(holdCountP1);
            }
        }
        else if (refScriptNum.keyDir == 3)
        {
            if (Input.GetKeyDown(key3))
            {
                holdCountP1++;
                print(holdCountP1);
            }
            else if (Input.GetKeyDown(key1) || Input.GetKeyDown(key2) || Input.GetKeyDown(key4))
            {
                holdCountP1 = 0;
                print(holdCountP1);
            }
        }
        else if (refScriptNum.keyDir == 4)
        {
            if (Input.GetKeyDown(key4))
            {
                holdCountP1++;
                print(holdCountP1);
            }
            else if (Input.GetKeyDown(key1) || Input.GetKeyDown(key2) || Input.GetKeyDown(key3))
            {
                holdCountP1 = 0;
                print(holdCountP1);
            }
        }
        else
        {
            //isHit--;
        }
    }

    // Check if key input matches key displayed for P2
    void checkInputP2(KeyHolder refScriptNum, KeyCode key1, KeyCode key2, KeyCode key3, KeyCode key4)
    {
        if (refScriptNum.keyDir == 1)
        {
            if (Input.GetKeyDown(key1))
            {
                holdCountP2++;
                print(holdCountP2);
            }
            else if (Input.GetKeyDown(key2) || Input.GetKeyDown(key3) || Input.GetKeyDown(key4))
            {
                holdCountP2 = holdName.Length / 2;
                print(holdCountP2);
            }
        }
        else if (refScriptNum.keyDir == 2)
        {
            if (Input.GetKeyDown(key2))
            {
                holdCountP2++;
                print(holdCountP2);
            }
            else if (Input.GetKeyDown(key1) || Input.GetKeyDown(key3) || Input.GetKeyDown(key4))
            {
                holdCountP2 = holdName.Length / 2;
                print(holdCountP2);
            }
        }
        else if (refScriptNum.keyDir == 3)
        {
            if (Input.GetKeyDown(key3))
            {
                holdCountP2++;
                print(holdCountP2);
            }
            else if (Input.GetKeyDown(key1) || Input.GetKeyDown(key2) || Input.GetKeyDown(key4))
            {
                holdCountP2 = holdName.Length / 2;
                print(holdCountP2);
            }
        }
        else if (refScriptNum.keyDir == 4)
        {
            if (Input.GetKeyDown(key4))
            {
                holdCountP2++;
                print(holdCountP2);
            }
            else if (Input.GetKeyDown(key1) || Input.GetKeyDown(key2) || Input.GetKeyDown(key3))
            {
                holdCountP2 = holdName.Length / 2;
                print(holdCountP2);
            }
        }
        else
        {
            //isHit--;
        }
    }
}
