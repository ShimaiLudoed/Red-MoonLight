using Core;
using Data;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using static UnityEditor.Progress;

namespace Player
{
    public class NormalQuestBook : AItemContainerView<QuestView, QuestSO>
    {
        [SerializeField] private QuestLog questLog;
        public override void ShowDetails(QuestSO u)
        {
            DetailsText.text = $" Название: {u.QuestName}\nОписание: {u.Description} состояние : {u.IsCompleted}";
            if (u.QuestGiver.Image != null && DetailsImage != null)
            {
                DetailsImage.sprite = u.QuestGiver.Image;
                DetailsImage.gameObject.SetActive(true);
            }
            else
            {
                DetailsImage.gameObject.SetActive(false);
            }
        }

        public override void DisplayItems()
        {
            ClearItemList();

            foreach (var quest in questLog.GetQuests())
            {
                QuestView questButton = Instantiate(ButtonPrefab, ItemContainer);
                questButton.GetComponentInChildren<TMP_Text>().text = quest.QuestName;
                TMP_Text objectiveText = questButton.transform.Find("QuestObjectiveText").GetComponent<TMP_Text>();
                var currItem = quest;
                if (objectiveText != null)
                {
                    objectiveText.text = $"Цель: {quest.Objective}";
                }
                questButton.Init(quest, () => ShowDetails(currItem));
            }
        }
    }
}