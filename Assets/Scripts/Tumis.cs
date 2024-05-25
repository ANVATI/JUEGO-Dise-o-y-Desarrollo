using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tumis : MonoBehaviour
{
    public Player jugador;
    public AudioClip audioTumi;
    AudioSource _audioSource;

    private void Start()
    {
        _audioSource = GetComponent<AudioSource>();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
       
        if (collision.gameObject == jugador.gameObject)
        {
            jugador.puntuacion++;
            StartCoroutine(TimetoDestroy());
        }
    }

    IEnumerator TimetoDestroy()
    {
        _audioSource.PlayOneShot(audioTumi);
        yield return new WaitForSeconds(0.15f);
        Destroy(this.gameObject);
    }
}
