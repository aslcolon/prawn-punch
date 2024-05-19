using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimation : MonoBehaviour
{

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
            aniConditions(refIsSpawn4, refIsSpawn8, refHealthP1, "isPunchingP1", "isHurtP1", "isKnockedOutP1");
        }

        if (gameObject.name == "P2")
        {
            aniConditions(refIsSpawn8, refIsSpawn4, refHealthP2, "isPunchingP2", "isHurtP2", "isKnockedOutP2");
        }
    }

    private void aniConditions(KeyHolder refIsSpawn1, KeyHolder refIsSpawn2, HealthBar refHealth, string isPunching, string isHurt, string isKnockedOut)
    {
        if (refIsSpawn1.isSpawn == false)
        {
            animator.SetBool(isPunching, true);
        }
        else if (refIsSpawn1.isSpawn == true)
        {
            animator.SetBool(isPunching, false);
        }

        if (refIsSpawn2.isSpawn == false)
        {
            animator.SetBool(isHurt, true);
        }
        else if (refIsSpawn2.isSpawn == true)
        {
            animator.SetBool(isHurt, false);
        }

        if (refHealth.slider.value == 0)
        {
            animator.SetBool(isKnockedOut, true);
        }
        else if (refHealth.slider.value == 100)
        {
            animator.SetBool(isKnockedOut, false);
        }
    }

}
