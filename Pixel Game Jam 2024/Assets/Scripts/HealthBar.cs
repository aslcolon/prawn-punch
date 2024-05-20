using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{

    public Slider slider; // Set up slider

    public int decValue; // Set up hit damage

    public KeyHolder refIsSpawn4, refIsSpawn8; // Declare KeyHolder to reference KeyHolder script

    public int oppPoint = 0;

    public int numOfSeq;

    // Implement decrease timer
    public double decRate = 0.1;
    private float timer = 0;

    private void Start()
    {
        // Initialize refIsSpawn as KeyHolder components attached to each key holder
        refIsSpawn4 = GameObject.Find("Key4").GetComponent<KeyHolder>();
        refIsSpawn8 = GameObject.Find("Key8").GetComponent<KeyHolder>();
    }

    private void Update()
    {
        // If timer is less than spawnRate, increase time
        if (timer < decRate)
        {
            timer += Time.deltaTime;
        }
        // Else if sequence is not yet spawned and consider Player health bar
        else if (refIsSpawn4.isSpawn == false && gameObject.name == "Health bar P2")
        {
            // Call function to control slider and reset timer
            slideConditions(5, 9);
            
            if (slider.value == 0)
            {
                addPoint("P1");
            }

            timer = 0;
        }
        else if (refIsSpawn8.isSpawn == false && gameObject.name == "Health bar P1")
        {
            slideConditions(1, 5);

            if (slider.value == 0)
            {
                addPoint("P2");
            }

            timer = 0;
        }
    }

    // Slider conditions to decrease slider and when slider is  zero
    private void slideConditions(int desStart, int desRange)
    {
        // If slider value is greater or equal to the decreasing value
        if (slider.value >= decValue)
        { 
            slider.value -= decValue; // Decrease slider value
        }
        // If slider is equal to zero
        else if (slider.value == 0)
        {
            // Destroy all key inputs displayed
            for (int i = desStart; i < desRange; i++)
            {
                Destroy(GameObject.Find("Prefab Spawn" + (i).ToString()));
            }
        }
        oppPoint++;
    }

    private void addPoint(string opp)
    {
        for (int i = numOfSeq; i < (numOfSeq * 3) + 1; i++)
        {
            for (int j = 1; j < 4; j++)
            {
                if (oppPoint == numOfSeq * j)
                {
                    if (GameObject.Find("Star" + j + " " + opp).GetComponent<SpriteRenderer>().enabled == false)
                    {
                        GameObject.Find("Star" + j + " " + opp).GetComponent<SpriteRenderer>().enabled = true;
                    }
                }
            }
        }
    }
}
