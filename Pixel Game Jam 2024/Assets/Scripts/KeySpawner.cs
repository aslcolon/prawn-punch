using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class KeySpawner : MonoBehaviour
{

    public KeyHolder refIsSpawn4, refIsSpawn8; // Declare KeyHolder to reference KeyHolder script

    // Implement spawn timer
    public double spawnRate = 0.1;
    private float timer = 0;
    
    public int countSeqP1 = 0, countSeqP2 = 0; // Sequence spawned counter

    //private bool round1 = true, round2 = true, round3 = true;

    [SerializeField] GameObject[] keyPrefab; // List for implementing keyPrefab

    // Start is called before the first frame update
    void Start()
    {
        // Initialize refIsSpawn4 as KeyHolder components attached to each key holder
        refIsSpawn4 = GameObject.Find("Key4").GetComponent<KeyHolder>();
        refIsSpawn8 = GameObject.Find("Key8").GetComponent<KeyHolder>();

        spawnRate = 0.1; // Initialize spawnRate

        // Call spawnKey to spawn random keys on start
        spawnKeyP1(); 
        spawnKeyP2();
    }

    // Update is called once per frame
    void Update()
    {
        // If timer is less than spawnRate, increase time
        if (timer < spawnRate)
        {
            timer += Time.deltaTime;
        }
        // Else if sequence is not yet spawned, spawn key and reset timer
        else if (refIsSpawn4.isSpawnP1 == false)
        {
            spawnKeyP1();
            timer = 0;
        }
        else if (refIsSpawn8.isSpawnP2 == false)
        {
            spawnKeyP2();
            timer = 0;
        }
    }

    // spawnKey randomly creates key object
    public void spawnKeyP1()
    {
        if (gameObject.name == "Spawn1" || gameObject.name == "Spawn2" || gameObject.name == "Spawn3" || gameObject.name == "Spawn4")
        {
            // Copy key prefab objects from given range of keys and rename them
            var newPrefab = Instantiate(keyPrefab[Random.Range(0, keyPrefab.Length)], transform.position, transform.rotation);
            newPrefab.name = "Prefab " + gameObject.name;
        
            // Count sequence every time new sequence is spawned
            countSeqP1++; 
            print(countSeqP1);
        }

    }

    public void spawnKeyP2()
    {
        if (gameObject.name == "Spawn5" || gameObject.name == "Spawn6" || gameObject.name == "Spawn7" || gameObject.name == "Spawn8")
        {
            // Copy key prefab objects from given range of keys and rename them
            var newPrefab = Instantiate(keyPrefab[Random.Range(0, keyPrefab.Length)], transform.position, transform.rotation);
            newPrefab.name = "Prefab " + gameObject.name;

            // Count sequence every time new sequence is spawned
            countSeqP2++;
            print(countSeqP2);
        }
    }

    /*void roundPause(int countSeq)
    {
        if (countSeq == 5  && round1 == true)
        {
            for (int i = 0; i < 8; i++)
            {
                Destroy(GameObject.Find("Prefab Spawn" + (i + 1).ToString()));
            }
            spawnRate = 5;
            round1 = false;

            
        }
        else if (round1 == false)
        {

            spawnRate = 0.1;
        }

        if (countSeq == 10 && round2 == true)
        {
            for (int i = 0; i < 8; i++)
            {
                Destroy(GameObject.Find("Prefab Spawn" + (i + 1).ToString()));
            }
            spawnRate = 5;
            round2 = false;


        }
        else if (round2 == false)
        {
            spawnRate = 0.1;
        }

        if (countSeq == 15 && round3 == true)
        {
            for (int i = 0; i < 8; i++)
            {
                Destroy(GameObject.Find("Prefab Spawn" + (i + 1).ToString()));
            }
            spawnRate = 5;
            round3 = false;


        }
        else if (round3 == false)
        {
            spawnRate = 0.1;
        }
    }*/
}
