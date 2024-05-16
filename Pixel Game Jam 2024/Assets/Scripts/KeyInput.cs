using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class KeyInput : MonoBehaviour
{


    public KeyHolder refScript1, refScript2, refScript3, refScript4, refScript5, refScript6, refScript7, refScript8;
    private int isHit = 0;
    private bool hitOnce = false;

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
        if(hitOnce == false && isHit == 0)
        {
            checkWASD(refScript1);
            //hit1 = true;
            /*if (Input.GetKeyUp(KeyCode.W))
            {
                hitOnce = false;
                //print(hitOnce);
            }*/
            hitOnce = false;
        }
        //checkWASD(refScript2);

        else if (hitOnce == false && isHit == 1)
        {
            //print("Key1 hit");
            //isHit = false;
            checkWASD(refScript2);
            //hit2 = true;
            hitOnce = false;
        }


        else if (hitOnce == false && isHit == 2)
        {
                //print("Key2 hit");
                //isHit = false;
            checkWASD(refScript3);
            //hit3 = true;
            hitOnce = false;
        }

        else if (hitOnce == false && isHit == 3)
        {
                    //print("Key3 hit");
                    //isHit = false;
          checkWASD(refScript4);
            //it4 = true;
          hitOnce = false;      
            
        }
        
        //checkKeys(refScript5);
        //checkKeys(refScript6);
        //checkKeys(refScript7);
        //checkKeys(refScript8);
    }

    void checkWASD(KeyHolder refScriptNum)
    {
        if (refScriptNum.keyDir == 1)
        {
            if (Input.GetKeyDown(KeyCode.W))
            {
                print("W Pressed");           
                isHit++;
                print(isHit);
                hitOnce = true;
                print(hitOnce);
            }
            /*if(Input.GetKeyUp(KeyCode.W))
            {
                hitOnce = false;
                print(hitOnce);
            }*/
            //hitOnce = false;
        }
        else if (refScriptNum.keyDir == 2)
        {
            if (Input.GetKeyDown(KeyCode.A))
            {
                print("A Pressed");
                isHit++;
                print(isHit);
                hitOnce = true;
                print(hitOnce);
            }
            /*if (Input.GetKeyUp(KeyCode.A))
            {
                hitOnce = false;
                print(hitOnce);
            }*/
        }
        else if (refScriptNum.keyDir == 3)
        {
            if (Input.GetKeyDown(KeyCode.S))
            {
                print("S Pressed");
                isHit++;
                print(isHit);
                hitOnce = true;
                print(hitOnce);
            }
            if (Input.GetKeyUp(KeyCode.S))
            {
                hitOnce = false;
                print(hitOnce);
            }
        }
        else if (refScriptNum.keyDir == 4)
        {
            if (Input.GetKeyDown(KeyCode.D))
            {
                print("D Pressed");
                isHit++;
                print(isHit);
                hitOnce = true;
                print(hitOnce);
            }
            if (Input.GetKeyUp(KeyCode.D))
            {
                hitOnce = false;
                print(hitOnce);
            }
        }
        else
        {
            //isHit--;
        }
    }
}
