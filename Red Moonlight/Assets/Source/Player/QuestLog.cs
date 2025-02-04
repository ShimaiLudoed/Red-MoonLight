using System.Collections.Generic;
using UnityEngine;

namespace Player
{
    public class QuestLog : MonoBehaviour
    {
        public List<QuestSO> quests = new List<QuestSO>();

        // Метод для добавления квеста
        public void AddQuest(QuestSO quest)
        {
            if (!quests.Contains(quest))
            {
                quests.Add(quest);
                Debug.Log($"Квест добавлен: {quest.questName}");
            }
        }

        // Метод для получения списка квестов
        public List<QuestSO> GetQuests()
        {
            return quests;
        }
    }
}