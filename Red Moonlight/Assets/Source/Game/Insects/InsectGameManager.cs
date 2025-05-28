using Data;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class InsectGameManager : MonoBehaviour
{
    [SerializeField] private List<Insect> insects = new List<Insect>(); 
    [field:SerializeField] public Transform PoisonousTray{get;private set;}
    [field:SerializeField] public Transform NonPoisonousTray{get;private set;}
    [SerializeField] private TMP_Text resultText; 
    [SerializeField] private int poisonousCount; 
    [SerializeField] private int nonPoisonousCount;
    [SerializeField] private int currentPoisonousCount;
    [SerializeField] private int currentNonPoisonousCount;
    [SerializeField] private QuestSO quest;
    
    private void Start()
    {
        poisonousCount = 0;
        nonPoisonousCount = 0;
        resultText.text = "Сортируйте насекомых!";
    }
    public void PlaceInsect(int index, Transform tray)
    {
        Insect insect = insects[index];
        if (tray == PoisonousTray)
        {
            if (insect.onNonTray == true)
            {
                RemoveInsect(insect.Index, insect.transform);
            }
            if (insect.onTray == false)
            {
                currentPoisonousCount++;
                if (insect.IsVenomous)
                {
                    poisonousCount++;
                }
                insect.onTray = true;
            }
        }
        else if (tray == NonPoisonousTray)
        {
            if (insect.onTray == true)
            {
                RemoveInsect(insect.Index, insect.transform);
            }
            if (insect.onNonTray == false)
            {
                currentNonPoisonousCount++;
                if (!insect.IsVenomous)
                {
                    nonPoisonousCount++;
                }
                insect.onNonTray = true;
            }
        }
        CheckPlacement();
    }
    public void RemoveInsect(int index, Transform tray)
    {
        Insect insect = insects[index];

        if (insect.onTray == false && insect.onNonTray == false)
        {
            return;
        }
        else
        {
            if (insect.onTray == true)
            {
                if (tray != PoisonousTray)
                {
                    currentPoisonousCount--;
                    if (insect.IsVenomous)
                    {
                        poisonousCount--;
                    }
                    insect.onTray = false;
                }
            }

            if (insect.onNonTray == true)
            {
                if (tray != NonPoisonousTray)
                {
                    currentNonPoisonousCount--;
                    if (!insect.IsVenomous)
                    {
                        nonPoisonousCount--;
                    }
                    insect.onNonTray = false;
                }
            }
        }
        CheckPlacement();
    }
    private void CheckPlacement()
    {
        if (poisonousCount + nonPoisonousCount == insects.Count)
        {
            resultText.text = "Поздравляем! Все насекомые расставлены правильно!";
            quest.CompleteQuest();
        }
        else
        {
            if (currentPoisonousCount > 5)
            {
                resultText.text = "Ошибка! В подносе для ядовитых насекомых больше правильных.";
            }
            else if (currentNonPoisonousCount > 3)
            {
                resultText.text = "Ошибка! В подносе для неядовитых насекомых больше правильных.";
            }
            else
            {
                resultText.text = "Некоторые насекомые размещены неправильно.";
            }
        }
    }
    public void ResetGame()
    {
        poisonousCount = 0;
        nonPoisonousCount = 0;
        resultText.text = "Сортируйте насекомых!";
    }
}
