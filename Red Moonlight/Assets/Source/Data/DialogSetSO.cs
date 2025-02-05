using System.Collections.Generic;
using UnityEngine;

namespace Data
{
  [CreateAssetMenu(fileName = "New Dialog Set", menuName = "NPC/Dialog Set")]
  public class DialogSetSO : ScriptableObject
  {
    [field: SerializeField] public List<NPCDialogsSO> Dialogs { get; private set; }
  }
}