using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Formation : MonoBehaviour
{
    
    public List<GameObject> birds = new List<GameObject>();
    public List<GameObject> targetPositions = new List<GameObject>();

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    { // for every bird in the birds array, we want to move them to the target positions
        for (int i = 0; i < birds.Count; i++)
        {
            birds[i].transform.position = targetPositions[i].transform.position;
        
        }
    }
}
