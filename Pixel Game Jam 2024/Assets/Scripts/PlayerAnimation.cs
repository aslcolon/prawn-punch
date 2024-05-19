using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimation : MonoBehaviour
{

    public Animator animator; // Declare animator to access animations

    public KeyHolder refIsSpawn4, refIsSpawn8; // Declare KeyHolder to reference KeyHolder script

    public HealthBar refHealthP1, refHealthP2; // Declare HealthBar to reference slider values

    // Start is called before the first frame update
    void Start()
    {
        // Initialize refIsSpawn as KeyHolder components attached to each key holder
        refIsSpawn4 = GameObject.Find("Key4").GetComponent<KeyHolder>();
        refIsSpawn8 = GameObject.Find("Key8").GetComponent<KeyHolder>();

        // Initialize refHealth as HealthBar componenents of each player
        refHealthP1 = GameObject.Find("Health bar P1").GetComponent<HealthBar>();
        refHealthP2 = GameObject.Find("Health bar P2").GetComponent<HealthBar>();
    }

    // Update is called once per frame
    void Update()   
    {   
        // If Player 1, call corresponding animation conditions
        if (gameObject.name == "P1")
        {
            aniConditions(refIsSpawn4, refIsSpawn8, refHealthP1, "isPunchingP1", "isHurtP1", "isKnockedOutP1");
        }
        // If Player 2, call corresponding animation conditions
        if (gameObject.name == "P2")
        {
            aniConditions(refIsSpawn8, refIsSpawn4, refHealthP2, "isPunchingP2", "isHurtP2", "isKnockedOutP2");
        }
    }

    // Animation conditions to play specific animation to action
    private void aniConditions(KeyHolder refIsSpawn1, KeyHolder refIsSpawn2, HealthBar refHealth, string isPunching, string isHurt, string isKnockedOut)
    {
        // When key inputs are destroyed, play punching animation for player
        if (refIsSpawn1.isSpawn == false)
        {
            animator.SetBool(isPunching, true);
        }
        else if (refIsSpawn1.isSpawn == true)
        {
            animator.SetBool(isPunching, false);
        }

        // When key inputs are destroyed, play hurt animation for opponent
        if (refIsSpawn2.isSpawn == false)
        {
            animator.SetBool(isHurt, true);
        }
        else if (refIsSpawn2.isSpawn == true)
        {
            animator.SetBool(isHurt, false);
        }

        // When health bar slider is zero, play knock out animation
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
