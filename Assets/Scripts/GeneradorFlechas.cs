using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GeneradorFlechas : MonoBehaviour
{
    public GameObject flechas;
    public float timeIntervalo = 4;
    public AudioClip sonidoDisparo;

    private AudioSource audioSource;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        InvokeRepeating("GenerarFlecha", 0.0f, timeIntervalo);
    }

    void GenerarFlecha()
    {
        Instantiate(flechas, transform.position, Quaternion.identity);
        audioSource.PlayOneShot(sonidoDisparo);
    }
}
