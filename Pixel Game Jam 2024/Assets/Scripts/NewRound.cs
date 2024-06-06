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

    public int roundCounter = 0;

    // Start is called before the first frame update
    void Start()
    {
        // Initialize refHealth as HealthBar componenets attached to each health bar
        refHealthP1 = GameObject.Find("Health bar P1").GetComponent<HealthBar>();
        refHealthP2 = GameObject.Find("Health bar P2").GetComponent<HealthBar>();

        // Call functions to start first round
        nextRound();
        Invoke(nameof(currentRound), 2);
    }

    // Update is called once per frame
    void Update()
    {
        // If at least one player has zero health
        if ((refHealthP1.slider.value == 0 && refHealthP2.slider.value > 0) || (refHealthP2.slider.value == 0 && refHealthP1.slider.value > 0))
        {
            roundComplete = false; // Set roundComplete to false

            // Disable key inputs while round popup is displayed
            for (int i = 1; i < 9; i++)
            {
                GameObject.Find("Prefab Spawn" + (i).ToString()).GetComponent<SpriteRenderer>().enabled = false;
                GameObject.Find("Prefab Spawn" + (i).ToString()).GetComponent<KeyInput>().enabled = false;
            }

            // Call functions to display round popups
            Invoke(nameof(nextRound), 2);
            Invoke(nameof(currentRound), 4);
        }

        // If round 3 is reached, disable round popup loop script
        if (roundCounter == 3)
        {
            GameObject.Find("UI").GetComponent<NewRound>().enabled = false;
        }
    }

    // Awake function to implement audio
    private void Awake()
    {
        audioManager = GameObject.FindGameObjectWithTag("Audio").GetComponent<AudioManager>();
    }

    // nextRound function to declare round number and display popup at beginning of round
    private void nextRound()
    {
        // If round is not complete
        if (roundComplete == false)
        {
            roundCounter++; // Increase round count
            // Reset player health
            refHealthP1.slider.value = 100;
            refHealthP2.slider.value = 100;

            // Spawn popup to declare round number
            var roundPopup = Instantiate(roundPopupPrefab, transform.position, transform.rotation);

            for (int i = 0; i < 3; i++)
            {
                // For corresponding round
                if (roundCounter == i + 1)
                {
                    // Popup sprite dependent on round count number
                    GameObject.Find("Round").GetComponent<SpriteRenderer>().sprite = roDisplay[i];

                    // Play audio to corresponding round count number
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
            roundComplete = true; // Round resets
        }
    }

    // currentRound function 
    private void currentRound()
    {
        // If round is complete
        if (roundComplete == true)
        {
            Debug.Log("STILL A NEW ROUND");
            Destroy(GameObject.Find("Round Popup(Clone)")); // Destroy round popup

            // Enable key inputs
            for (int i = 1; i < 9; i++)
            {
                GameObject.Find("Prefab Spawn" + (i).ToString()).GetComponent<SpriteRenderer>().enabled = true;
                GameObject.Find("Prefab Spawn" + (i).ToString()).GetComponent<KeyInput>().enabled = true;
            }
        }
    }
}
