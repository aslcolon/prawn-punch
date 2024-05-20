using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class NewRound : MonoBehaviour
{
    AudioManager audioManager;

    public HealthBar refHealthP1, refHealthP2;

    public GameObject roundPopupPrefab;

    public Sprite[] round = new Sprite[3];

    public Sprite[] roDisplay = new Sprite[3];

    public int numOfSeq;

    private bool roundComplete = false;


    // Start is called before the first frame update
    void Start()
    {
        refHealthP1 = GameObject.Find("Health bar P1").GetComponent<HealthBar>();
        refHealthP2 = GameObject.Find("Health bar P2").GetComponent<HealthBar>();

        nextRound();
        Invoke(nameof(currentRound), 2);

    }

    // Update is called once per frame
    void Update()
    {
        if (((refHealthP1.slider.value == 0 && refHealthP2.slider.value > 0) || (refHealthP2.slider.value == 0 && refHealthP1.slider.value > 0)) && (refHealthP1.oppPoint <= numOfSeq * 2 || refHealthP2.oppPoint <= numOfSeq * 2))
        {
            roundComplete = false;

            for (int j = 1; j < 9; j++)
            {
                GameObject.Find("Prefab Spawn" + (j).ToString()).GetComponent<SpriteRenderer>().enabled = false;
            }
            for (int i = 1; i < 9; i++)
            {
                GameObject.Find("Prefab Spawn" + (i).ToString()).GetComponent<KeyInput>().enabled = false;
            }

            Invoke(nameof(nextRound), 2);
            Invoke(nameof(currentRound), 4);
        }

        if (refHealthP1.oppPoint > numOfSeq * 2 || refHealthP2.oppPoint > numOfSeq * 2)
        {
            GameObject.Find("UI").GetComponent<NewRound>().enabled = false;
        }
    }

    private void Awake()
    {
        audioManager = GameObject.FindGameObjectWithTag("Audio").GetComponent<AudioManager>();
    }

    private void nextRound()
    {
        if (roundComplete == false)
        {
            refHealthP1.slider.value = 100;
            refHealthP2.slider.value = 100;
            var roundPopup = Instantiate(roundPopupPrefab, transform.position, transform.rotation);
            
            for (int i = 0; i < 3; i++)
            {
                if (refHealthP1.oppPoint == numOfSeq * i || refHealthP2.oppPoint == numOfSeq * i)
                {
                    roundPopup.GetComponent<SpriteRenderer>().sprite = round[i];
                    GameObject.Find("Round").GetComponent<SpriteRenderer>().sprite = roDisplay[i];

                    if (i == 0)
                    {
                        audioManager.PlaySFX(audioManager.bellSignal1);
                    }
                    else if (i == 1)
                    {
                        audioManager.PlaySFX(audioManager.bellSignal2);
                    }
                    else if (i == 2)
                    {
                        audioManager.PlaySFX(audioManager.bellSignal3);
                    }
                }
            }
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
