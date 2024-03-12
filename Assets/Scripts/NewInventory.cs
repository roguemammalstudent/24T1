using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class NewInventory : ScriptableObject
{
    public List<ItemData> items = new();
}