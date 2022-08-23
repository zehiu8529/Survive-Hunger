using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClearPoint : MonoBehaviour
{
    GameObject gameMenu;
    GameObject soundHandler;

    private void Start()
    {
        gameMenu = GameObject.Find("Game Menu");
        soundHandler = GameObject.Find("SoundHandler");
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag.Equals("Player"))
        {
            soundHandler.GetComponent<SoundHandler>().PlayClearedStageSound();
            gameMenu.GetComponent<MenuHandler>().DisplayGameClearedMenu();
            this.gameObject.SetActive(false);
        }
    }
}
