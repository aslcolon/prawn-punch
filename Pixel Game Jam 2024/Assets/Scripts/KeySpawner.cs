using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Key : MonoBehaviour
{

    public KeyHolder refIsSpawn; // Reference isKey bool from KeyHolder script
    private string[] holdName = { "Key1", "Key2", "Key3", "Key4", "Key5", "Key6", "Key7", "Key8" };

    [SerializeField] GameObject[] keyPrefab;


    // Start is called before the first frame update
    void Start()
    {

        for (int i = 0; i < holdName.Length; i++)
        {
            refIsSpawn = GameObject.Find(holdName[i]).GetComponent<KeyHolder>();
        }
        spawnKey(); // Call spawnKey to spawn random key on start
    }

    // Update is called once per frame
    void Update()
    {
        if(refIsSpawn.isSpawnP1 == false)
        {
            spawnKey();
        }
    }

    // spawnKey randomly creates key object
    void spawnKey()
    {
        // Copy key prefab objects from given range of keys
        var newPrefab = Instantiate(keyPrefab[Random.Range(0, keyPrefab.Length)], transform.position, transform.rotation);
        newPrefab.name = "Prefab " + gameObject.name;
    }
}
