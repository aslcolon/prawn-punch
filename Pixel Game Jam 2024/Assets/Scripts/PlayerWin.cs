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

    public int winner;

    public int pointsP1, pointsP2;

    private bool pointsCounted3 = false;

    // Start is called before the first frame update
    void Start()
    {
        // Initialize refHealth as HealthBar componenets attached to each health bar
        refHealthP1 = GameObject.Find("Health bar P1").GetComponent<HealthBar>();
        refHealthP2 = GameObject.Find("Health bar P2").GetComponent<HealthBar>();

        // Initialize refIsSpawn as KeyHolder components attached to each key holder
        refIsSpawn4 = GameObject.Find("Key4").GetComponent<KeyHolder>();
        refIsSpawn8 = GameObject.Find("Key8").GetComponent<KeyHolder>();

        // Initialize refRoundCounter
        refRoundCounter = GameObject.Find("UI").GetComponent<NewRound>();
    }

    // Update is called once per frame
    void Update()
    {
        // If at least one player has zero health
        if ((refHealthP1.slider.value == 0 && refHealthP2.slider.value > 0) || (refHealthP2.slider.value == 0 && refHealthP1.slider.value > 0))
        {
            // For corresponding round
            for (int i = 1; i < 4; i++)
            {
                if (refRoundCounter.roundCounter == i)
                {
                    // If player 2 hit last, they earn a star
                    if (refIsSpawn4.isSpawn == false)
                    {
                        GameObject.Find("Star" + i + " P1").GetComponent<SpriteRenderer>().enabled = true;
                    }
                    // Else if player 1 hit last, they earn a star
                    else if (refIsSpawn8.isSpawn == false)
                    {
                        GameObject.Find("Star" + i + " P2").GetComponent<SpriteRenderer>().enabled = true;
                    }
                }
            }

            /*if (refRoundCounter.roundCounter == 1 && pointsCounted1 == false)
            {
                if (pointsP1 == 1)
                {
                    GameObject.Find("Star1 P1").GetComponent<SpriteRenderer>().enabled = true;
                }
                else if (pointsP2 == 1)
                {
                    GameObject.Find("Star1 P2").GetComponent<SpriteRenderer>().enabled = true;
                }
                pointsCounted1 = true;
            }*/

            // If round 3
            if (refRoundCounter.roundCounter == 3 && pointsCounted3 == false)
            {
                // Count number of stars for each player
                for (int i = 1; i < 4; i++)
                {
                    if (GameObject.Find("Star" + i + " P1").GetComponent<SpriteRenderer>().enabled == true)
                    {
                        pointsP1++;
                    }
                    else if (GameObject.Find("Star" + i + " P2").GetComponent<SpriteRenderer>().enabled == true)
                    {
                        pointsP2++;
                    }
                }

                pointsCounted3 = true;

                // Winner is determined on greater number of points
                if (pointsP1 > pointsP2)
                {
                    winner = 1;
                }
                else if (pointsP2 > pointsP1)
                {
                    winner = 2;
                }
            }
        }

        // Win menu popup depending on winner
        if (GameObject.Find("UI").GetComponent<NewRound>().enabled == false && (winner == 1 || winner == 2))
        {
            GameObject.Find("Win Menu").GetComponent<Image>().enabled = true;

            if (winner == 1)
            {
                GameObject.Find("Win Menu").GetComponent<Image>().sprite = P1Win;
            }
            else if (winner == 2)
            {
                GameObject.Find("Win Menu").GetComponent<Image>().sprite = P2Win;
            }

            GameObject.Find("Play Again").GetComponent<Image>().enabled = true;
        }
    }
}
