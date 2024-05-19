using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting.FullSerializer;
using UnityEngine;

public class KeyHolder : MonoBehaviour
{

    public int keyDirP1; // Declare key direction with corresponding integer
    public bool isSpawnP1 = true, isSpawnP2 = true; // Declare bool for key objects within collision area

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
        if (other.gameObject.CompareTag("W Key") || other.gameObject.CompareTag("Up Key"))
        {
            keyDirP1 = 1;
        }
        else if (other.gameObject.CompareTag("A Key") || other.gameObject.CompareTag("Left Key"))
        {
            keyDirP1 = 2;
        }
        else if (other.gameObject.CompareTag("S Key") || other.gameObject.CompareTag("Down Key"))
        {
            keyDirP1 = 3;
        }
        else if (other.gameObject.CompareTag("D Key") || other.gameObject.CompareTag("Right Key"))
        {
            keyDirP1 = 4;
        }

        /*if (other.gameObject.CompareTag("Up Key") && (gameObject.name == "Key5" || gameObject.name == "Key6" || gameObject.name == "Key7" || gameObject.name == "Key8"))
        {
            keyDirP1 = 1;
        }
        else if (other.gameObject.CompareTag("Left Key") && (gameObject.name == "Key5" || gameObject.name == "Key6" || gameObject.name == "Key7" || gameObject.name == "Key8"))
        {
            keyDirP1 = 2;
        }
        else if (other.gameObject.CompareTag("Down Key") && (gameObject.name == "Key5" || gameObject.name == "Key6" || gameObject.name == "Key7" || gameObject.name == "Key8"))
        {
            keyDirP1 = 3;
        }
        else if (other.gameObject.CompareTag("Right Key") && (gameObject.name == "Key5" || gameObject.name == "Key6" || gameObject.name == "Key7" || gameObject.name == "Key8"))
        {
            keyDirP1 = 4;
        }*/
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
