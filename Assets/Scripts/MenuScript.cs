using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenuScript : MonoBehaviour
{

    public string nameScene;
    public static int totalScore = 0;
    public static bool firstStart = true;

    void OnEnable()
    {
        if (firstStart == true)
        {
            GameObject score = GameObject.Find("TextHit");
            score.GetComponent<Text>().text = "BallHit : " + totalScore;
            firstStart = false;
        }
        else
        {
            int scoreInt = PlayerPrefs.GetInt("score");
            totalScore = totalScore + scoreInt;
            GameObject score = GameObject.Find("TextHit");
            score.GetComponent<Text>().text = "BallHit : " + totalScore;
        }
    }

    public void LoadSceneEarth()
    {
        SceneManager.LoadScene("Game");
        nameScene = "Earth";
    }

    public void LoadSceneMoon()
    {
        SceneManager.LoadScene("Game");
        nameScene = "Moon";
    }

    public void LoadSceneJupiter()
    {
        SceneManager.LoadScene("Game");
        nameScene = "Jupiter";
    }

    void OnDisable()
    {
        PlayerPrefs.SetString("nameScene", nameScene);
    }

}