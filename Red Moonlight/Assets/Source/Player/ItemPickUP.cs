using Core;
using UnityEngine;

namespace Player
{
  public class ItemPickUP : MonoBehaviour
  {
    public ItemSO item; // Ссылка на ScriptableObject
    [SerializeField] private Inventory inventory;
    private bool _isInRange; // Флаг для проверки, находится ли игрок в зоне подбора

    private void OnTriggerEnter2D(Collider2D other)
    {
      if (other.CompareTag("Player"))
      {
        InputListener.OnPickupItem += PickUP;
        _isInRange = true; // Игрок вошел в зону действия
        Debug.Log("Нажмите E, чтобы подобрать предмет: " + item.itemName);
      }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
      if (other.CompareTag("Player"))
      {
        InputListener.OnPickupItem -= PickUP;
        _isInRange = false; // Игрок вышел из зоны действия
      }
    }

    private void PickUP()
    {
      // Проверяем, если игрок в зоне подбора и нажал клавишу "E"
      if (_isInRange)
      {
        if (inventory != null)
        {
          inventory.AddItem(item); // Добавляем предмет в инвентарь
          Destroy(gameObject); // Удаляем предмет после подбора
        }
      }  
    }
  }
}