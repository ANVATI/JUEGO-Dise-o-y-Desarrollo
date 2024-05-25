using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class OtraScena : MonoBehaviour
{
    public void CambiarAEscena()
    {  
        SceneManager.LoadScene("InicialScene");
    }
}
