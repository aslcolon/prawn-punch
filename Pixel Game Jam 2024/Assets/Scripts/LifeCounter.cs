using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LifeCounter : MonoBehaviour
{

    public HealthBar refHealthP1, refHealthP2;

    public GameObject roundPopupPrefab;

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
            var roundPopup = Instantiate(roundPopupPrefab, transform.position, transform.rotation);
        }
        else if (refHealthP2.slider.value == 0 && refHealthP1.slider.value > 0)
        {
            GameObject.Find("Star3 P2").GetComponent<SpriteRenderer>().enabled = false;
            var roundPopup = Instantiate(roundPopupPrefab, transform.position, transform.rotation);

        }
    }
}
