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

        private void ContinueDialogue()
        {
            if (_currentDialogueIndex < NpcSO.Dialogs.Count)
            {
                string currentDialogue = NpcSO.Dialogs[_currentDialogueIndex];
                Debug.Log($"{NpcSO.NPCName}: {currentDialogue}");

                _currentDialogueIndex++; 
            }
            else
            {
                Debug.Log($"{NpcSO.NPCName}: Разговор завершен.");
                _currentDialogueIndex = 0; 
            }
        }
    }
}