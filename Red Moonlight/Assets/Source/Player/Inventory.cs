using Core;
using System;
using System.Collections.Generic;
using UnityEngine;

namespace Player
{
    public class Inventory : MonoBehaviour
    {
    private List<ItemSO> items = new List<ItemSO>();

    public void AddItem(ItemSO item)
    {
        items.Add(item);
        Debug.Log("Добавлен предмет в инвентарь: " + item.itemName);
    }

    public void ShowInventory()
    {
        if (items.Count == 0)
        {
            Debug.Log("Инвентарь пуст.");
        }
        else
        {
            Debug.Log("Содержимое инвентаря:");
            foreach (var item in items)
            {
                Debug.Log(" - " + item.itemName + " (ID: " + item.id + ")");
            }
        }
    }
    }
}