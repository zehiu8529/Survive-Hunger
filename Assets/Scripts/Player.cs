using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    PlayersHunger player;
    Movement characterMovement;

    MenuHandler menuHandler;

    int clearTime = 0;

    // Start is called before the first frame update
    void Start()
    {
        player = GetComponent<PlayersHunger>();
        characterMovement = GetComponent<Movement>();

        menuHandler = GameObject.Find("Game Menu").GetComponent<MenuHandler>();

        InvokeRepeating("Counting", 1f, 1f);
    }

    // Update is called once per frame
    void Update()
    {
        player.CalculateHungerOverTime();
        if (player.IsDead())
        {
            player.Die();            
        }
        else
        {            
            menuHandler.UpdateTimer(clearTime);
        }       
        PauseGame();
    }

    private void FixedUpdate()
    {
        characterMovement.Move();
    }    

    void PauseGame()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Time.timeScale = 0;
            menuHandler.DisplayGamePauseMenu();
        }
    }

    void Counting()
    {        
        clearTime++;
    }
}
