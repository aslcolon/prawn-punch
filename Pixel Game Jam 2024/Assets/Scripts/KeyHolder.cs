using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyHolder : MonoBehaviour
{

    // Declare bool for key objects within collision area
    public bool isUp, isLeft, isDown, isRight;

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
        // If tag is "Up Key", isUp is true
        if (other.gameObject.tag == "Up Key")
        {
            isUp = true;
        }
        else if (other.gameObject.tag == "Left Key")
        {
            isLeft = true;
        }
        else if (other.gameObject.tag == "Down Key")
        {
            isDown = true;
        }
        else if (other.gameObject.tag == "Right Key")
        {
            isRight = true;
        }

    }

    /*private void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.tag == "Up Key")
        {
            print("No up key");
            isUp = false;
        }
    }*/
}
