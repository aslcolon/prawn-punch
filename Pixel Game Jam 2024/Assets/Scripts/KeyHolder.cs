using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting.FullSerializer;
using UnityEngine;

public class KeyHolder : MonoBehaviour
{
    public int numOfKeys; // Set number of keys within a sequence

    public int keyDir; // Declare key direction with corresponding integer
    public bool isSpawn = true; // Declare bool for key objects within collision area

    // Create arrays for tag strings
    private string[] letterTag = { "W Key", "A Key", "S Key", "D Key" };
    private string[] arrowTag = { "Up Key", "Left Key", "Down Key", "Right Key" };

    // Check which key is displayed when object enters collision area
    private void OnTriggerEnter2D(Collider2D other)
    {
        // If last key of sequence enters collision area, sequence is spawned
        checkIsSpawn(other, true, "Prefab Spawn4", "Prefab Spawn8");
        
        // Declare key direction on tag of key
        tagToKey(other, letterTag, arrowTag);
    }

    // Check when sequence exits collision area and destroyed
    private void OnTriggerExit2D(Collider2D other)
    {
        // If last key of sequence exits collision area, sequence is not spawned
        checkIsSpawn(other, false, "Prefab Spawn4", "Prefab Spawn8");
    }

    // Checks if sequence is spawned based on the last key entering or exiting the collision area
    private void checkIsSpawn(Collider2D other, bool condition, string prefab1, string prefab2)
    {
        if (other.gameObject.name == prefab1 || other.gameObject.name == prefab2)
        {
            isSpawn = condition;
        }
    }

    // Declare key direction when corresponding tag enters collision area
    private void tagToKey(Collider2D other, string[] tag1, string[] tag2)
    {
        for (int i = 0; i < numOfKeys; i++)
        {
            if (other.gameObject.CompareTag(tag1[i]) || other.gameObject.CompareTag(tag2[i]))
            {
                keyDir = i + 1;
            }
        }
    }
}
