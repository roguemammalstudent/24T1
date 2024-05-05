using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Block : MonoBehaviour
{
    public GameObject wall;
    public PlayerController playerController;

    public void OnTriggerEnter2D(Collider2D other)
    {
        if (wall && other.gameObject.CompareTag("Player") && (playerController.hasCollectedTheBeginning == true )) // And bool spelt correct
        {
            UnlockWay();
        }
    }

    public void UnlockWay()
    {
        wall.SetActive(false);
    }
}
