using Data;
using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class InventoryItemView : ItemView<ItemSO>
{
    [SerializeField] private TMP_Text _itemName;
    [SerializeField] private Button _itemButton;
    public override void Init(ItemSO data, Action callback = null)
    {
        _itemName.text = data.ItemName; //TODO call Init(U data) from prefab component

        if (callback != null)
            _itemButton.onClick.AddListener(() => callback.Invoke());
    }
}
