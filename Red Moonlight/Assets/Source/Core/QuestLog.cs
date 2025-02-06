using Data;
using System.Collections.Generic;
using UnityEngine;

namespace Core
{
    public class QuestLog : MonoBehaviour
    {
       [SerializeField] private List<QuestSO> quests = new List<QuestSO>();

        public void AddQuest(QuestSO quest)
        {
            if (!quests.Contains(quest))
            {
                quests.Add(quest);
                Debug.Log($"Квест добавлен: {quest.QuestName}");
            }
        }

        public List<QuestSO> GetQuests()
        {
            return quests;
        }
    }
}