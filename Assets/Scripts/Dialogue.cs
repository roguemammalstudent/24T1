using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dialogue : MonoBehaviour
{
    public GameObject dialogueBoxUI;
    public GameObject dialogueUI; // Assign your UI GameObject in the Inspector

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            if (dialogueUI != null)
            dialogueUI.SetActive(true);
            if (dialogueBoxUI != null)
            dialogueBoxUI.SetActive(true);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (dialogueUI != null)
        dialogueUI.SetActive(false);
        if (dialogueBoxUI != null)
        dialogueBoxUI.SetActive(false);
    }
}