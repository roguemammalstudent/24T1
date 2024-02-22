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
        if (gameObject.CompareTag("Right") && other.gameObject.CompareTag("Player")) // And bool spelt correct
        {
            AdvanceToLevel();
        }


        if (gameObject.CompareTag("Left") && other.gameObject.CompareTag("Player")) // And bool spelt correct
        {
            AdvanceBackLevel();
        }

        if (gameObject.CompareTag("Death") && other.gameObject.CompareTag("Player")) // And bool spelt correct
        {
            AdvanceDeathLevel();
        }

    }
    public void AdvanceToLevel()
    {

        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }


    public void AdvanceBackLevel()
    {

        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
    }

    public void AdvanceDeathLevel()
    {

        SceneManager.LoadScene("DeathScene");
    }
}
