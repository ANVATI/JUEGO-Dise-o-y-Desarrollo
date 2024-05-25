using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TextoPuntuacion : MonoBehaviour
{
    public Text textoPuntuacion; 

  
    public Player jugador;

    void Update()
    {
       
        if (textoPuntuacion != null && jugador != null)
        {
            textoPuntuacion.text = "x"+jugador.puntuacion.ToString();
        }
    }
}
