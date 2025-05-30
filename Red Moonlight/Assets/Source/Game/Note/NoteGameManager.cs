using Data;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class NoteGameManager : MonoBehaviour
{
    [SerializeField] private TMP_Text scoreText; 
    private int _score = 0;
    [SerializeField] private int _winScore;
    [SerializeField] private QuestSO quest;
    void Start()
    {
        UpdateScoreText(); 
    }
    public void AddScore()
    {
        _score++; 
        UpdateScoreText();
        if (_score == _winScore)
        {
            quest.CompleteQuest();
            gameObject.SetActive(false);
        }
    }
    void UpdateScoreText()
    {
        scoreText.text = "Score: " + _score; 
    }
}
