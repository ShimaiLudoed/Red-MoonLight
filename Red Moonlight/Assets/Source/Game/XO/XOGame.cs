using Data;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
public class XOGame : MonoBehaviour
{
    [SerializeField] private Button[] buttons; 
    [SerializeField] private TMP_Text statusText; // Если вы используете изображение для статуса вместо текста
    [SerializeField] private Sprite playerSprite; 
    [SerializeField] private Sprite botSprite; 
    [SerializeField] private Sprite emptySprite; 
    private string _currentPlayer; 
    private bool _isBotTurn; 
    [SerializeField] private QuestSO quest;
    private void Start()
    {
        _currentPlayer = "X"; 
        _isBotTurn = false; 
        statusText.GetComponent<TMP_Text>().text = "Игрок X, ваш ход!";
        ResetGame(); 
    }
    public void PlayerMove(int index)
    {
        if (buttons[index].GetComponent<Image>().sprite == emptySprite && !_isBotTurn)
        {
            buttons[index].GetComponent<Image>().sprite = playerSprite; 
            CheckForWinner();
            SwitchPlayer();
        }
    }
    private void SwitchPlayer()
    {
        if (_isBotTurn)
        {
            _currentPlayer = "X"; 
            statusText.GetComponent<TMP_Text>().text = "Игрок X, ваш ход!";
            _isBotTurn = false;
        }
        else
        {
            _currentPlayer = "O"; 
            statusText.GetComponent<TMP_Text>().text = $"Ход бота {_currentPlayer}...";
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
            buttons[index].GetComponent<Image>().sprite = botSprite; 
            CheckForWinner();
            SwitchPlayer(); 
        }
    }
    private int GetRandomEmptyCellIndex()
    {
        List<int> emptyCells = new List<int>(); 
        for (int i = 0; i < buttons.Length; i++)
        {
            if (buttons[i].GetComponent<Image>().sprite == emptySprite)
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
            if (buttons[winConditions[i, 0]].GetComponent<Image>().sprite != emptySprite &&
                buttons[winConditions[i, 0]].GetComponent<Image>().sprite ==
                buttons[winConditions[i, 1]].GetComponent<Image>().sprite &&
                buttons[winConditions[i, 1]].GetComponent<Image>().sprite ==
                buttons[winConditions[i, 2]].GetComponent<Image>().sprite)
            {
                string winner = buttons[winConditions[i, 0]].GetComponent<Image>().sprite == playerSprite ? "X" : "O";
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
            if (button.GetComponent<Image>().sprite == emptySprite)
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
        statusText.GetComponent<TMP_Text>().text = result;
        for (int i = 0; i < buttons.Length; i++)
        {
            buttons[i].interactable = false; 
        }
        Debug.Log("Игра окончена: " + result); 
        StartCoroutine(ResetGameAfterDelay(1f));
    }
    private IEnumerator ResetGameAfterDelay(float delay)
    {
        yield return new WaitForSeconds(delay);
        gameObject.SetActive(false);
        ResetGame(); 
    }
    public void ResetGame()
    {
        foreach (Button button in buttons)
        {
            button.GetComponent<Image>().sprite = emptySprite; 
            button.interactable = true; 
        }
        _currentPlayer = "X";
        _isBotTurn = false; 
        statusText.GetComponent<TMP_Text>().text = "Игрок X, ваш ход!";
    }
}