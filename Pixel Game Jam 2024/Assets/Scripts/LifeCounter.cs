using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LifeCounter : MonoBehaviour
{

    public HealthBar refHealthP1, refHealthP2;

    public GameObject roundPopupPrefab;

    private bool round2 = false;

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
        if (refHealthP1.slider.value == 0 && refHealthP2.slider.value > 0)
        {
            GameObject.Find("Star3 P1").GetComponent<SpriteRenderer>().enabled = false;
            Invoke("nextRound", 2);
            Invoke("currentRound", 4);
            //var roundPopup = Instantiate(roundPopupPrefab, transform.position, transform.rotation);
            //SceneManager.LoadScene("GameplayScene");
        }
        else if (refHealthP2.slider.value == 0 && refHealthP1.slider.value > 0)
        {
            GameObject.Find("Star3 P2").GetComponent<SpriteRenderer>().enabled = false;
            Invoke("nextRound", 2);
            Invoke("currentRound", 4);
            //var roundPopup = Instantiate(roundPopupPrefab, transform.position, transform.rotation);
            //SceneManager.LoadScene("GameplayScene");

        }

    }

    private void nextRound()
    {
        if (round2 == false)
        {
            refHealthP1.slider.value = 100;
            refHealthP2.slider.value = 100;
            var roundPopup = Instantiate(roundPopupPrefab, transform.position, transform.rotation);
            round2 = true;
        }
    }

    private void currentRound()
    {
        if (round2 == true)
        {
            Destroy(GameObject.Find("Round Popup(Clone)"));
        }
    }
}

