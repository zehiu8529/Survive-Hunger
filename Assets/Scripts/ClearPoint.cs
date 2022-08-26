using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClearPoint : MonoBehaviour
{
    MenuHandler menuHandler;
    SoundHandler soundHandler;

    private void Start()
    {
        menuHandler = GameObject.Find("Game Menu").GetComponent<MenuHandler>();
        soundHandler = GameObject.Find("SoundHandler").GetComponent<SoundHandler>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag.Equals("Player"))
        {
            soundHandler.PlayClearedStageSound();
            menuHandler.DisplayGameClearedMenu();
            this.gameObject.SetActive(false);
        }
    }
}
