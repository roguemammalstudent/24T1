using System.Collections.Generic;

[System.Serializable]
public class ItemInstance
{
    public ItemData itemType;
    //public int condition;
    //public int ammo;

    public ItemInstance(ItemData itemData)
    {
        itemType = itemData;
        //condition = itemData.startingCondition;
        //ammo = itemData.startingAmmo;
    }

    public ItemData newItemType;
    public List<ItemInstance> items = new();

    void Start()
    {
        items.Add(new ItemInstance(newItemType));
    }

}