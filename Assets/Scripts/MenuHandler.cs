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
    [SerializeReference] GameObject gameOverMenu;
    [SerializeReference] GameObject gameClearedMenu;
    [SerializeReference] TextMeshProUGUI timerText;
    Animator transition;
    Animator menuTransition;
    CanvasGroup groupControl;
    private float transitionTime = 1f;
    [SerializeReference] GameObject gamePauseMenu;

    private void Start()
    {
        try
        {
            groupControl = GetComponentInChildren<CanvasGroup>();            
        }
        catch
        {
            groupControl = GameObject.Find("Game Menu").GetComponent<CanvasGroup>();
        }

        groupControl.interactable = true;
        groupControl.blocksRaycasts = true;

        transition = GameObject.Find("LevelLoader").GetComponentInChildren<Animator>();
        menuTransition = GameObject.Find("Game Menu").GetComponent<Animator>();
    }


    /// <summary>
    /// Change to difficulty selection section
    /// </summary>
    public void StartGame()
    {
        startButton.gameObject.SetActive(false);
        difficultyMenu.gameObject.SetActive(true);
    }

    /// <summary>
    /// Load easy difficult stage scene
    /// </summary>
    public void StartEasyStage()
    {
       StartCoroutine( LoadLevel(1));
    }

    /// <summary>
    /// Load medium difficult stage scene
    /// </summary>
    public void StartMediumStage()
    {
        StartCoroutine(LoadLevel(2));
    }

    /// <summary>
    /// Load hard difficult stage scene
    /// </summary>
    public void StartHardStage()
    {
        StartCoroutine(LoadLevel(3));
    }

    /// <summary>
    /// Reload current scence to play again
    /// </summary>
    public void TryAgain()
    {
        StartCoroutine(LoadLevel(SceneManager.GetActiveScene().buildIndex));   
            
    }

    /// <summary>
    /// Return to starting menu scene
    /// </summary>
    public void Return()
    {
        StartCoroutine(LoadLevel(0));
        Time.timeScale = 1;
    }

    /// <summary>
    /// Load next difficult scene
    /// </summary>
    public void NextLevel()
    {
        StartCoroutine(LoadLevel(SceneManager.GetActiveScene().buildIndex + 1));
        Time.timeScale = 1;
    }

    /// <summary>
    /// Continue to play
    /// </summary>
    public void Continue()
    {
        gamePauseMenu.gameObject.SetActive(false);
        Time.timeScale = 1;
    }

    IEnumerator LoadLevel(int levelNumber)
    {
        transition.SetTrigger("Start");
        menuTransition.SetTrigger("Begin");
        groupControl.interactable = true;
        groupControl.blocksRaycasts = true;
        yield return new WaitForSeconds(transitionTime);
        SceneManager.LoadScene(levelNumber);
    }

    public void UpdateTimer(int time)
    {
        timerText.text = "Time\n" + time;
    }

    #region Menu Display
    /// <summary>
    /// Set game over object active state to true
    /// </summary>
    public void DisplayGameOverMenu()
    {
        gameOverMenu.gameObject.SetActive(true);
    }

    /// <summary>
    /// Set game cleared object active state to true
    /// </summary>
    public void DisplayGameClearedMenu()
    {
        gameClearedMenu.gameObject.SetActive(true);
    }
      
    /// <summary>
    /// Set game pause object active state to true
    /// </summary>
    public void DisplayGamePauseMenu()
    {
        gamePauseMenu.gameObject.SetActive(true);
    }
    #endregion
}
