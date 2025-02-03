using Core;
using System.Collections.Generic;
using UnityEngine;

namespace Player
{
  public class InventoryViewModel : MonoBehaviour
  {
    private Inventory _inventory;

    public void AddItem(ItemSO itemSo)
    {
      _inventory.AddItem(itemSo);
    }

    public void RemoveItem(int itemID)
    {
      _inventory.RemoveItem(itemID);
    }

    public List<ItemSO> GetItems()
    {
      return _inventory.items;
    }
  }
}