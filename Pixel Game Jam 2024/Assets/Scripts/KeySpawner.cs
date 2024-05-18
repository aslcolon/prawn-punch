using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeySpawner : MonoBehaviour
{
    public KeyHolder refIsSpawn; // Reference isKey bool from KeyHolder script

    [SerializeField] GameObject[] keyPrefab;


    // Start is called before the first frame update
    void Start()
    {
        spawnKey(); // Call spawnKey to spawn random key on start
    }

    // Update is called once per frame
    void Update()
    {
        if(refIsSpawn.isSpawnP1 == false || refIsSpawn.isSpawnP2 == false)
        {
            print("should spawn");
            spawnKey();
        }

        //spawnKey();
    }

    // spawnKey randomly creates key object
    public void spawnKey()
    {
        // Copy key prefab objects from given range of keys
        var newPrefab = Instantiate(keyPrefab[Random.Range(0, keyPrefab.Length)], transform.position, transform.rotation);
        newPrefab.name = "Prefab " + gameObject.name;
    }
}
