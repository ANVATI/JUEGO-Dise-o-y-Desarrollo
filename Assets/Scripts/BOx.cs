using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BOx : MonoBehaviour
{
    private Transform player;
    private bool isFollowing = false;
    private bool isTriggered = false;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            isFollowing = true;
            isTriggered = true;
        }
        else if (Input.GetKeyUp(KeyCode.E))
        {
            isFollowing = false;
            isTriggered = false;
        }


        if (isFollowing && player != null)
        {
            transform.position = player.position;
        }
    }

    void FixedUpdate()
    {
        GetComponent<Collider2D>().isTrigger = isTriggered;
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            player = collision.transform;
        }
    }

    void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            player = null;
        }
    }
}
