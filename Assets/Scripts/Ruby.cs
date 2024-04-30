using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ruby : MonoBehaviour
{
    public static Ruby Instance;

    public GameObject clinicCanvas;
    public GameObject saloonDownstairsCanvas;
    public GameObject saloonUpstairsCanvas;
    public GameObject townHallCanvas;

    private void Awake()
    {
        Instance = this;
    }

    // Start is called before the first frame update
    void Start()
    {
        clinicCanvas.SetActive(false);
        saloonDownstairsCanvas.SetActive(false);
        townHallCanvas.SetActive(false);
    }

    public void SetCanvas(string canvas, bool enable)
    {
        if (canvas == "clinic")
        {
            SetClinicCanvas(enable);
            SetSaloonDownstairsCanvas(!enable);
            SetSaloonUpstairsCanvas(!enable);
            SetTownHallCanvas(!enable);
        }

        else if (canvas == "saloondownstairs")
        {
            SetClinicCanvas(!enable);
            SetSaloonDownstairsCanvas(enable);
            SetSaloonUpstairsCanvas(!enable);
            SetTownHallCanvas(!enable);
        }

        else if (canvas == "saloonupstairs")
        {
            SetClinicCanvas(!enable);
            SetSaloonDownstairsCanvas(!enable);
            SetSaloonUpstairsCanvas(enable);
            SetTownHallCanvas(!enable);
        }

        else if (canvas == "townhall")
        {
            SetClinicCanvas(!enable);
            SetSaloonDownstairsCanvas(!enable);
            SetSaloonUpstairsCanvas(!enable);
            SetTownHallCanvas(enable);
        }

    }

    public void SetClinicCanvas(bool enable)
    {
        clinicCanvas.SetActive(enable);
    }

    public void SetSaloonDownstairsCanvas(bool enable)
    {
        saloonDownstairsCanvas.SetActive(enable);
    }
    public void SetSaloonUpstairsCanvas(bool enable)
    {
        saloonUpstairsCanvas.SetActive(enable);
    }

    public void SetTownHallCanvas(bool enable)
    {
        townHallCanvas.SetActive(enable);
    }
}
