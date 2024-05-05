using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Kyle : MonoBehaviour
{
    public static Kyle Instance;

    public GameObject orphanCanvas;
    public GameObject saloonBalconyCanvas;
    public GameObject ladderTopCanvas;

    private void Awake()
    {
        Instance = this;
    }

    // Start is called before the first frame update
    void Start()
    {
        orphanCanvas.SetActive(false);
        saloonBalconyCanvas.SetActive(false);
        ladderTopCanvas.SetActive(false);
    }

    public void SetCanvas(string canvas, bool enable)
    {
        if (canvas == "orphan")
        {
            SetOrphanCanvas(enable);
            SetSaloonBalconyCanvas(!enable);
            SetLadderTopCanvas(!enable);
        }
        else if (canvas == "saloon")
        {
            SetOrphanCanvas(!enable);
            SetSaloonBalconyCanvas(enable);
            SetLadderTopCanvas(enable);
        }
        else if (canvas == "laddertop")
        {
            SetOrphanCanvas(!enable);
            SetSaloonBalconyCanvas(enable);
            SetLadderTopCanvas(enable);
        }
    }

    public void SetOrphanCanvas(bool enable)
    {
        orphanCanvas.SetActive(enable);
    }

    public void SetSaloonBalconyCanvas(bool enable)
    {
        saloonBalconyCanvas.SetActive(enable);
    }

    public void SetLadderTopCanvas(bool enable)
    {
        ladderTopCanvas.SetActive(enable);
    }
}
