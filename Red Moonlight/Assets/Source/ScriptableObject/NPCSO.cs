using System.Collections.Generic;
using UnityEngine;

namespace Core
{
    [CreateAssetMenu(fileName = "NewNpc", menuName = "NPC",order = 1)]
    public class NPCSO : ScriptableObject
    {
        [field: SerializeField] public string NPCName { get; private set; }
        [field: SerializeField] public List<string> Dialogs { get; private set; }
        [field: SerializeField] public Sprite Sprite { get; private set; }
    }
}
