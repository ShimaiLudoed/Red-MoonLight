using Data;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using static UnityEditor.Progress;

namespace Player
{
    public class NormalInventory : AItemContainerView<InventoryItemView, ItemSO>
    {
        public override void ShowDetails(ItemSO u)
        {
            DetailsText.text = $" Название: {u.ItemName} \nnОписание: {u.Description}";
            if (u.Icon != null && DetailsImage != null)
            {
                DetailsImage.sprite = u.Icon;
                DetailsImage.gameObject.SetActive(true);
            }
            else
            {
                DetailsImage.gameObject.SetActive(false);
            }
        }
    }
}