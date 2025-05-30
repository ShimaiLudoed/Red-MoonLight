using Data;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WinStars : MonoBehaviour
{
  [SerializeField] private QuestSO quest;
  private void Start()
  {
    Telescope.onWin += Win;
  }
  private void Win()
  {
    gameObject.SetActive(false);
    Debug.Log("опял");
    quest.CompleteQuest();
  }
}
