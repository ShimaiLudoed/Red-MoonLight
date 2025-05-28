using Data;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class XOGame : MonoBehaviour
{
    [SerializeField] private Button[] buttons; 
    [SerializeField] private TMP_Text statusText; 
    private string _currentPlayer; 
    private bool _isBotTurn; 
    [SerializeField] private QuestSO quest;
    private void Start()
    {
        _currentPlayer = "X"; 
        _isBotTurn = false; 
        statusText.text = "Игрок X, ваш ход!";
        ResetGame(); 
    }
    public void PlayerMove(int index)
    {
        if (buttons[index].GetComponentInChildren<TMP_Text>().text == "" && !_isBotTurn)
        {
            buttons[index].GetComponentInChildren<TMP_Text>().text = _currentPlayer;
            CheckForWinner();
            SwitchPlayer();
        }
    }
    private void SwitchPlayer()
    {
        if (_isBotTurn)
        {
            _currentPlayer = "X"; 
            statusText.text = "Игрок X, ваш ход!";
            _isBotTurn = false;
        }
        else
        {
            _currentPlayer = "O"; 
            statusText.text = $"Ход бота {_currentPlayer}...";
            _isBotTurn = true;
            StartCoroutine(BotMove());
        }
    }
    private IEnumerator BotMove()
    {
        yield return new WaitForSeconds(1); 
        int index = GetRandomEmptyCellIndex();
        if (index != -1)
        {
            buttons[index].GetComponentInChildren<TMP_Text>().text = _currentPlayer;
            CheckForWinner();
            SwitchPlayer(); 
        }
    }
    private int GetRandomEmptyCellIndex()
    {
        List<int> emptyCells = new List<int>(); 
        for (int i = 0; i < buttons.Length; i++)
        {
            if (buttons[i].GetComponentInChildren<TMP_Text>().text == "")
            {
                emptyCells.Add(i);
            }
        }
        if (emptyCells.Count > 0)
        {
            return emptyCells[Random.Range(0, emptyCells.Count)];
        }
        return -1; 
    }
    private void CheckForWinner()
    {
        int[,] winConditions = new int[,]
        {
            {0, 1, 2},
            {3, 4, 5},
            {6, 7, 8},
            {0, 3, 6},
            {1, 4, 7},
            {2, 5, 8},
            {0, 4, 8},
            {2, 4, 6}
        };
        for (int i = 0; i < winConditions.GetLength(0); i++)
        {
            if (buttons[winConditions[i, 0]].GetComponentInChildren<TMP_Text>().text != ""
                && buttons[winConditions[i, 0]].GetComponentInChildren<TMP_Text>().text
                == buttons[winConditions[i, 1]].GetComponentInChildren<TMP_Text>().text
                && buttons[winConditions[i, 1]].GetComponentInChildren<TMP_Text>().text
                == buttons[winConditions[i, 2]].GetComponentInChildren<TMP_Text>().text)
            {
                string winner = buttons[winConditions[i, 0]].GetComponentInChildren<TMP_Text>().text;
                if (winner == "X")
                {
                    quest.CompleteQuest();
                    Debug.Log("Игрок X выиграл!"); 
                }
                else if (winner == "O")
                {
                    Debug.Log("Бот O выиграл!"); 
                }
                EndGame(winner + " выиграл!");
                return;
            }
        }
        bool isDraw = true;
        foreach (Button button in buttons)
        {
            if (button.GetComponentInChildren<TMP_Text>().text == "")
            {
                isDraw = false;
                break;
            }
        }
        if (isDraw)
        {
            EndGame("Ничья!");
            Debug.Log("Ничья!"); 
        }
    }
    private void EndGame(string result)
    {
        statusText.text = result;
        for (int i = 0; i < buttons.Length; i++)
        {
            buttons[i].interactable = false; 
        }
        Debug.Log("Игра окончена: " + result); 
    }
    public void ResetGame()
    {
        foreach (Button button in buttons)
        {
            button.GetComponentInChildren<TMP_Text>().text = ""; 
            button.interactable = true; 
        }
        _currentPlayer = "X";
        _isBotTurn = false; 
        statusText.text = "Игрок X, ваш ход!";
    }
}