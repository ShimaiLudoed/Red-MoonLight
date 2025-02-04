using System.Collections.Generic;
using UnityEngine;

namespace Core
{
  [CreateAssetMenu(fileName = "New Dialog Set", menuName = "NPC/Dialog Set")]
  public class DialogSet : ScriptableObject
  {
    [field: SerializeField] public List<NPCDialogs> Dialogs { get; private set; }
  }
}