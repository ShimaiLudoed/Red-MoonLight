using Core;
using System;
using System.Collections.Generic;
using UnityEngine;

namespace Player
{
    [Serializable]
    public class Inventory
    {
        public List<ItemSO> items = new List<ItemSO>();

        public void AddItem(ItemSO itemSo)
        {
            items.Add(itemSo);
            Debug.Log("Добавлен предмет: " + itemSo.itemName);
        }

        public void RemoveItem(int itemID)
        {
            ItemSO itemToUse = items.Find(item => item.id == itemID);
            if (itemToUse != null)
            {
                Debug.Log("Используется предмет: " + itemToUse.itemName);
                items.Remove(itemToUse);
                Debug.Log("Предмет убран из инвентаря. Осталось предметов: " + items.Count);
            }
            else
            {
                Debug.Log("Предмет с ID " + itemID + " не найден в инвентаре.");
            }
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