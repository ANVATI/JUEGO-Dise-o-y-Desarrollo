using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RocaMovible : MonoBehaviour
{
    private Rigidbody2D rb;
    private bool isBeingPushed = false;
    private bool isColliding = false; 
    private AudioSource audioSource;
    public AudioClip move;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        audioSource = GetComponent<AudioSource>();
    }

    void FixedUpdate()
    {
        if (!isBeingPushed)
        {
            rb.velocity = Vector2.zero;
        }
    }

    public void Push(Vector2 direction, float speed)
    {
        rb.velocity = direction * speed * 0.5f;
        isBeingPushed = true;
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            isColliding = true;
            StartCoroutine(PlayMoveSound());
        }
    }

    void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            isColliding = false;
        }
    }

    IEnumerator PlayMoveSound()
    {
        if (!audioSource.isPlaying)
        {
            audioSource.PlayOneShot(move);
        }
        yield return new WaitWhile(() => isColliding);
        audioSource.Stop();
        isBeingPushed = false;
    }
}


