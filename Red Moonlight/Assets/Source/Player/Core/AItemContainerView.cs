using Data;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Player
{
    public abstract class AItemContainerView<T, U> : MonoBehaviour
        where T : ItemView<U>
        where U : ScriptableObject
    {
        private bool _isPanelOpen = false;
        protected List<U> _items = new List<U>();
        [SerializeField] protected GameObject _panel;
        [SerializeField] protected T ButtonPrefab;
        [SerializeField] protected Transform ItemContainer;
        [SerializeField] protected TMP_Text DetailsText;
        [SerializeField] protected Image DetailsImage;

        public virtual void AddItem(U item)
        {
            _items.Add(item);
        }

        public virtual void Show()
        {
            _isPanelOpen = !_isPanelOpen;
            _panel.SetActive(_isPanelOpen);
            if (_isPanelOpen)
            {
                DisplayItems();
            }
            else
            {
                ClearItemList();
            }
        }
        public abstract void ShowDetails(U u);
        public virtual void DisplayItems()
        {
            ClearItemList();

            foreach (var item in _items)
            {
                T itemButton = Instantiate(ButtonPrefab, ItemContainer);
                var currItem = item;
                itemButton.Init(item, () => ShowDetails(currItem));
            }
        }
        public virtual void ClearItemList()
        {
            foreach (Transform child in ItemContainer)
            {
                Destroy(child.gameObject);
            }
        }
    }
}
