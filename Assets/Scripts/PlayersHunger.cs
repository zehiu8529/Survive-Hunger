using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayersHunger : MonoBehaviour
{
    [SerializeField]
    private float hungerMeter = 0f;
    [SerializeField]
    private Image hungerSlider;
    private float smooth = 3f;
    private float timer = .5f;
    private float rate = .5f;
    private float decreaseNumber = 1f;
    private float maxNumber = 100;
    private float minNumber = 0;
    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("TimeAndRateIncrease",1,1);
        InvokeRepeating("HungerIncrease",timer,rate);
        
        hungerMeter = minNumber;
    }

    // Update is called once per frame
    void Update()
    {
        hungerMeter = Mathf.Clamp(hungerMeter,0,100);
        timer = Mathf.Clamp(timer,0.5f,5f);
        rate = Mathf.Clamp(rate, 0.5f, 5f);
        float lerpSpeed = smooth * Time.deltaTime;
        hungerSlider.fillAmount = Mathf.Lerp(hungerSlider.fillAmount,hungerMeter/maxNumber,lerpSpeed);
    }

    private void HungerIncrease()
    {
        hungerMeter += decreaseNumber;
        Debug.Log(hungerMeter);
    }
    private void TimeAndRateIncrease()
    {
        timer -= 0.5f;
        rate -= 0.5f;
        
    }
}