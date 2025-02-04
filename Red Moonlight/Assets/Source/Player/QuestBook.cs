using Player;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class QuestBook : MonoBehaviour
{
    public QuestLog playerNotebook; // Ссылка на блокнот игрока

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Q))
        {
            DisplayQuests();
        }
    }

    // Метод для отображения квестов
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
            Debug.Log($"{quest.questName}: {quest.description} - Завершен: {quest.isCompleted} выдан: {quest.questGiver.NPCName}");
        }
    }
}
