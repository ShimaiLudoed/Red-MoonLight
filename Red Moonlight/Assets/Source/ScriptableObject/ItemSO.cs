using UnityEngine;

namespace Core
{
    [CreateAssetMenu(fileName = "NewItem", menuName = "Inventory/Item")]
    public class ItemSO : ScriptableObject
    {
        public string itemName;
        public string description;
        public Sprite icon; 
        public int id;
    }
}
