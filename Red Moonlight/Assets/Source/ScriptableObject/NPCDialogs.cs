using Core;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New NPC Dialogue", menuName = "Dialogue/NPC Dialogue")]
public class NPCDialogs : ScriptableObject
{
  public string dialogueContent;
  public bool givesQuest;
}