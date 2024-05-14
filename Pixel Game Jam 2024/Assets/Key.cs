using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Key : MonoBehaviour
{

    [SerializeField] GameObject[] keyPrefab;

    // Start is called before the first frame update
    void Start()
    {
        spawnKey();
    }

    // Update is called once per frame
    void Update()
    {
         
    }

    // spawnKey randomly creates key object
    void spawnKey()
    {
        // Copy key prefab objects from given range of keys
        Instantiate(keyPrefab[Random.Range(0, keyPrefab.Length)], transform.position, transform.rotation);
    }
}
