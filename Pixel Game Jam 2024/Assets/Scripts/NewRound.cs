using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewRou : MonoBehaviour
{

    public HealthBar refHealthP1, refHealthP2;

    public GameObject roundPopupPrefab;

    private bool roundComplete = false;

    // Start is called before the first frame update
    void Start()
    {
        refHealthP1 = GameObject.Find("Health bar P1").GetComponent<HealthBar>();
        refHealthP2 = GameObject.Find("Health bar P2").GetComponent<HealthBar>();
    }

    // Update is called once per frame
    void Update()
    {
        if ((refHealthP1.slider.value == 0 && refHealthP2.slider.value > 0) || (refHealthP2.slider.value == 0 && refHealthP1.slider.value > 0))
        {
            roundComplete = false;

            for (int i = 1; i < 9; i++)
            {
                GameObject.Find("Prefab Spawn" + (i).ToString()).GetComponent<KeyInput>().enabled = false;
            }

            for (int i = 1; i < 4; i++)
            {
                if (refHealthP2.slider.value == 0)
                {
                    if(GameObject.Find("Star" + (i).ToString() + " P1").GetComponent<SpriteRenderer>().enabled == false)
                    {
                        GameObject.Find("Star" + (i).ToString() + " P1").GetComponent<SpriteRenderer>().enabled = true;
                    }
                    break;
                }
                else if (refHealthP1.slider.value == 0)
                {
                    if (GameObject.Find("Star" + (i).ToString() + " P2").GetComponent<SpriteRenderer>().enabled == false)
                    {
                        GameObject.Find("Star" + (i).ToString() + " P2").GetComponent<SpriteRenderer>().enabled = true;
                    }
                    break;
                }
            }
            Invoke(nameof(nextRound), 2);
            Invoke(nameof(currentRound), 4);
        }
    }

    private void nextRound()
    {
        if (roundComplete == false)
        {
            refHealthP1.slider.value = 100;
            refHealthP2.slider.value = 100;
            var roundPopup = Instantiate(roundPopupPrefab, transform.position, transform.rotation);
            roundComplete = true;
        }
    }

    private void currentRound()
    {
        if (roundComplete == true)
        {
            Destroy(GameObject.Find("Round Popup(Clone)"));
            for (int j = 1; j < 9; j++)
            {
                GameObject.Find("Prefab Spawn" + (j).ToString()).GetComponent<SpriteRenderer>().enabled = true;
            }
            for (int i = 1; i < 9; i++)
            {
                GameObject.Find("Prefab Spawn" + (i).ToString()).GetComponent<KeyInput>().enabled = true;
            }
        }
    }
}
