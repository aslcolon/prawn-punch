using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LifeCounter : MonoBehaviour
{

    public HealthBar refHealthP1, refHealthP2;

    public GameObject roundPopupPrefab;

    private bool round2 = false, round3 = false;

    public Sprite round2Sprite;
    public Sprite round3Sprite;

    //private int roundCount = 0;

    //public Animator animator;

    // Start is called before the first frame update
    void Start()
    {
        refHealthP1 = GameObject.Find("Health bar P1").GetComponent<HealthBar>();
        refHealthP2 = GameObject.Find("Health bar P2").GetComponent<HealthBar>();
    }

    // Update is called once per frame
    void Update()
    {

        /*for (int i = 0; i < 3; i++)
        {
            if (refHealthP1.slider.value == 0 && refHealthP2.slider.value > 0)
            {
                GameObject.Find("Star" + (i + 1).ToString() + " P1").GetComponent<SpriteRenderer>().enabled = true;
                Invoke(nameof(nextRound), 2);
                Invoke(nameof(currentRound), 4);
            }
            else if (refHealthP2.slider.value == 0 && refHealthP1.slider.value > 0)
            {
                GameObject.Find("Star" + (i + 1).ToString() + " P2").GetComponent<SpriteRenderer>().enabled = true;
                Invoke(nameof(nextRound), 2);
                Invoke(nameof(currentRound), 4);
            }
        }*/

        /*if ((refHealthP1.slider.value == 0 && refHealthP2.slider.value > 0) || (refHealthP2.slider.value == 0 && refHealthP1.slider.value > 0))
        {
            roundCount++;
            

            if (roundCount == 1)
            {
                if (refHealthP1.slider.value == 0 && refHealthP2.slider.value > 0)
                {
                    GameObject.Find("Star1 P1").GetComponent<SpriteRenderer>().enabled = true;
                    Invoke(nameof(nextRound), 2);
                    Invoke(nameof(currentRound), 4);
                }
                else if (refHealthP2.slider.value == 0 && refHealthP1.slider.value > 0)
                {
                    GameObject.Find("Star1 P2").GetComponent<SpriteRenderer>().enabled = true;
                    Invoke(nameof(nextRound), 2);
                    Invoke(nameof(currentRound), 4);
                }
            }
            else if (roundCount == 2)
            {
                if (refHealthP1.slider.value == 0 && refHealthP2.slider.value > 0)
                {
                    GameObject.Find("Star2 P1").GetComponent<SpriteRenderer>().enabled = true;
                    Invoke(nameof(nextRound), 2);
                    Invoke(nameof(currentRound), 4);
                }
                else if (refHealthP2.slider.value == 0 && refHealthP1.slider.value > 0)
                {
                    GameObject.Find("Star2 P2").GetComponent<SpriteRenderer>().enabled = true;
                    Invoke(nameof(nextRound), 2);
                    Invoke(nameof(currentRound), 4);
                }
            }
            else if (roundCount == 3)
            {
                if (refHealthP1.slider.value == 0 && refHealthP2.slider.value > 0)
                {
                    GameObject.Find("Star3 P1").GetComponent<SpriteRenderer>().enabled = true;
                    //Invoke(nameof(nextRound), 2);
                    //Invoke(nameof(currentRound), 4);
                }
                else if (refHealthP2.slider.value == 0 && refHealthP1.slider.value > 0)
                {
                    GameObject.Find("Star3 P2").GetComponent<SpriteRenderer>().enabled = true;
                    //Invoke(nameof(nextRound), 2);
                    //Invoke(nameof(currentRound), 4);
                }
            }    
        }*/

        if (refHealthP1.slider.value == 0 && refHealthP2.slider.value > 0)
        {
            if (round2 == false)
            {
                GameObject.Find("Star1 P1").GetComponent<SpriteRenderer>().enabled = true;
                Invoke(nameof(nextRound), 2);
                Invoke(nameof(currentRound), 4);
            }
            else if (round2 == true)
            {
                GameObject.Find("Star2 P1").GetComponent<SpriteRenderer>().enabled = true;
                Invoke(nameof(nextRound), 2);
                Invoke(nameof(currentRound), 4);
            }
            else if (round3 == true)
            {
                GameObject.Find("Star3 P1").GetComponent<SpriteRenderer>().enabled = true;
            }
        }
        else if (refHealthP2.slider.value == 0 && refHealthP1.slider.value > 0)
        {
            if (round2 == false)
            {
                GameObject.Find("Star1 P2").GetComponent<SpriteRenderer>().enabled = true;
                Invoke(nameof(nextRound), 2);
                Invoke(nameof(currentRound), 4);
            }
            else if (round2 == true)
            {
                GameObject.Find("Star2 P2").GetComponent<SpriteRenderer>().enabled = true;
                Invoke(nameof(nextRound), 2);
                Invoke(nameof(currentRound), 4);
            }
            else if (round3 == true) 
            {
                GameObject.Find("Star3 P2").GetComponent<SpriteRenderer>().enabled = true;
            }
        }
    }

    private void nextRound()
    {

        if (round2 == false)
        {
            refHealthP1.slider.value = 100;
            refHealthP2.slider.value = 100;
            var roundPopup = Instantiate(roundPopupPrefab, transform.position, transform.rotation);
            roundPopup.GetComponent<SpriteRenderer>().sprite = round2Sprite;
            round2 = true;
        }
        else if (round3 == false)
        {
            refHealthP1.slider.value = 100;
            refHealthP2.slider.value = 100;
            var roundPopup = Instantiate(roundPopupPrefab, transform.position, transform.rotation);
            roundPopup.GetComponent<SpriteRenderer>().sprite = round3Sprite;
            round3 = true;
        }
        /*else if (roundCount == 2)
        {
            refHealthP1.slider.value = 100;
            refHealthP2.slider.value = 100;
            var roundPopup = Instantiate(roundPopupPrefab, transform.position, transform.rotation);
            roundCount = 3;
        }*/

        /*if (roundCount == 1)
        {
            if (round2 == false)
            {
                refHealthP1.slider.value = 100;
                refHealthP2.slider.value = 100;
                var roundPopup = Instantiate(roundPopupPrefab, transform.position, transform.rotation);
                round2 = true;
            }
        }
        else if (roundCount == 2)
        {
            if (round3 == false)
            {
                refHealthP1.slider.value = 100;
                refHealthP2.slider.value = 100;
                var roundPopup = Instantiate(roundPopupPrefab, transform.position, transform.rotation);
                round3 = true;
            }
        }*/

        /*for (int i = 0; i < 2; i++)
        {
            if (round[i] == false)
            {
                refHealthP1.slider.value = 100;
                refHealthP2.slider.value = 100;
                var roundPopup = Instantiate(roundPopupPrefab, transform.position, transform.rotation);
                round[i] = true;
            }
        }*/

        /*if (round2 == false)
        {
            refHealthP1.slider.value = 100;
            refHealthP2.slider.value = 100;
            var roundPopup = Instantiate(roundPopupPrefab, transform.position, transform.rotation);
            round2 = true;
        }*/
    }

    private void currentRound()
    {

        if (round2 == true)
        {
            Destroy(GameObject.Find("Round Popup(Clone)"));
            for (int j = 1; j < 9; j++)
            {
                GameObject.Find("Prefab Spawn" + (j).ToString()).GetComponent<SpriteRenderer>().enabled = true;
            }
        }
        else if (round3 == true)
        {
            Destroy(GameObject.Find("Round Popup(Clone)"));
            for (int j = 1; j < 9; j++)
            {
                GameObject.Find("Prefab Spawn" + (j).ToString()).GetComponent<SpriteRenderer>().enabled = true;
            }
        }

        /*if (roundCount == 1)
        {
            if (round2 == true)
            {
                Destroy(GameObject.Find("Round Popup(Clone)"));
                for (int j = 1; j < 9; j++)
                {
                    GameObject.Find("Prefab Spawn" + (j).ToString()).GetComponent<SpriteRenderer>().enabled = true;
                }
            }
        }
        else if (roundCount == 2)
        {
            if (round3 == true)
            {
                Destroy(GameObject.Find("Round Popup(Clone)"));
                for (int j = 1; j < 9; j++)
                {
                    GameObject.Find("Prefab Spawn" + (j).ToString()).GetComponent<SpriteRenderer>().enabled = true;
                }
            }
        }*/

        /*if (round[roundNum] == true)
        {
            Destroy(GameObject.Find("Round Popup(Clone)"));
            for (int j = 1; j < 9; j++)
            {
                GameObject.Find("Prefab Spawn" + (j).ToString()).GetComponent<SpriteRenderer>().enabled = true;
            }
        }*/
        /*for (int i = 0; i < 2; i++)
        {
            if (round[i] == true)
            {
                Destroy(GameObject.Find("Round Popup(Clone)"));
                for (int j = 1; j < 9; j++)
                {
                    GameObject.Find("Prefab Spawn" + (j).ToString()).GetComponent<SpriteRenderer>().enabled = true;
                }
            }
        }*/

        /*if (round2 == true)
        {
            Destroy(GameObject.Find("Round Popup(Clone)"));

            for (int i = 1; i < 9; i++)
            {
                GameObject.Find("Prefab Spawn" + (i).ToString()).GetComponent<SpriteRenderer>().enabled = true;
            }
        }*/
    }
}

