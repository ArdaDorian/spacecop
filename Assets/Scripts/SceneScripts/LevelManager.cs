using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
    ScoreKeeper scoreKeeper;
    //UILevelEnd UILevelEnd;
    [SerializeField] GameObject UILevelEndGameObject;
    [SerializeField] GameObject endGameScreen;

    private void Awake()
    {
        scoreKeeper=FindObjectOfType<ScoreKeeper>();
        //UILevelEnd=FindObjectOfType<UILevelEnd>();
    }

    public void LoadNextScene(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }

    public void LoadGame()
    {
        ResetScore();
        SceneManager.LoadScene("Level1");
    }

    public void LoadMainMenu()
    {
        SceneManager.LoadScene(0);

    }

    public void LoadGameOver()
    {
        StartCoroutine(WaitLoad("_GameOver"));
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    public void LoadEndLevel()
    {
        UILevelEndGameObject.SetActive(true);
        FindObjectOfType<UILevelEnd>().CallLevelEndUI(scoreKeeper.GetScore()>=100, "Score: " + scoreKeeper.GetScore().ToString("00000"));
    }

    public void LoadEndGame()
    {
        endGameScreen.SetActive(true);
    }

    IEnumerator WaitLoad(string sceneName)
    {
        yield return new WaitForSeconds(2);
        SceneManager.LoadScene(sceneName);
    }

    void ResetScore()
    {
        if (scoreKeeper != null)
        {
            scoreKeeper.ResetScore();
        }
    }
}
