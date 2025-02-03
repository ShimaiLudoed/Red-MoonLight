using Core;
using UnityEngine;

namespace Player
{
  public class ItemPickUP : MonoBehaviour
  {
    public ItemSO item; // Ссылка на предмет

    private void OnTriggerEnter(Collider other)
    {
      if (other.CompareTag("Player")) // Предполагаем, что игрок имеет тег "Player"
      {
        Inventory inventory = other.GetComponent<Inventory>();
        if (inventory != null)
        {
          inventory.AddItem(item);
          Destroy(gameObject); // Удаляем предмет после подбора
        }
      }
    }
  }
}