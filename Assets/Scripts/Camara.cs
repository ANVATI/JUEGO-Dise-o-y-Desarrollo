using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camara : MonoBehaviour
{
    public Transform jugador; 

    public Vector3 offset; 

    void Update()
    {
        
        if (jugador != null)
        {
            
            Vector3 nuevaPosicion = jugador.position + offset;

            
            nuevaPosicion.z = transform.position.z;

            
            transform.position = nuevaPosicion;
        }
    }
}
