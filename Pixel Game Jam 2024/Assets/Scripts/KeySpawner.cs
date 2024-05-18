using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeySpawner : MonoBehaviour
{
    public KeyHolderP1 refIsSpawn; // Reference isKey bool from KeyHolder script
    //private string[] holdName = { "Key1", "Key2", "Key3", "Key4"};

    [SerializeField] GameObject[] keyPrefab;


    // Start is called before the first frame update
    void Start()
    {
        /*for (int i = 0; i < holdName.Length; i++)
        {
            refIsSpawn[i] = GameObject.Find(holdName[""]).GetComponent<KeyHolderP1>();
        }*/

        refIsSpawn = GameObject.Find("Key4").GetComponent<KeyHolderP1>();

        spawnKey(); // Call spawnKey to spawn random key on start
    }

    // Update is called once per frame
    void Update()
    {

        /*for (int i = 0; i < holdName.Length; i++)
        {
            if (refIsSpawn[i].isSpawnP1 == false)
            {
                //print("should spawn");
                spawnKey();
            }
        }*/

        if (refIsSpawn.isSpawnP1 == false)
        {
            //print("should spawn");
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
