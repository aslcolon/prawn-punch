using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class KeySpawnerP1 : MonoBehaviour
{

    public KeyHolder refIsSpawn4; // Declare KeyHolder to reference KeyHolder script

    // Implement spawn timer
    public double spawnRate = 0.1;
    private float timer = 0;
    
    private int countSeq = 0; // Sequence spawned counter

    [SerializeField] GameObject[] keyPrefab; // List for implementing keyPrefab

    // Start is called before the first frame update
    void Start()
    {
        // Initialize refIsSpawn4 as KeyHolder components attached to each key holder
        refIsSpawn4 = GameObject.Find("Key4").GetComponent<KeyHolder>();

        spawnKey(); // Call spawnKey to spawn random key on start
    }

    // Update is called once per frame
    void Update()
    {
        // If timer is less than spawnRate, increase time
        if (timer < spawnRate)
        {
            timer += Time.deltaTime;
        }
        // Else if sequence is not yet spawned
        else if (refIsSpawn4.isSpawnP1 == false)
        {
            // Spawn sequence and reset timer
            spawnKey();
            timer = 0;
        }
    }

    // spawnKey randomly creates key object
    public void spawnKey()
    {
        // Copy key prefab objects from given range of keys and rename them
        var newPrefab = Instantiate(keyPrefab[Random.Range(0, keyPrefab.Length)], transform.position, transform.rotation);
        newPrefab.name = "Prefab " + gameObject.name;
        
        // Count sequence every time new sequence is spawned
        countSeq++; 
        print(countSeq);
    }
}
