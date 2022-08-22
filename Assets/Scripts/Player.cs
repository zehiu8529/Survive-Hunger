using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    PlayersHunger player;
    Movement characterMovement;

    // Start is called before the first frame update
    void Start()
    {
        player = GetComponent<PlayersHunger>();
        characterMovement = GetComponent<Movement>();
    }

    // Update is called once per frame
    void Update()
    {
        player.CalculateHungerOverTime();
        if (player.IsDead())
        {
            player.Die();
        }
    }

    private void FixedUpdate()
    {
        characterMovement.Move();
    }    
}
