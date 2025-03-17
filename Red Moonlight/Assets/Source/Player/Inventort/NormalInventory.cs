using Data;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Player
{
    public class NormalInventory : AItemContainerView<InventoryItemView, ItemSO>
    {
        public override void ShowDetails(ItemSO u)
        {
            throw new System.NotImplementedException();
        }
    }
}