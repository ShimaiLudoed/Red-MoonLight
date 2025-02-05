using Data;
using UnityEngine;


namespace Data
{
  [CreateAssetMenu(fileName = "New Quest", menuName = "Quest/New Quest")]
  public class QuestSO : ScriptableObject
  {
    [field: SerializeField] public string QuestName { get; private set; }
    [field: SerializeField] public string Description { get; private set; }
    [field: SerializeField] public NPCSO QuestGiver { get; private set; }
    [field: SerializeField] public bool IsCompleted { get; private set; }
  }
}