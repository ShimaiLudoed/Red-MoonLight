using System;
using UnityEngine;

namespace Core
{
  [CreateAssetMenu(fileName = "NewItem", menuName = "Inventory/Item")]
  public class ItemSO : ScriptableObject
  {
    [field: SerializeField] public string ItemName { get; private set; }
    [field: SerializeField] public string Description { get; private set; }
    [field: SerializeField] public Sprite Icon { get; private set; }
    [field: SerializeField] public int Id { get; private set; }
    
  }
}
