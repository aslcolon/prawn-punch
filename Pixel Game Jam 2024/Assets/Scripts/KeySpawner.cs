using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class KeySpawner : MonoBehaviour
{
    
    [SerializeField] GameObject[] keyPrefab; // List for implementing keyPrefab

    public KeyHolder refIsSpawn4, refIsSpawn8; // Declare KeyHolder to reference KeyHolder script

    // Implement spawn timer
    public double spawnRate = 0.1;
    private float timer = 0;
    
    public int countSeqP1 = 0, countSeqP2 = 0; // Sequence spawned counter
   
    public HealthBar refHealthP1, refHealthP2;

    // Start is called before the first frame update
    void Start()
    {
        // Initialize refIsSpawn as KeyHolder components attached to each key holder
        refIsSpawn4 = GameObject.Find("Key4").GetComponent<KeyHolder>();
        refIsSpawn8 = GameObject.Find("Key8").GetComponent<KeyHolder>();

        // Initialize refHealth as HealthBar componenets attached to each health bar
        refHealthP1 = GameObject.Find("Health bar P1").GetComponent<HealthBar>();
        refHealthP2 = GameObject.Find("Health bar P2").GetComponent<HealthBar>();

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
        else if (refIsSpawn4.isSpawn == false)
        {
            spawnKeyP1();
            timer = 0;
        }
        else if (refIsSpawn8.isSpawn == false)
        {
            spawnKeyP2();
            timer = 0;
        }

    }

    // spawnKey randomly creates key object
    public void spawnKeyP1()
    {
        // For P1 spawn objects
        if (gameObject.name == "Spawn1" || gameObject.name == "Spawn2" || gameObject.name == "Spawn3" || gameObject.name == "Spawn4")
        {
            // Copy key prefab objects from given range of keys and rename them
            var newPrefabP1 = Instantiate(keyPrefab[Random.Range(0, keyPrefab.Length)], transform.position, transform.rotation);
            newPrefabP1.name = "Prefab " + gameObject.name;

            // If either player is at zero health
            if (refHealthP1.slider.value == 0 || refHealthP2.slider.value == 0)
            {
                for (int i = 1; i < 9; i++)
                {
                    // All key sprites are disabled from display (objects still exist)
                    GameObject.Find("Prefab Spawn" + (i).ToString()).GetComponent<SpriteRenderer>().enabled = false;
                }
            }
            countSeqP1++; // Count sequence every time new sequence is spawned
            Debug.Log("Player 1: " + newPrefabP1.name + " in sequence " + countSeqP1);
        }
    }

    // spawnKey randomly creates key object
    public void spawnKeyP2()
    {
        // For P2 spawn objects
        if (gameObject.name == "Spawn5" || gameObject.name == "Spawn6" || gameObject.name == "Spawn7" || gameObject.name == "Spawn8")
        {
            // Copy key prefab objects from given range of keys and rename them
            var newPrefabP2 = Instantiate(keyPrefab[Random.Range(0, keyPrefab.Length)], transform.position, transform.rotation);
            newPrefabP2.name = "Prefab " + gameObject.name;

            // If either player is at zero health
            if (refHealthP1.slider.value == 0 || refHealthP2.slider.value == 0)
            {
                // All key sprites are disabled from display (objects still exist)
                for (int i = 1; i < 9; i++)
                {
                    GameObject.Find("Prefab Spawn" + (i).ToString()).GetComponent<SpriteRenderer>().enabled = false;
                }
            }
            countSeqP2++; // Count sequence every time new sequence is spawned
            Debug.Log("Player 2: " + newPrefabP2.name + " in sequence " + countSeqP2);
        }  
    }
}
