using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneScript : MonoBehaviour
{

    public List<Planets> planets;
    public GameObject basketBall;
    public static bool firstStart = true;
    public static int platformCount = 0;
    public int planetsScore;

    void Start()
    {
        string nameScene = PlayerPrefs.GetString("nameScene");
        FindPlanets(nameScene);
        OptionsPlanet();
    }

    void FindPlanets(string planetsName)
    {
        for (int i = 0; i < planets.Count; i++)
            if (planets[i].name == planetsName)
            {
                planetsScore = i;
            }
    }

    void OptionsPlanet()
    {
        Camera.main.backgroundColor = planets[planetsScore].color;
        basketBall.transform.position = planets[planetsScore].positionBall;
        Physics2D.gravity = new Vector2(0, -planets[planetsScore].gravity);
        planetsScore = 0;
    }

    void Update()
    {
        if (Input.GetKey(KeyCode.Escape))
        {

            SceneManager.LoadScene("Menu");
        }

        if (platformCount == 3)
        {
            firstStart = false;
        }
    }
}