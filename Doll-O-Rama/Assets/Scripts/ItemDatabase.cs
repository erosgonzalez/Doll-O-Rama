using System.Collections.Generic;
using UnityEngine;
using System;

public class ItemDatabase : MonoBehaviour
{
    public List<Item> itemList = new List<Item>();

    public static ItemDatabase instance;
    private void Awake()
    {
        //create singlton
        instance = this;

        //naked
        itemList.Add(new Item(0, "", "", "naked_legs", "Legs"));
        itemList.Add(new Item(1, "", "", "naked_chest", "Chest"));
        itemList.Add(new Item(2, "", "", "bald_head", "Hair"));
        itemList.Add(new Item(3, "", "", "no_beard", "Beard"));
        itemList.Add(new Item(4, "", "", "no_mustache", "Mustache"));
        //itemList.Add(new Item(5, "", "", "empty_hand_r", "HandRight"));
        itemList.Add(new Item(5, "", "", "no_armor", "ChestArmor"));
        itemList.Add(new Item(6, "", "", "naked_slug", "Feet"));
        //clothing
        itemList.Add(new Item(50, "", "", "pants", "Legs", (GameObject)Resources.Load("Assets/Resources/Gear/pants.prefab")));
        itemList.Add(new Item(51, "", "", "boots", "Feet", (GameObject)Resources.Load("Assets/Resources/Gear/boots.prefab")));
        itemList.Add(new Item(53, "", "", "cuirass", "ChestArmor", (GameObject)Resources.Load("Assets/Resources/Gear/cuirass.prefab")));
        itemList.Add(new Item(54, "", "", "gambeson", "Chest", (GameObject)Resources.Load("Assets/Resources/Gear/gambeson.prefab")));
        //weapons
        //itemList.Add(new Item(300, "", "", "halberd", "HandRight", (GameObject)Resources.Load("Gear/halberd")));
        //hair and beard
        itemList.Add(new Item(200, "", "", "long_hair", "Hair", (GameObject)Resources.Load("Assets/Resources/Gear/long_hair.prefab")));
        itemList.Add(new Item(201, "", "", "beard", "Beard", (GameObject)Resources.Load("Assets/Resources/Gear/beard.prefab")));
        itemList.Add(new Item(201, "", "", "mustache", "Mustache", (GameObject)Resources.Load("Assets/Resources/Gear/mustache.prefab")));
    }

    public Item FetchItemByID(int id)
    {
        Console.WriteLine(id);
        for (int i = 0; i < itemList.Count; i++)
        {
            if (itemList[i].ItemID == id)
            {
                return itemList[i];
            }
        }
        return null;
    }

    public Item FetchItemBySlug(string slugName)
    {
        for (int i = 0; i < itemList.Count; i++)
        {

            if (itemList[i].Slug == slugName)
            {
                return itemList[i];
            }
        }
        return null;
    }


}
