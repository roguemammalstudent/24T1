using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PossessionCheck : MonoBehaviour
{
    public PlayerController playerController;
    public GameObject haveObjectDialogue;
    public GameObject normalDialogue;
    public GameObject promptButton;
    public GameObject firstImage;
    public GameObject firstLine;

    public GameObject objectButton;
    public GameObject firstObjectImage;
    public GameObject firstObjectLine;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OpenDialogueFroggy()
    {
        if (playerController.hasCollectedTheFroggyHat == true)

        {
            // Go to the text that acknowledges this
            haveObjectDialogue.SetActive(true);
            objectButton.SetActive(true);
            firstObjectImage.SetActive(true);
            firstObjectImage.SetActive(true);
            firstObjectLine.SetActive(true);
        }

        else
        {
            // Go to the text that does NOT acknowledge this
            normalDialogue.SetActive(true);
            promptButton.SetActive(true);
            firstImage.SetActive(true);
            firstImage.SetActive(true);
            firstLine.SetActive(true);
        }
    }

    public void OpenDialogueBottle()
    {
        if (playerController.hasCollectedTheBoozeBottle == true)

        {
            // Go to the text that acknowledges this
            haveObjectDialogue.SetActive(true);
            objectButton.SetActive(true);
            firstObjectImage.SetActive(true);
            firstObjectImage.SetActive(true);
            firstObjectLine.SetActive(true);
        }

        else
        {
            // Go to the text that does NOT acknowledge this
            normalDialogue.SetActive(true);
            promptButton.SetActive(true);
            firstImage.SetActive(true);
            firstImage.SetActive(true);
            firstLine.SetActive(true);
        }
    }
}
