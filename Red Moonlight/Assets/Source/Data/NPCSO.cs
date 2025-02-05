using JetBrains.Annotations;
using System.Collections.Generic;
using UnityEngine;

namespace Data
{
    [CreateAssetMenu(fileName = "NewNpc", menuName = "NPC/NPC",order = 1)]
    public class NPCSO : ScriptableObject
    {
        //TODO СДЕЛАТЬ ДРУГИЕ ИНДЕКСЫ
        [field: SerializeField] public string NPCName { get; private set; }
        [field: SerializeField] public List<DialogSetSO> DialogueSets;
        [field: SerializeField] public Sprite Sprite { get; private set; }
        [field: SerializeField] [ItemCanBeNull] public List<QuestSO> QuestSo { get; private set; }
    }
}
