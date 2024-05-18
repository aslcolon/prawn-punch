using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{

    public Slider slider;

    AudioManager audioManager;

    public KeyHolder refIsSpawn4, refIsSpawn8;

    // Implement decrease timer
    public double decRate = 0.1;
    private float timer = 0;

    private void Start()
    {
        refIsSpawn4 = GameObject.Find("Key4").GetComponent<KeyHolder>();
        refIsSpawn8 = GameObject.Find("Key8").GetComponent<KeyHolder>();
    }

    private void Update()
    {
        if (timer < decRate)
        {
            timer += Time.deltaTime;
        }
        else if (refIsSpawn4.isSpawnP1 == false && gameObject.name == "Health bar P2")
        {
            //if (slider.value >= 4)
            //{
                slider.value -= 50;
            //}
            //audioManager.PlaySFX(audioManager.punch);
            //audioManager.PlaySFX(audioManager.hurt);
            timer = 0;
        }
        else if (refIsSpawn8.isSpawnP2 == false && gameObject.name == "Health bar P1")
        {
            //if (slider.value >= 4)
            //{
                slider.value -= 50;
            //}
            //audioManager.PlaySFX(audioManager.punch);
            //audioManager.PlaySFX(audioManager.hurt);
            timer = 0;
        }
    }
}
