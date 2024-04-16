using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PossessionCheck : MonoBehaviour
{
    public PlayerController playerController;
    public GameObject haveObjectDialogue;
    public GameObject normalDialogue;

    // Initial dialogue WITHOUT desired object
    public GameObject firstButton;
    public GameObject firstImage;
    public GameObject firstLine;

    // Having the desired object
    public GameObject firstObjectButton;
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
            firstObjectButton.SetActive(true);
            firstObjectImage.SetActive(true);
            firstObjectImage.SetActive(true);
            firstObjectLine.SetActive(true);
        }

        else
        {
            // Go to the text that does NOT acknowledge this
            normalDialogue.SetActive(true);
            firstButton.SetActive(true);
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
            firstObjectButton.SetActive(true);
            firstObjectImage.SetActive(true);
            firstObjectImage.SetActive(true);
            firstObjectLine.SetActive(true);
        }

        else
        {
            // Go to the text that does NOT acknowledge this
            normalDialogue.SetActive(true);
            firstButton.SetActive(true);
            firstImage.SetActive(true);
            firstImage.SetActive(true);
            firstLine.SetActive(true);
        }
    }
}
