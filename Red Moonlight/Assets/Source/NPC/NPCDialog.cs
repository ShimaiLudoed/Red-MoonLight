using Core;
using Data;
using UnityEngine;
using Utils;
using TMPro;

namespace NPC
{
    public class NpcDialog : MonoBehaviour
    {
        [SerializeField] private LayerMask player;
        //TODO внедрить call back
        [SerializeField] NPCSO NpcSO;
        private bool _isInRange;
        private int _currentDialogueIndex = 0;
        private int _currentSetIndex = 0;
        [SerializeField] private QuestLog _playerNotebook;
        [SerializeField] private GameObject dialoguePanel; 
        [SerializeField] private TMP_Text dialogueText;    
        
        
        private void Start()
        {
            dialoguePanel.SetActive(false);
        }
        
        private void OnTriggerEnter2D(Collider2D other)
        {
            if (LayerMaskCheck.ContainsLayer(player, other.gameObject.layer))
            {
                InputListener.OnInteract += HandleInteract;
                _isInRange = true;
                Debug.Log($"{NpcSO.NPCName}: Нажмите E, чтобы поговорить с NPC");
            }
        }

        private void OnTriggerExit2D(Collider2D other)
        {
            if (LayerMaskCheck.ContainsLayer(player, other.gameObject.layer))
            {
                InputListener.OnInteract -= HandleInteract;
                _isInRange = false;
                _currentDialogueIndex = 0;
                dialoguePanel.SetActive(false);
            }
        }

        private void HandleInteract()
        {
            if (_isInRange)
            {
                ContinueDialogue();
            }
        }

        public void ContinueDialogue()
        {
            if (NpcSO.DialogueSets == null || NpcSO.DialogueSets.Count == 0)
            {
                dialoguePanel.SetActive(false); 
                Debug.Log($"{NpcSO.NPCName}: Нет доступных наборов диалогов.");
                return;
            }

            if (_currentSetIndex < NpcSO.DialogueSets.Count)
            {
                dialoguePanel.SetActive(true);
                UseCurrentDialogueSet();
            }
            else
            {
                Debug.Log($"{NpcSO.NPCName}: Все наборы диалогов исчерпаны.");
                dialoguePanel.SetActive(false); 
            }
        }

        private void UseCurrentDialogueSet()
        {
            var currentDialogSet = NpcSO.DialogueSets[_currentSetIndex];

            if (_currentDialogueIndex < currentDialogSet.Dialogs.Count)
            {
                var currentDialogue = currentDialogSet.Dialogs[_currentDialogueIndex];
                dialogueText.text = $"{NpcSO.NPCName}: {currentDialogue.DialogueContent}";
                Debug.Log($"{NpcSO.NPCName}: {currentDialogue.DialogueContent}");

                if (currentDialogue.GivesQuest)
                {
                    AssignQuest();
                }

                _currentDialogueIndex++;
            }
            else
            {
                dialoguePanel.SetActive(false); 
                Debug.Log($"{NpcSO.NPCName}: Разговор с набором {_currentSetIndex + 1} завершен.");
                _currentSetIndex++;
                _currentDialogueIndex = 0;
            }
        }

        private void AssignQuest()
        {
            if (_currentSetIndex < NpcSO.QuestSo.Count)
            {
                var questToAssign = NpcSO.QuestSo[_currentSetIndex];
                _playerNotebook.AddQuest(questToAssign);
                Debug.Log($"Квест добавлен: {questToAssign.QuestName}");
                _currentDialogueIndex++;
            }
            else
            {
                Debug.Log($"{NpcSO.NPCName}: Нет доступных квестов для этого набора диалогов.");
            }
        }
    }
}
