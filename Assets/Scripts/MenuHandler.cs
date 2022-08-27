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
    [SerializeField] Animator transition;
    [SerializeReference] Animator menuTransition;
    [SerializeField] CanvasGroup groupControl;
    private float transitionTime = 1f;

    private void Start()
    {
        /*        try
                {
                    if(startButton != null && difficultyMenu != null)
                    {
                        Debug.Log(".............");
                    }
                }
                catch
                {
                    Debug.Log("It's fine :v");
                }*/
        groupControl.interactable = true;
        groupControl.blocksRaycasts = true;
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
    }

    /// <summary>
    /// Load next difficult scene
    /// </summary>
    public void NextLevel()
    {
        StartCoroutine(LoadLevel(SceneManager.GetActiveScene().buildIndex + 1));
    }

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

    IEnumerator LoadLevel(int levelNumber)
    {
        transition.SetTrigger("Start");
        menuTransition.SetTrigger("Begin");
        groupControl.interactable = true;
        groupControl.blocksRaycasts = true;
        yield return new WaitForSeconds(transitionTime);
        SceneManager.LoadScene(levelNumber);
    }
}
