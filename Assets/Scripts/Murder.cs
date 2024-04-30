using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Murder : MonoBehaviour
{
    public PlayerController playerController;

    [Header("Items to Kill and Revive")]
    public GameObject BlueFlower;
    public GameObject FroggyHat;
    public GameObject Jeans;
    public GameObject Jacket;
    public GameObject Boots;
    public GameObject Hat;
    public GameObject John;
    public GameObject johnCanvas;
    public GameObject MemoriamFlower;




    // Start is called before the first frame update
    void Start()
    {
        Jeans.SetActive(false);
        Jacket.SetActive(false);
        if (Boots != null)
        {
            Boots.SetActive(false);
        }
        if (Hat != null)
        {
            Hat.SetActive(false);
        }
        if (MemoriamFlower != null)
        {
            MemoriamFlower.SetActive(false);
        }
    }

    // Update is called once per frame
    void Update()
    {
        // Blue Flower
        if (playerController.hasCollectedTheBlueFlower == true)
        {
            BlueFlower.SetActive(false);
        }

        //if (mainCamera.activeSelf && !playerController.hasCollectedTheAirhorn)
        //{
            //canvas1.SetActive(true);
        //}
        //else
        //{
            //canvas1.SetActive(false);
        //}

        //if (mainCamera.activeSelf && playerController.hasCollectedTheAirhorn)
        //{
            //canvas2.SetActive(true);
        //}
        //else
        //{
            //canvas2.SetActive(false);
        //}

        // Froggy Hat
        if (playerController.hasCollectedTheFroggyHat == true)
        {
            FroggyHat.SetActive(false);
        }

        // Jeans
        if (playerController.hasCollectedTheJeansQuest == true)
        {
            Jeans.SetActive(true);
        }

        if (playerController.hasCollectedThePatientJeans == true)
        {
            Jeans.SetActive(false);
        }

        // Jacket
        if (playerController.hasCollectedTheJacketQuest == true)
        {
            Jacket.SetActive(true);
        }

        if (playerController.hasCollectedThePatientJacket == true)
        {
            Jacket.SetActive(false);
        }

        // Boots
        if (playerController.hasCollectedTheBootsQuest == true)
        {
            Boots.SetActive(true);
        }

        if (playerController.hasCollectedThePatientBoots == true)
        {
            Boots.SetActive(false);
        }

        // Hat
        if (playerController.hasCollectedTheHatQuest == true)
        {
            Hat.SetActive(true);
        }

        if (playerController.hasCollectedThePatientHat == true)
        {
            Hat.SetActive(false);
        }

        if (playerController.hasCollectedTheSheriffBadge == true)
        {
            John.SetActive(false);
            johnCanvas.SetActive(false);
        }

        // Memoriam
        if (playerController.hasCollectedTheMemoriam == false)
        {
            MemoriamFlower.SetActive(false);
        }

        if (playerController.hasCollectedTheMemoriam == true)
        {
            MemoriamFlower.SetActive(true);
        }

    }

    //public void WakeUp()
    //{

    //}

    //public void KillDie()
    //{

    //}

}
