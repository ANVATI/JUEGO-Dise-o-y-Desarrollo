using UnityEngine;
using System.Collections;
using System.Collections.Generic;
public class Mina: MonoBehaviour
{
    private AudioSource audioSource;
    public AudioClip collect;

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            Player player = collision.gameObject.GetComponent<Player>();
            if (player != null)
            {
                player.RecibirDano(1);
            }
            StartCoroutine(DestroyPico());
        }
    }

    IEnumerator DestroyPico()
    {
        audioSource.PlayOneShot(collect);
        yield return new WaitForSeconds(0.5f);
        Destroy(this.gameObject);
    }
}