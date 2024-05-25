using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PIcoObjeto : MonoBehaviour
{
    public Player jugador;
    private AudioSource audioSource;
    public AudioClip collect;

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject == jugador.gameObject)
        {
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
