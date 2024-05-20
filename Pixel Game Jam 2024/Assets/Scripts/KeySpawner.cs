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
        spawnKey("Spawn1", "Spawn2", "Spawn3", "Spawn4", countSeqP1, "Player 1");
        spawnKey("Spawn5", "Spawn6", "Spawn7", "Spawn8", countSeqP2, "Player 1");
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
            spawnKey("Spawn1", "Spawn2", "Spawn3", "Spawn4", countSeqP1, "Player 1");
            timer = 0;
        }
        else if (refIsSpawn8.isSpawn == false)
        {
            spawnKey("Spawn5", "Spawn6", "Spawn7", "Spawn8", countSeqP2, "Player 2");
            timer = 0;
        }
    }

    private void spawnKey(string spaName1, string spaName2, string spaName3, string spaName4, int countSeq, string player)
    {

        //yield return new WaitForSeconds(2);

        // For corresponding player spawn objects
        if (gameObject.name == spaName1 || gameObject.name == spaName2 || gameObject.name == spaName3 || gameObject.name == spaName4)
        {
            // Copy key prefab objects from given range of keys and rename them
            var newPrefab = Instantiate(keyPrefab[Random.Range(0, keyPrefab.Length)], transform.position, transform.rotation);
            newPrefab.name = "Prefab " + gameObject.name;

            // If either player is at zero health
            if (refHealthP1.slider.value == 0 || refHealthP2.slider.value == 0)
            {
                // All key sprites are disabled from display (objects still exist)
                for (int i = 1; i < 9; i++)
                {
                    GameObject.Find("Prefab Spawn" + (i).ToString()).GetComponent<SpriteRenderer>().enabled = false;
                }
            }
 
            countSeq++; // Count sequence every time new sequence is spawned
            Debug.Log(player + ": " + newPrefab.name + " in sequence " + countSeq);
        }
    }
}
