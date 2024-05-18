using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimation : MonoBehaviour
{
    //AudioManager audioManager;

    public Animator animator;

    public KeyHolder refIsSpawn4, refIsSpawn8;

    public HealthBar refHealthP1, refHealthP2;

    // Start is called before the first frame update
    void Start()
    {
        refIsSpawn4 = GameObject.Find("Key4").GetComponent<KeyHolder>();
        refIsSpawn8 = GameObject.Find("Key8").GetComponent<KeyHolder>();

        refHealthP1 = GameObject.Find("Health bar P1").GetComponent<HealthBar>();
        refHealthP2 = GameObject.Find("Health bar P2").GetComponent<HealthBar>();
    }

    // Update is called once per frame
    void Update()
    {
        if (gameObject.name == "P1")
        {
            if (refIsSpawn4.isSpawnP1 == false)
            {
                animator.SetBool("isPunchingP1", true);
                //audioManager.PlaySFX(audioManager.punch);
            }
            else if (refIsSpawn4.isSpawnP1 == true)
            {
                animator.SetBool("isPunchingP1", false);
            }

            if (refIsSpawn8.isSpawnP2 == false)
            {
                animator.SetBool("isHurtP1", true);
                //audioManager.PlaySFX(audioManager.hurt);
            }
            else if (refIsSpawn8.isSpawnP2 == true)
            {
                animator.SetBool("isHurtP1", false);
            }

            if (refHealthP1.slider.value == 0)
            {
                animator.SetBool("isKnockedOutP1", true);
            }
            else if (refHealthP1.slider.value > 0)
            {
                animator.SetBool("isKnockedOutP1", false);
            }
        }

        if (gameObject.name == "P2")
        {
            if (refIsSpawn8.isSpawnP2 == false)
            {
                animator.SetBool("isPunchingP2", true);
                //audioManager.PlaySFX(audioManager.punch);
            }
            else if (refIsSpawn8.isSpawnP2 == true)
            {
                animator.SetBool("isPunchingP2", false);
            }

            if (refIsSpawn4.isSpawnP1 == false)
            {
                animator.SetBool("isHurtP2", true);
                //audioManager.PlaySFX(audioManager.hurt);
            }
            else if (refIsSpawn4.isSpawnP1 == true)
            {
                animator.SetBool("isHurtP2", false);
            }

            if (refHealthP2.slider.value == 0)
            {
                animator.SetBool("isKnockedOutP2", true);
            }
            else if (refHealthP2.slider.value > 0)
            {
                animator.SetBool("isKnockedOutP2", false);
            }
        }
    }

}
