using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rocks : MonoBehaviour
{
    public GameObject objectToDestroy;
    public AudioClip destroy;
    private AudioSource audiosource;
    private bool canDestroy;

    private void Start()
    {
        canDestroy = true;
        audiosource = GetComponent<AudioSource>();
     
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            
            if (objectToDestroy == null && canDestroy)
            {
                
                StartCoroutine(destroyRock());
            }
            else
            {
                Debug.Log("El objeto no puede ser destruido porque el objeto condicional aún no ha sido destruido.");
            }
        }
    }

    IEnumerator destroyRock()
    {
        canDestroy = false;
        audiosource.PlayOneShot(destroy);
        yield return new WaitForSeconds(1f);
        Destroy(gameObject);

    }
}
