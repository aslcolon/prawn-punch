using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimation : MonoBehaviour
{
    public Animator animator;

    public KeyHolder refIsSpawn4, refIsSpawn8;

    // Start is called before the first frame update
    void Start()
    {
        refIsSpawn4 = GameObject.Find("Key4").GetComponent<KeyHolder>();
        refIsSpawn8 = GameObject.Find("Key8").GetComponent<KeyHolder>();
    }

    // Update is called once per frame
    void Update()
    {
        if (gameObject.name == "P1")
        {
            if (refIsSpawn4.isSpawnP1 == false)
            {
                animator.SetBool("isPunchingP1", true);
            }
            else if (refIsSpawn4.isSpawnP1 == true)
            {
                animator.SetBool("isPunchingP1", false);
            }

            if (refIsSpawn8.isSpawnP2 == false)
            {
                animator.SetBool("isHurtP1", true);
            }
            else if (refIsSpawn8.isSpawnP2 == true)
            {
                animator.SetBool("isHurtP1", false);
            }
        }

        if (gameObject.name == "P2")
        {
            if (refIsSpawn8.isSpawnP2 == false)
            {
                animator.SetBool("isPunchingP2", true);
            }
            else if (refIsSpawn8.isSpawnP2 == true)
            {
                animator.SetBool("isPunchingP2", false);
            }

            if (refIsSpawn4.isSpawnP1 == false)
            {
                animator.SetBool("isHurtP2", true);
            }
            else if (refIsSpawn4.isSpawnP1 == true)
            {
                animator.SetBool("isHurtP2", false);
            }
        }
    }

}
