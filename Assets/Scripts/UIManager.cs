using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    public GameObject[] hearts;

    public void UpdateHearts(int life)
    {

        for (int i = 0; i < hearts.Length; i++)
        {
            if (i >= life && hearts[i] != null)
            {
                Destroy(hearts[i]);
                hearts[i] = null; 
            }
        }
    }
}
