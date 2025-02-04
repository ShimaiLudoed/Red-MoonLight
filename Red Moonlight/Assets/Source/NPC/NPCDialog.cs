using Core;
using Player;
using UnityEngine;
using UnityEngine.Serialization;

namespace NPC
{
    public class NPCDialog : MonoBehaviour
    {
        [FormerlySerializedAs("Npcso")]
        public NPCSO NpcSO;
        private bool _isInRange; 
        private int _currentDialogueIndex = 0;
        private int _currentSetIndex = 0;
        private QuestLog _playerNotebook;

        private void Start()
        {
            _playerNotebook = FindObjectOfType<QuestLog>(); // Находим блокнот игрока
        }

        private void OnTriggerEnter2D(Collider2D other)
        {
            if (other.CompareTag("Player"))
            {
                InputListener.OnInteract += HandleInteract;
                _isInRange = true;
                Debug.Log($"{NpcSO.NPCName}: Нажмите E, чтобы поговорить с NPC");
            }
        }

        private void OnTriggerExit2D(Collider2D other)
        {
            if (other.CompareTag("Player"))
            {
                InputListener.OnInteract -= HandleInteract;
                _isInRange = false; 
                _currentDialogueIndex = 0; 
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
                Debug.Log($"{NpcSO.NPCName}: Нет доступных наборов диалогов.");
                return;
            }

            if (_currentSetIndex < NpcSO.DialogueSets.Count)
            {
                UseCurrentDialogueSet();
            }
            else
            {
                Debug.Log($"{NpcSO.NPCName}: Все наборы диалогов исчерпаны.");
            }
        }
        
        private void UseCurrentDialogueSet()
        {
            var currentDialogSet = NpcSO.DialogueSets[_currentSetIndex];

            if (_currentDialogueIndex < currentDialogSet.Dialogs.Count)
            {
                var currentDialogue = currentDialogSet.Dialogs[_currentDialogueIndex];
                Debug.Log($"{NpcSO.NPCName}: {currentDialogue.dialogueContent}");
                
                if (currentDialogue.givesQuest)
                {
                    AssignQuest();
                }

                _currentDialogueIndex++; 
            }
            else
            {
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
                Debug.Log($"Квест добавлен: {questToAssign.questName}");
                _currentDialogueIndex++; 
            }
            else
            {
                Debug.Log($"{NpcSO.NPCName}: Нет доступных квестов для этого набора диалогов.");
            }
        }
        
    }
}