using UnityEngine;

namespace Data
{
  [CreateAssetMenu(fileName = "New NPC Dialogue", menuName = "Dialogue/NPC Dialogue")]
  public class NPCDialogsSO : ScriptableObject
  {
    [field: SerializeField] public string DialogueContent { get; private set; }
    [field: SerializeField] public bool GivesQuest { get; private set; }
  }
}