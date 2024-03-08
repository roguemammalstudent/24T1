using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;


public class Inventory : MonoBehaviour
{
    public TextMeshProUGUI eyepartsText;
    public TextMeshProUGUI corepartsText;
    public TextMeshProUGUI moneyText;

    public int moneyValue = 0;


    public void UpdateEyesDisplay(int eyepartsValue)
    {
        if (eyepartsText != null)
        eyepartsText.text = "X " + eyepartsValue.ToString();
    }


    public void UpdateCoreDisplay(int corepartsValue)
    {
        if (corepartsText != null)
        corepartsText.text = "X " + corepartsValue.ToString();
    }
}
