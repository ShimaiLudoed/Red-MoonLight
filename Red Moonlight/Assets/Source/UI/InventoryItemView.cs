using Data;
using System;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class InventoryItemView : ItemView<ItemSO>
{
    [SerializeField] private TMP_Text _itemName;
    [SerializeField] private Button _itemButton;
    public override void Init(ItemSO data, Action callback = null)
    {
        if (_itemName != null)
        {
            _itemName.text = data.ItemName; //TODO call Init(U data) from prefab component
        }
        _itemButton.image.sprite = data.Icon;   
        
        if (callback != null)
            _itemButton.onClick.AddListener(() => callback.Invoke());
    }
}
