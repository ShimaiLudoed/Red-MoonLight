using Core;
using Player;
using UnityEngine;

namespace Player
{
    public class QuestBook : MonoBehaviour
    {
        [SerializeField] private QuestLog playerNotebook;

        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.Q))
            {
                DisplayQuests();
            }
        }

        private void DisplayQuests()
        {
            if (playerNotebook.GetQuests().Count == 0)
            {
                Debug.Log("У вас нет квестов.");
                return;
            }

            Debug.Log("Список ваших квестов:");
            foreach (var quest in playerNotebook.GetQuests())
            {
                Debug.Log($"{quest.QuestName}: {quest.Description} - Завершен: {quest.IsCompleted} выдан: {quest.QuestGiver.NPCName}");
            }
        }
    }
}