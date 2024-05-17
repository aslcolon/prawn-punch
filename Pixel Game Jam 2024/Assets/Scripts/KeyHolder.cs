using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyHolder : MonoBehaviour
{

    // Declare bool for key objects within collision area
    public int keyDir;
    public bool isSpawnP1 = true, isSpawnP2 = true;

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
        if (other.gameObject.tag == "Up Key")
        {
            keyDir = 1;
        }
        else if (other.gameObject.tag == "Left Key")
        {
            keyDir = 2;
        }
        else if (other.gameObject.tag == "Down Key")
        {
            keyDir = 3;
        }
        else if (other.gameObject.tag == "Right Key")
        {
            keyDir = 4;
        }

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

        if (other.gameObject.tag == "Up Key" || other.gameObject.tag == "Left Key" || other.gameObject.tag == "Down Key" || other.gameObject.tag == "Right Key")
        {
            isSpawnP1 = false;
        }
        
    }
}
