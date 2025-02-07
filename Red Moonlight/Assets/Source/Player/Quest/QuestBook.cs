using Core;
using Data;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

namespace Player
{
    public class QuestBook : MonoBehaviour
    {
        [SerializeField] private QuestLog questLog;
        [SerializeField] private GameObject questPanel;
        [SerializeField] private Button questButtonPrefab;
        [SerializeField] private Transform questListContainer;
        [SerializeField] private TMP_Text questDetailsText;
        [SerializeField] private Image questDetailsImage;

        private bool _isQuestPanelOpen = false;

        void Update()
        {
            if (Input.GetKeyDown(KeyCode.Q))
            {
                ToggleQuestPanel();
            }
        }

        public void ToggleQuestPanel()
        {
            _isQuestPanelOpen = !_isQuestPanelOpen;
            questPanel.SetActive(_isQuestPanelOpen);

            if (_isQuestPanelOpen)
            {
                DisplayQuests();
            }
            else
            {
                ClearQuestList();
            }
        }

        void DisplayQuests()
        {
            ClearQuestList();

            foreach (var quest in questLog.GetQuests())
            {
                Button questButton = Instantiate(questButtonPrefab, questListContainer);
                questButton.GetComponentInChildren<TMP_Text>().text = quest.QuestName;
                TMP_Text objectiveText = questButton.transform.Find("QuestObjectiveText").GetComponent<TMP_Text>();
                if (objectiveText != null)
                {
                    objectiveText.text = $"Цель: {quest.Objective}";
                }

             
                questButton.onClick.AddListener(() => ShowQuestDetails(quest));
            }
        }

        void ShowQuestDetails(QuestSO quest)
        {
           
            questDetailsText.text = $" Название: {quest.QuestName}\nОписание: {quest.Description} состояние : {quest.IsCompleted}";
            if (quest.QuestGiver.Image != null && questDetailsImage != null)
            {
                questDetailsImage.sprite = quest.QuestGiver.Image;
                questDetailsImage.gameObject.SetActive(true);
            }
            else
            {
                questDetailsImage.gameObject.SetActive(false);
            }
        }

        void ClearQuestList()
        {
            foreach (Transform child in questListContainer)
            {
                Destroy(child.gameObject);
            }

            if (questDetailsImage != null)
            { 
                //questDetailsImage.gameObject.SetActive(false); 
               // questDetailsImage.sprite = null; 
            }
        }
    }
}