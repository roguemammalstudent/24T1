using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActivateDialogue : MonoBehaviour
{
    public GameObject dialogueToActivate;
    public GameObject dialogueButton;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void TurnOnDialogue()
    {
        dialogueToActivate.SetActive(true);
        dialogueButton.SetActive(false);
    }
}
