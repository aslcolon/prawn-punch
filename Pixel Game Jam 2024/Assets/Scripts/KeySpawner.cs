using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Key : MonoBehaviour
{

    public KeyHolder isKey; // Reference isKey bool from KeyHolder script

    [SerializeField] GameObject[] keyPrefab;

    // Start is called before the first frame update
    void Start()
    {
        spawnKey(); // Call spawnKey to spawn random key on start
    }

    // Update is called once per frame
    void Update()
    {
        // If no key object is within collision area, spawn new object
        /*if(isKey == false)
        {
            spawnKey();
        }*/
    }

    // spawnKey randomly creates key object
    void spawnKey()
    {
        // Copy key prefab objects from given range of keys
        Instantiate(keyPrefab[Random.Range(0, keyPrefab.Length)], transform.position, transform.rotation);
    }
}
