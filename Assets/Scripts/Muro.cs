using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class Muro : MonoBehaviour
{

    public float velocidadEstiramiento = 1.0f; 
    public float alturaMaxima = 5.0f; 
    public float velocidadRetorno = 1.0f;
    public float alturaOriginal; 
    public string escenaDerrota = "Derrota"; 

    private bool estirandose = true; 

    void Start()
    {
        
        alturaOriginal = transform.localScale.y;
    }

    void Update()
    {
       
        if (estirandose)
        {
            
            if (transform.localScale.y < alturaMaxima)
            {
                transform.localScale += new Vector3(0, velocidadEstiramiento * Time.deltaTime, 0);
            }
            else
            {
                
                estirandose = false;
            }
        }
        else 
        {
            
            if (transform.localScale.y > alturaOriginal)
            {
                transform.localScale -= new Vector3(0, velocidadRetorno * Time.deltaTime, 0);
            }
            else
            {
                
                estirandose = true;
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
      
        if (collision.gameObject.tag == ("Player"))
        {
            
            collision.gameObject.SetActive(false);

            
           SceneManager.LoadScene(escenaDerrota);
        }
    }
}
