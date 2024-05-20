using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerWin : MonoBehaviour
{

    public HealthBar refHealthP1, refHealthP2;

    public NewRound refRoundCounter;

    public KeyHolder refIsSpawn4, refIsSpawn8;


    // Start is called before the first frame update
    void Start()
    {
        refHealthP1 = GameObject.Find("Health bar P1").GetComponent<HealthBar>();
        refHealthP2 = GameObject.Find("Health bar P2").GetComponent<HealthBar>();

        refIsSpawn4 = GameObject.Find("Key4").GetComponent<KeyHolder>();
        refIsSpawn8 = GameObject.Find("Key8").GetComponent<KeyHolder>();

        refRoundCounter = GameObject.Find("UI").GetComponent<NewRound>();
    }

    // Update is called once per frame
    void Update()
    {
        if ((refHealthP1.slider.value == 0 && refHealthP2.slider.value > 0) || (refHealthP2.slider.value == 0 && refHealthP1.slider.value > 0))
        {

            for (int i = 1; i < 4; i++)
            {
                if (refRoundCounter.roundCounter == i)
                {
                    if (refHealthP2.oppPoint >= refHealthP1.oppPoint && refIsSpawn4.isSpawn == false)
                    {
                        GameObject.Find("Star" + i + " P1").GetComponent<SpriteRenderer>().enabled = true;
                    }
                    else if (refHealthP1.oppPoint >= refHealthP2.oppPoint && refIsSpawn8.isSpawn == false)
                    {
                        GameObject.Find("Star" + i + " P2").GetComponent<SpriteRenderer>().enabled = true;
                    }
                }
            }
        }



        if (GameObject.Find("UI").GetComponent<NewRound>().enabled == false && (GameObject.Find("Star3 P1").GetComponent<SpriteRenderer>().enabled == true || GameObject.Find("Star3 P2").GetComponent<SpriteRenderer>().enabled == true))
        {
            GameObject.Find("Player Wins").GetComponent<SpriteRenderer>().enabled = true;
        }
    }
}
