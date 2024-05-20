using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerWin : MonoBehaviour
{

    public HealthBar refHealthP1, refHealthP2;

    public NewRound refRoundCounter;

    public KeyHolder refIsSpawn4, refIsSpawn8;

    public Sprite P1Win, P2Win;


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
            GameObject.Find("Win Menu").GetComponent<Image>().enabled = true;

            if (GameObject.Find("Star3 P1").GetComponent<SpriteRenderer>().enabled == true)
            {
                GameObject.Find("Win Menu").GetComponent<Image>().sprite = P1Win;
            }
            else if (GameObject.Find("Star3 P2").GetComponent<SpriteRenderer>().enabled == true)
            {
                GameObject.Find("Win Menu").GetComponent<Image>().sprite = P2Win;
            }

            GameObject.Find("Play Again").GetComponent<Image>().enabled = true;
            GameObject.Find("Exit Game").GetComponent<Image>().enabled = true;
        }
    }
}
