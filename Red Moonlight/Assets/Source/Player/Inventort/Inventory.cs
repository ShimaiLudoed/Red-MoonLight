using Data;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Player
{
    public class Inventory : MonoBehaviour
    {
        private bool _isInventoryPanelOpen = false;
        
        private List<ItemSO> _items = new List<ItemSO>();
        [SerializeField] private GameObject inventoryPanel;
        [SerializeField] private Button ItemButtonPrefab;
        [SerializeField] private Transform ItemContainer;
        [SerializeField] private TMP_Text ItemDetailsText;
        [SerializeField] private Image ItemDetailsImage;

        public void AddItem(ItemSO item)
        {
            _items.Add(item);
            Debug.Log("Добавлен предмет в инвентарь: " + item.ItemName);
        }

        public void ShowInventory()
        {
            _isInventoryPanelOpen = !_isInventoryPanelOpen;
            inventoryPanel.SetActive(_isInventoryPanelOpen);
            if (_isInventoryPanelOpen)
            {
                DisplayItems();
            }
            else
            {
                ClearItemList();
            }
        }

        void DisplayItems()
        {
            ClearItemList();

            foreach (var item in _items)
            {
                Button itemButton = Instantiate(ItemButtonPrefab, ItemContainer);
                itemButton.GetComponentInChildren<TMP_Text>().text = item.ItemName; //TODO call Init(U data) from prefab component
                Debug.Log(" - " + item.ItemName + " (ID: " + item.Id + ")");

                itemButton.onClick.AddListener(() => ShowItemDetails(item));
            }
        }

        void ShowItemDetails(ItemSO itemSo)
        {

            ItemDetailsText.text = $" Название: {itemSo.ItemName} \nОписание: {itemSo.Description}";
            if (itemSo.Icon != null && ItemDetailsImage != null)
            {
                ItemDetailsImage.sprite = itemSo.Icon;
                ItemDetailsImage.gameObject.SetActive(true);
            }
            else
            {
                ItemDetailsImage.gameObject.SetActive(false);
            }
        }

        void ClearItemList()
        {
            foreach (Transform child in ItemContainer)
            {
                Destroy(child.gameObject);
            }

            if (ItemDetailsImage != null)
            {
                //questDetailsImage.gameObject.SetActive(false);
                // questDetailsImage.sprite = null;
            }
        }
    }
}
 