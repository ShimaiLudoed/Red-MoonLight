using Data;
using UnityEngine;


namespace Data
{
  [CreateAssetMenu(fileName = "New Quest", menuName = "Quest/New Quest")]
  public class QuestSO : ScriptableObject
  {
    [field: SerializeField] public string QuestName { get; private set; }
    [field: SerializeField] public string Description { get; private set; }
    [field: SerializeField] public string Objective { get; private set; }
    [field: SerializeField] public NPCSO QuestGiver { get; private set; }
    [field: SerializeField] public bool IsCompleted { get; private set; }
    [field: SerializeField] private bool _isItemCollected = false;
    [field: SerializeField] public ItemSO RequiredItem { get; private set; }

    public void CollectItem()
    {
      _isItemCollected = true;
      Debug.Log($"Предмет {RequiredItem.ItemName} собран для квеста {QuestName}!");
    }

    public void TryCompleteQuest()
    {
      if (_isItemCollected)
      {
        CompleteQuest();
      }
    }

    public void CompleteQuest()
    {
      IsCompleted = true;
      Debug.Log($"Квест {QuestName} завершен!");
    }
  }
}