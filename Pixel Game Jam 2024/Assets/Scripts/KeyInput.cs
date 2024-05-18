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

    // Declare bool for P1 and P2 for checking inputs
    // isHit checks if input is correct while wrongInput checks if input is incorrect
    private bool isHitP1 = false, isHitP2 = false, wrongInputP1 = false, wrongInputP2 = false;

    AudioManager audioManager;

    // Start is called before the first frame update
    void Start()
    {
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
        for (int i = 0; i < holdName.Length / 2; i++)
        { 
            if (holdCountP1 == i)
            {
                // Check input for corresponding key holder to the referenced key displayed 
                checkInputP1(refScript[i], KeyCode.W, KeyCode.A, KeyCode.S, KeyCode.D);

                // If input is correct
                if (isHitP1 == true)
                {
                    // Disable SpriteRenderer to corresponding sprite and set isHit back to false
                    GameObject.Find("Prefab Spawn" + (i + 1).ToString()).GetComponent<SpriteRenderer>().enabled = false;
                    isHitP1 = false;
                }
                // Else if input is incorrect
                else if (wrongInputP1 == true)
                {
                    // For all key sprites within sequence
                    for (int j = 0; j < holdName.Length / 2; j++)
                    {
                        // If sprites are disabled then enable them
                        if (GameObject.Find("Prefab Spawn" + (j + 1).ToString()).GetComponent<SpriteRenderer>().enabled == false)
                        {
                            GameObject.Find("Prefab Spawn" + (j + 1).ToString()).GetComponent<SpriteRenderer>().enabled = true;
                        }
                    }
                    
                }
                break;
            }
            
        }

        // Once the sequence is complete and P1 reaches last key holder
        if (holdCountP1 == 4)
        {
            holdCountP1 = 0; // Reset key holder number
            // Destroy all key game objects within sequence 
            for (int i = 0; i < holdName.Length / 2; i++)
            {
                Destroy(GameObject.Find("Prefab Spawn" + (i + 1).ToString()));
            }
        }

        // Check P2 key input for ascending key holder
        for (int j = holdName.Length / 2; j < holdName.Length; j++)
        {
            if (holdCountP2 == j)
            {
                // Check input for corresponding key holder to the referenced key displayed
                checkInputP2(refScript[j], KeyCode.UpArrow, KeyCode.LeftArrow, KeyCode.DownArrow, KeyCode.RightArrow);

                // If input is correct
                if (isHitP2 == true)
                {
                    // Disable SpriteRenderer to corresponding sprite and set isHit back to false
                    GameObject.Find("Prefab Spawn" + (j + 1).ToString()).GetComponent<SpriteRenderer>().enabled = false;
                    isHitP2 = false;
                }
                // Else if input is incorrect
                else if (wrongInputP2 == true)
                {
                    // For all key sprites within sequence
                    for (int k = holdName.Length / 2; k < holdName.Length; k++)
                    {
                        // If sprites are disabled then enable them
                        if (GameObject.Find("Prefab Spawn" + (k + 1).ToString()).GetComponent<SpriteRenderer>().enabled == false)
                        {
                            GameObject.Find("Prefab Spawn" + (k + 1).ToString()).GetComponent<SpriteRenderer>().enabled = true;
                        }
                    }
                }
                break;
            }
        }

        // Once the sequence is complete and P2 reaches last key holder
        if (holdCountP2 == 8)
        {
            holdCountP2 = holdName.Length / 2; // Reset key holder number
            // Destroy all key game objects within sequence
            for (int i = holdName.Length / 2; i < holdName.Length; i++)
            {
                Destroy(GameObject.Find("Prefab Spawn" + (i + 1).ToString()));
            }
        }
    }

    private void Awake()
    {
        audioManager = GameObject.FindGameObjectWithTag("Audio").GetComponent<AudioManager>();
    }

    // Check if key input matches key displayed for P1
    void checkInputP1(KeyHolder refScriptNum, KeyCode key1, KeyCode key2, KeyCode key3, KeyCode key4)
    {
        // If keyDir integer declared from KeyHolder script 
        if (refScriptNum.keyDirP1 == 1)
        {
            if (Input.GetKeyDown(key1))
            {
                holdCountP1++;
                print(holdCountP1);
                isHitP1 = true;
                wrongInputP1 = false;
                audioManager.PlaySFX(audioManager.bubblePop);
            }
            else if(Input.GetKeyDown(key2) || Input.GetKeyDown(key3) || Input.GetKeyDown(key4)) 
            {
                holdCountP1 = 0;
                print(holdCountP1);
                wrongInputP1 = true;
            }
        }
        else if (refScriptNum.keyDirP1 == 2)
        {
            if (Input.GetKeyDown(key2))
            {
                holdCountP1++;
                print(holdCountP1);
                isHitP1 = true;
                wrongInputP1 = false;
                audioManager.PlaySFX(audioManager.bubblePop);
            }
            else if (Input.GetKeyDown(key1) || Input.GetKeyDown(key3) || Input.GetKeyDown(key4))
            {
                holdCountP1 = 0;
                print(holdCountP1);
                wrongInputP1 = true;
            }
        }
        else if (refScriptNum.keyDirP1 == 3)
        {
            if (Input.GetKeyDown(key3))
            {
                holdCountP1++;
                print(holdCountP1);
                isHitP1 = true;
                wrongInputP1 = false;
                audioManager.PlaySFX(audioManager.bubblePop);
            }
            else if (Input.GetKeyDown(key1) || Input.GetKeyDown(key2) || Input.GetKeyDown(key4))
            {
                holdCountP1 = 0;
                print(holdCountP1);
                wrongInputP1 = true;
            }
        }
        else if (refScriptNum.keyDirP1 == 4)
        {
            if (Input.GetKeyDown(key4))
            {
                holdCountP1++;
                print(holdCountP1);
                isHitP1 = true;
                wrongInputP1 = false;
                audioManager.PlaySFX(audioManager.bubblePop);
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
        if (refScriptNum.keyDirP2 == 1)
        {
            if (Input.GetKeyDown(key1))
            {
                holdCountP2++;
                print(holdCountP2);
                isHitP2 = true;
                wrongInputP2 = false;
                audioManager.PlaySFX(audioManager.bubblePop);
            }
            else if (Input.GetKeyDown(key2) || Input.GetKeyDown(key3) || Input.GetKeyDown(key4))
            {
                holdCountP2 = holdName.Length / 2;
                print(holdCountP2);
                wrongInputP2 = true;
            }
        }
        else if (refScriptNum.keyDirP2 == 2)
        {
            if (Input.GetKeyDown(key2))
            {
                holdCountP2++;
                print(holdCountP2);
                isHitP2 = true;
                wrongInputP2 = false;
                audioManager.PlaySFX(audioManager.bubblePop);
            }
            else if (Input.GetKeyDown(key1) || Input.GetKeyDown(key3) || Input.GetKeyDown(key4))
            {
                holdCountP2 = holdName.Length / 2;
                print(holdCountP2);
                wrongInputP2 = true;
            }
        }
        else if (refScriptNum.keyDirP2 == 3)
        {
            if (Input.GetKeyDown(key3))
            {
                holdCountP2++;
                print(holdCountP2);
                isHitP2 = true;
                wrongInputP2 = false;
                audioManager.PlaySFX(audioManager.bubblePop);
            }
            else if (Input.GetKeyDown(key1) || Input.GetKeyDown(key2) || Input.GetKeyDown(key4))
            {
                holdCountP2 = holdName.Length / 2;
                print(holdCountP2);
                wrongInputP2 = true;
            }
        }
        else if (refScriptNum.keyDirP2 == 4)
        {
            if (Input.GetKeyDown(key4))
            {
                holdCountP2++;
                print(holdCountP2);
                isHitP2 = true;
                wrongInputP2 = false;
                audioManager.PlaySFX(audioManager.bubblePop);
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
