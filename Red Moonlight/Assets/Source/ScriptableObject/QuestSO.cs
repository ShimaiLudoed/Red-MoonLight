using Core;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Quest", menuName = "Quest/New Quest")]
public class QuestSO : ScriptableObject
{
  public string questName; // Название квеста
  public string description; // Описание квеста
  public NPCSO questGiver; // NPC, дающий квест
  public bool isCompleted;
}
