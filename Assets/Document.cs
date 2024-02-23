using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Document : MonoBehaviour
{
    public GameObject mainCamera;
    public GameObject documentCamera;

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
    }

    public void DeactivateDocument()
    {
        mainCamera.SetActive(true);
        documentCamera.SetActive(false);
    }
}
