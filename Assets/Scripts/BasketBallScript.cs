using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasketBallScript : MonoBehaviour
{

    public int totaCollision;
    public Vector3 nowdirection;

    void FixedUpdate()
    {

        if (Input.GetMouseButton(0))
        {
            OnMouseDrag();
            gameObject.GetComponent<Rigidbody2D>().AddForce(nowdirection * 65, ForceMode2D.Force);
        }
    }

    void OnMouseDrag()
    {
        Vector3 mousePosition = new Vector3(Input.mousePosition.x, Input.mousePosition.y, Input.mousePosition.z);
        Vector3 objPosition = Camera.main.ScreenToWorldPoint(mousePosition);
        var heading = gameObject.transform.position - objPosition;
        var distance = heading.magnitude;
        var direction = -heading / distance;
        nowdirection = direction;
    }

    void OnCollisionEnter2D(Collision2D collision)
    {

        totaCollision++;
    }

    void OnDisable()
    {
        PlayerPrefs.SetInt("score", totaCollision);
    }
}