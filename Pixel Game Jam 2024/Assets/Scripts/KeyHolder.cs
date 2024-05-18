using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyHolder : MonoBehaviour
{

    public int keyDirP1, keyDirP2; // Declare key direction with corresponding integer
    public bool isSpawnP1 = true, isSpawnP2 = true; // Declare bool for key objects within collision area

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
        // If last key of sequence enters collision area, sequence is spawned
        if (other.gameObject.name == "Prefab Spawn4")
        {
            isSpawnP1 = true;
        }
        if (other.gameObject.name == "Prefab Spawn8")
        {
            isSpawnP2 = true;
        }

        // For each tag compared, key direction is determined
        // 1-Up, 2-Left, 3-Down, 4-Right
        if (other.gameObject.CompareTag("W Key"))
        {
            keyDirP1 = 1;
        }
        else if (other.gameObject.CompareTag("A Key"))
        {
            keyDirP1 = 2;
        }
        else if (other.gameObject.CompareTag("S Key"))
        {
            keyDirP1 = 3;
        }
        else if (other.gameObject.CompareTag("D Key"))
        {
            keyDirP1 = 4;
        }

        if (other.gameObject.CompareTag("Up Key"))
        {
            keyDirP2 = 1;
        }
        else if (other.gameObject.CompareTag("Left Key"))
        {
            keyDirP2 = 2;
        }
        else if (other.gameObject.CompareTag("Down Key"))
        {
            keyDirP2 = 3;
        }
        else if (other.gameObject.CompareTag("Right Key"))
        {
            keyDirP2 = 4;
        }
    }

    // Check when sequence exits collision area and destroyed
    private void OnTriggerExit2D(Collider2D other)
    {
        // If last key of sequence exits collision area, sequence is not spawned
        if (other.gameObject.name == "Prefab Spawn4")
        {
            isSpawnP1 = false;
        }

        if (other.gameObject.name == "Prefab Spawn8")
        {
            isSpawnP2 = false;
        }
    }
}
