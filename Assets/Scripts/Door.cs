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

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Teleport()
    {
        playerController.transform.position = teleportLocation.transform.position;
        teleportLocationCamera.SetActive(true);
        mainCamera.SetActive(false);
        teleportLocationCamera.SetActive(true);
    }

    public void Return()
    {
        playerController.transform.position = returnLocation.transform.position;
        mainCamera.SetActive(true);
        teleportLocationCamera.SetActive(false);
    }
}
