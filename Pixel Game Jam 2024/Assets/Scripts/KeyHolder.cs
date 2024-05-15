using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyHolder : MonoBehaviour
{

    public bool isUp; // Declare bool for key object within collision area

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        print("Collision");
        if (other.gameObject.tag == "Up Key")
        {
            print("Up key");
            isUp = true;
        }
     
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        print("No collision");
        if (other.gameObject.tag == "Up Key")
        {
            print("No up key");
            isUp = false;
        }
    }
}
