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
    [SerializeField]
    private float timer = .25f;
    [SerializeField]
    private float rate = .25f;
    private float decreaseNumber = 1f;
    private float maxNumber = 101;
    private float minNumber = 0;
    [SerializeField]
    private GameObject explosionPrefabs;

    GameObject gameMenu;

    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("TimeAndRateIncrease",1,1);
        InvokeRepeating("HungerIncrease",timer,rate);
        
        hungerMeter = minNumber;

        gameMenu = GameObject.Find("Game Menu");        
    }
    
    // Increase hunger overtime
    private void HungerIncrease()
    {
        hungerMeter += decreaseNumber;
    }

    // What do this method do? :v
    private void TimeAndRateIncrease()
    {
        timer -= 0.5f;
        rate -= 0.5f;        
    }

    /// <summary>
    /// Calculate current hunger amount
    /// </summary>
    public void CalculateHungerOverTime()
    {
        hungerMeter = Mathf.Clamp(hungerMeter, 0, 101);
        timer = Mathf.Clamp(timer, 0.25f, 5f);
        rate = Mathf.Clamp(rate, 0.25f, 5f);
        float lerpSpeed = smooth * Time.deltaTime;
        hungerSlider.fillAmount = Mathf.Lerp(hungerSlider.fillAmount, hungerMeter / maxNumber, lerpSpeed);
    }

    /// <summary>
    /// Check if player is died
    /// </summary>
    /// <returns></returns>
    public bool IsDead()
    {
        if(hungerMeter == maxNumber)
        {
            return true;
        }
        return false;
    }

    /// <summary>
    /// Player die and display game over menu
    /// </summary>
    public void Die()
    {
        Instantiate(explosionPrefabs,transform.position,Quaternion.identity);
        Destroy(gameObject);

        gameMenu.GetComponent<MenuHandler>().DisplayGameOverMenu();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Food" && collision.gameObject.layer == 6)
        {
            hungerMeter -= 5f;
            Destroy(collision.gameObject);
        }
        if (collision.gameObject.tag == "Food" && collision.gameObject.layer == 7)
        {
            hungerMeter -= 15f;
            Destroy(collision.gameObject);
        }
        if (collision.gameObject.tag == "Food" && collision.gameObject.layer == 8)
        {
            hungerMeter -= 25f;
            Destroy(collision.gameObject);
        }
    }    
}
