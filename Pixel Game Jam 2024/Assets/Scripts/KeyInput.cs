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

    private bool isHitP1 = false, isHitP2 = false, wrongInputP1 = false, wrongInputP2 = false;

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

                if(isHitP1 == true)
                {
                    GameObject.Find("Prefab Spawn" + (i + 1).ToString()).GetComponent<SpriteRenderer>().enabled = false;
                    isHitP1 = false;
                }

                else if(wrongInputP1 == true)
                {
                    for(int j = 0; j < holdName.Length / 2; j++)
                    {
                        if(GameObject.Find("Prefab Spawn" + (j + 1).ToString()).GetComponent<SpriteRenderer>().enabled == false)
                        {
                            GameObject.Find("Prefab Spawn" + (j + 1).ToString()).GetComponent<SpriteRenderer>().enabled = true;
                        }
                    }
                    
                }
                
                break;
            }
        }

        // Check P2 key input for ascending key holder
        for(int j = holdName.Length / 2; j < holdName.Length; j++)
        {
            if(holdCountP2 == j)
            {
                checkInputP2(refScript[j], KeyCode.UpArrow, KeyCode.LeftArrow, KeyCode.DownArrow, KeyCode.RightArrow);

                if (isHitP2 == true)
                {
                    GameObject.Find("Prefab Spawn" + (j + 1).ToString()).GetComponent<SpriteRenderer>().enabled = false;
                    isHitP2 = false;
                }

                else if (wrongInputP2 == true)
                {
                    for (int k = holdName.Length / 2; k < refScript.Length; k++)
                    {
                        if (GameObject.Find("Prefab Spawn" + (k + 1).ToString()).GetComponent<SpriteRenderer>().enabled == false)
                        {
                            GameObject.Find("Prefab Spawn" + (k + 1).ToString()).GetComponent<SpriteRenderer>().enabled = true;
                        }
                    }

                }
                break;
            }
        }

    }

    // Check if key input matches key displayed for P1
    void checkInputP1(KeyHolder refScriptNum, KeyCode key1, KeyCode key2, KeyCode key3, KeyCode key4)
    {

        // If keyDir integer declared from KeyHolder script 
        if (refScriptNum.keyDir == 1)
        {
            if (Input.GetKeyDown(key1))
            {
                holdCountP1++;
                print(holdCountP1);
                isHitP1 = true;
                wrongInputP1 = false;
            }
            else if(Input.GetKeyDown(key2) || Input.GetKeyDown(key3) || Input.GetKeyDown(key4)) 
            {
                holdCountP1 = 0;
                print(holdCountP1);
                wrongInputP1 = true;
            }
        }
        else if (refScriptNum.keyDir == 2)
        {
            if (Input.GetKeyDown(key2))
            {
                holdCountP1++;
                print(holdCountP1);
                isHitP1 = true;
                wrongInputP1 = false;
            }
            else if (Input.GetKeyDown(key1) || Input.GetKeyDown(key3) || Input.GetKeyDown(key4))
            {
                holdCountP1 = 0;
                print(holdCountP1);
                wrongInputP1 = true;
            }
        }
        else if (refScriptNum.keyDir == 3)
        {
            if (Input.GetKeyDown(key3))
            {
                holdCountP1++;
                print(holdCountP1);
                isHitP1 = true;
                wrongInputP1 = false;
            }
            else if (Input.GetKeyDown(key1) || Input.GetKeyDown(key2) || Input.GetKeyDown(key4))
            {
                holdCountP1 = 0;
                print(holdCountP1);
                wrongInputP1 = true;
            }
        }
        else if (refScriptNum.keyDir == 4)
        {
            if (Input.GetKeyDown(key4))
            {
                holdCountP1++;
                print(holdCountP1);
                isHitP1 = true;
                wrongInputP1 = false;
            }
            else if (Input.GetKeyDown(key1) || Input.GetKeyDown(key2) || Input.GetKeyDown(key3))
            {
                holdCountP1 = 0;
                print(holdCountP1);
                wrongInputP1 = true;
            }
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
                isHitP2 = true;
                wrongInputP2 = false;
            }
            else if (Input.GetKeyDown(key2) || Input.GetKeyDown(key3) || Input.GetKeyDown(key4))
            {
                holdCountP2 = holdName.Length / 2;
                print(holdCountP2);
                wrongInputP2 = true;
            }
        }
        else if (refScriptNum.keyDir == 2)
        {
            if (Input.GetKeyDown(key2))
            {
                holdCountP2++;
                print(holdCountP2);
                isHitP2 = true;
                wrongInputP2 = false;
            }
            else if (Input.GetKeyDown(key1) || Input.GetKeyDown(key3) || Input.GetKeyDown(key4))
            {
                holdCountP2 = holdName.Length / 2;
                print(holdCountP2);
                wrongInputP2 = true;
            }
        }
        else if (refScriptNum.keyDir == 3)
        {
            if (Input.GetKeyDown(key3))
            {
                holdCountP2++;
                print(holdCountP2);
                isHitP2 = true;
                wrongInputP2 = false;
            }
            else if (Input.GetKeyDown(key1) || Input.GetKeyDown(key2) || Input.GetKeyDown(key4))
            {
                holdCountP2 = holdName.Length / 2;
                print(holdCountP2);
                wrongInputP2 = true;
            }
        }
        else if (refScriptNum.keyDir == 4)
        {
            if (Input.GetKeyDown(key4))
            {
                holdCountP2++;
                print(holdCountP2);
                isHitP2 = true;
                wrongInputP2 = false;
            }
            else if (Input.GetKeyDown(key1) || Input.GetKeyDown(key2) || Input.GetKeyDown(key3))
            {
                holdCountP2 = holdName.Length / 2;
                print(holdCountP2);
                wrongInputP2 = true;
            }
        }
    }
}
