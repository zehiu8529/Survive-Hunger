using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class MenuHandler : MonoBehaviour
{
    [SerializeReference] Button startButton;
    [SerializeReference] TextMeshProUGUI difficultyMenu;

    private void Start()
    {
        try
        {
            if(startButton != null && difficultyMenu != null)
            {
                Debug.Log(".............");
            }
        }
        catch
        {
            Debug.Log("It's fine :v");
        }
    }

    public void StartGame()
    {
        startButton.gameObject.SetActive(false);
        difficultyMenu.gameObject.SetActive(true);
    }

    public void StartEasyStage()
    {
        SceneManager.LoadScene(1);
    }

    public void StartMediumStage()
    {
        SceneManager.LoadScene(2);
    }
    public void StartHardStage()
    {
        SceneManager.LoadScene(3);
    }

    public void TryAgain()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void Return()
    {
        SceneManager.LoadScene(0);
    }

    public void NextLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}
