using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class NPCController : MonoBehaviour
{
    public GameObject interactionUI; 
    public Text interactionText; 
 

    public GameObject dialogueUI; 
    public Text dialogueText; 
   

    private bool isPlayerNearby = false; 

    void Start()
    {
        interactionUI.SetActive(false); 
        dialogueUI.SetActive(false); 
    }

    void Update()
    {
        if (isPlayerNearby && Input.GetKeyDown(KeyCode.E))
        {
         
            dialogueUI.SetActive(true);
 
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            
            isPlayerNearby = true;
            interactionUI.SetActive(true);
           
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
           
            isPlayerNearby = false;
            interactionUI.SetActive(false);
            dialogueUI.SetActive(false);
        }
    }
}
