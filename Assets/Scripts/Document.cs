using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Document : MonoBehaviour
{
    public GameObject mainCamera;
    public GameObject documentCamera;
    public PlayerController playerController;
    public string activateFunction;
    public string deactivateFunction;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void ActivateDocument()
    {
        mainCamera.SetActive(false);
        documentCamera.SetActive(true);
        playerController.Invoke(activateFunction, 0);
    }

    public void DeactivateDocument()
    {
        mainCamera.SetActive(true);
        documentCamera.SetActive(false);
        playerController.Invoke(deactivateFunction, 0);
    }
}
