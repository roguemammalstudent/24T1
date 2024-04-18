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



    // Start is called before the first frame update
    void Start()
    {
        Jeans.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        // Blue Flower
        if (playerController.hasCollectedTheBlueFlower == true)
        {
            BlueFlower.SetActive(false);
        }

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

    }

    //public void WakeUp()
    //{

    //}

    //public void KillDie()
    //{

    //}

}
