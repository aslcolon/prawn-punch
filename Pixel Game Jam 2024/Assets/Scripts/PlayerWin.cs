using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerWin : MonoBehaviour
{

    public HealthBar refHealthP1, refHealthP2;


    // Start is called before the first frame update
    void Start()
    {
        refHealthP1 = GameObject.Find("Health bar P1").GetComponent<HealthBar>();
        refHealthP2 = GameObject.Find("Health bar P2").GetComponent<HealthBar>();
    }

    // Update is called once per frame
    void Update()
    {


        if (GameObject.Find("UI").GetComponent<NewRound>().enabled == false && (refHealthP1.pointCount == 3 || refHealthP2.pointCount == 3 || (refHealthP1.pointCount == 2 && refHealthP2.pointCount == 1) || (refHealthP2.pointCount == 2 && refHealthP1.pointCount == 1)))
        {
            GameObject.Find("Player Wins").GetComponent<SpriteRenderer>().enabled = true;
        }
    }
}
