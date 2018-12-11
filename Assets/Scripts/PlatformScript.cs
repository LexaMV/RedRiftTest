using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlatformScript : MonoBehaviour
{

    public string namePlatform;
    public bool firstStrike = true;

    void OnCollisionEnter2D(Collision2D collision)
    {
        gameObject.GetComponent<SpriteRenderer>().color = Random.ColorHSV(0f, 1f, 1f, 1f, 0.5f, 1f);

        string nameScene = PlayerPrefs.GetString("nameScene");
        if (nameScene == "Jupiter" && firstStrike == true)
        {
            collision.gameObject.GetComponent<Rigidbody2D>().velocity = new Vector3(0, 10, 0);
            firstStrike = false;
        }
    }

    void OnEnable()
    {

        namePlatform = gameObject.name;

        float r = PlayerPrefs.GetFloat(namePlatform + "r");
        float g = PlayerPrefs.GetFloat(namePlatform + "g");
        float b = PlayerPrefs.GetFloat(namePlatform + "b");
        float a = PlayerPrefs.GetFloat(namePlatform + "a");

        if (SceneScript.firstStart == true)
        {
            gameObject.GetComponent<SpriteRenderer>().color = Color.black;
            SceneScript.platformCount += 1;
        }
        else
        {
            gameObject.GetComponent<SpriteRenderer>().color = new Color(r, g, b, a);
        }
    }

    void OnDisable()
    {
        float r = gameObject.GetComponent<SpriteRenderer>().color.r;
        float b = gameObject.GetComponent<SpriteRenderer>().color.b;
        float g = gameObject.GetComponent<SpriteRenderer>().color.g;
        float a = gameObject.GetComponent<SpriteRenderer>().color.a;

        PlayerPrefs.SetFloat(namePlatform + "r", r);
        PlayerPrefs.SetFloat(namePlatform + "g", g);
        PlayerPrefs.SetFloat(namePlatform + "b", b);
        PlayerPrefs.SetFloat(namePlatform + "a", a);
    }
}