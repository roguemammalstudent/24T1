using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class AdvanceLevel : MonoBehaviour
{
    //public GameObject wall;
    //public bool isDone;

    private void Update()
    {
        //if (isDone == true)
        //{
        //    wall.SetActive(false);
        //}

    }

    public void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player")) // And bool spelt correct
        {
            AdvanceToLevel();
        }
    }
    public void AdvanceToLevel()
    {

        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}
