using Core;
using Data;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Player
{
    public class NormalQuestBook : AItemContainerView<QuestView, QuestSO>
    {
        [SerializeField] private QuestLog questLog;
        public override void ShowDetails(QuestSO u)
        {
            DetailsText.text = $" Название: {u.QuestName}\nОписание: {u.Description}";
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
            for (int i = 0; i < questLog.GetQuests().Count; i++)
            {
                if (questLog.GetQuests()[i].IsCompleted != true)
                {
                    QuestView questButton = Instantiate(ButtonPrefab, ItemContainer);
                    questButton.GetComponentInChildren<TMP_Text>().text = questLog.GetQuests()[i].QuestName;
                    TMP_Text objectiveText = questButton.transform.Find("QuestObjectiveText").GetComponent<TMP_Text>();
                    var currItem = questLog.GetQuests()[i];
                    if (objectiveText != null)
                    {
                        objectiveText.text = $"Цель: {questLog.GetQuests()[i].Objective}";
                    }

                    questButton.Init(questLog.GetQuests()[i], () => ShowDetails(currItem));
                }
            }
        }
    }
}