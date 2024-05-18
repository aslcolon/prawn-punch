using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class KeySpawner : MonoBehaviour
{
    //public KeyHolderP1 refIsSpawn1; // Reference isKey bool from KeyHolder script
    //private string[] holdName = { "Key1", "Key2", "Key3", "Key4"};
    //public KeyHolderP1 refIsSpawn2;
    //public KeyHolderP1 refIsSpawn3;
    public KeyHolderP1 refIsSpawn4;

    public float spawnRate = 1;
    private float timer = 0;

    //private bool spawnOnce = false;

    [SerializeField] GameObject[] keyPrefab;


    // Start is called before the first frame update
    void Start()
    {
        //refIsSpawn1 = GameObject.Find("Key1").GetComponent<KeyHolderP1>();
        //refIsSpawn2 = GameObject.Find("Key2").GetComponent<KeyHolderP1>();
        //refIsSpawn3 = GameObject.Find("Key3").GetComponent<KeyHolderP1>();
        refIsSpawn4 = GameObject.Find("Key4").GetComponent<KeyHolderP1>();

        spawnKey(); // Call spawnKey to spawn random key on start
    }

    // Update is called once per frame
    void Update()
    {

        if (timer < spawnRate)
        {
            timer += Time.deltaTime;
        }
        else if (refIsSpawn4.isSpawnP1 == false)
        {
            //print("should spawn");
            spawnKey();
            //spawnOnce = true;
            timer = 0;
        }

        /*if (refIsSpawn2.isSpawnP1 == false)
        {
            //print("should spawn");
            spawnKey();
            //spawnOnce = true;
        }
        if (refIsSpawn3.isSpawnP1 == false)
        {
            //print("should spawn");
            spawnKey();
            //spawnOnce = true;
        }
        if (refIsSpawn4.isSpawnP1 == false)
        {
            //print("should spawn");
            spawnKey();
            //spawnOnce = true;
        }*/

        /*else if(refIsSpawn.isSpawnP1 == false)
        {
            spawnOnce = false;
        }*/

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
