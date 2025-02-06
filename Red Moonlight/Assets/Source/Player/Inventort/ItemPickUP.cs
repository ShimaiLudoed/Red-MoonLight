using Core;
using Data;
using UnityEngine;
using Utils;

namespace Player
{
  public class ItemPickUP : MonoBehaviour
  {
    [SerializeField] private LayerMask player;
    [SerializeField] private ItemSO item;
    [SerializeField] private Inventory inventory;
    [SerializeField] private QuestSO quest;
    private bool _isInRange;

    private void OnTriggerEnter2D(Collider2D other)
    {
      //TODO Сделать по слою
      if (LayerMaskCheck.ContainsLayer(player, other.gameObject.layer))
      {
        InputListener.OnInteract += PickUP;
        _isInRange = true;
        Debug.Log("Нажмите E, чтобы подобрать предмет: " + item.ItemName);
      }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
      if (LayerMaskCheck.ContainsLayer(player, other.gameObject.layer))
      {
        InputListener.OnInteract -= PickUP;
        _isInRange = false;
      }
    }

    private void PickUP()
    {
      if (_isInRange)
      {
        if (inventory != null)
        {
          inventory.AddItem(item);
          if (quest != null && quest.RequiredItem == item)
          {
            quest.CollectItem();
          }

          InputListener.OnInteract -= PickUP;
          Destroy(gameObject);
        }

      }
    }
  }
}