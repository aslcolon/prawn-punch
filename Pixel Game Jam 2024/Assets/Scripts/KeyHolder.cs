using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyHolder : MonoBehaviour
{

    // Declare bool for key objects within collision area
    public int keyDirP1, keyDirP2;
    public bool isSpawnP1 = true, isSpawnP2 = true;

    //private string[] letterTag = { "W Key", "A Key", "S Key", "D Key" };
    //private string[] arrowTag = { "Up Key", "Left Key", "Down Key", "Right Key" };

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

    }

    // Check which key is displayed when object enters collision area
    private void OnTriggerEnter2D(Collider2D other)
    {
        // For each tag checked, bool is true for the corresponding key
        // 1-Up, 2-Left, 3-Down, 4-Right
        if (other.gameObject.CompareTag("W Key"))
        {
            keyDirP1 = 1;
            isSpawnP2 = false;
        }
        else if (other.gameObject.CompareTag("A Key"))
        {
            keyDirP1 = 2;
            isSpawnP2 = false;
        }
        else if (other.gameObject.CompareTag("S Key"))
        {
            keyDirP1 = 3;
            isSpawnP2 = false;
        }
        else if (other.gameObject.CompareTag("D Key"))
        {
            keyDirP1 = 4;
            isSpawnP2 = false;
        }

        if (other.gameObject.CompareTag("Up Key"))
        {
            keyDirP2 = 1;
            isSpawnP1 = false;
        }
        else if (other.gameObject.CompareTag("Left Key"))
        {
            keyDirP2 = 2;
            isSpawnP1 = false;
        }
        else if (other.gameObject.CompareTag("Down Key"))
        {
            keyDirP2 = 3;
            isSpawnP1 = false;
        }
        else if (other.gameObject.CompareTag("Right Key"))
        {
            keyDirP2 = 4;
            isSpawnP1 = false;
        }

        /*for (int i = 0; i < letterTag.Length; i++)
        {
            if (other.gameObject.tag == letterTag[i])
            {
                keyDirP1 = i + 1;
                isSpawnP2 = false;
            }
        }

        for (int i = 0; i < arrowTag.Length;i++)
        {
            if (other.gameObject.tag == arrowTag[i])
            {
                keyDirP2 = i + 1;
                isSpawnP1 = false;
            }
        }*/

    }

    private void OnTriggerExit2D(Collider2D other)
    {

        /*for(int i = 0; i < 4; i++)
        {
            if(other.gameObject.name == "Prefab Spawn" + (i + 1).ToString())
            {
                isSpawnP1 = false;
            }
        }*/

        if (other.gameObject.CompareTag("W Key") || other.gameObject.CompareTag("A Key") || other.gameObject.CompareTag("S Key") || other.gameObject.CompareTag("D Key"))
        {
            isSpawnP1 = false;
        }

        if (other.gameObject.CompareTag("Up Key") || other.gameObject.CompareTag("Left Key") || other.gameObject.CompareTag("Down Key") || other.gameObject.CompareTag("Right Key"))
        {
            isSpawnP2 = false;
        }

        /*if (other.gameObject.name == "Prefab Spawn1")
        {
            isSpawnP1 = false;
        }*/

    }
}
