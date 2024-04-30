using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{

    public GameObject teleportLocation;
    public GameObject returnLocation;
    public GameObject teleportLocationCamera;
    public GameObject playerController;

    public GameObject mainCamera;

    public void Teleport(string canvas)
    {
        playerController.transform.position = teleportLocation.transform.position;
        teleportLocationCamera.SetActive(true);
        mainCamera.SetActive(false);
        Kyle.Instance.SetCanvas(canvas, true);
        Ruby.Instance.SetCanvas(canvas, true);
        //teleportLocationCamera.SetActive(true);
    }

    public void Return(string canvas)
    {
        playerController.transform.position = returnLocation.transform.position;
        mainCamera.SetActive(true);
        teleportLocationCamera.SetActive(false);
        Kyle.Instance.SetCanvas(canvas, false);
        Ruby.Instance.SetCanvas(canvas, false);
    }
}
