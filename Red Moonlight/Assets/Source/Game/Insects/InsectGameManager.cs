using Data;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class InsectGameManager : MonoBehaviour
{
    [SerializeField] private List<Insect> insects = new List<Insect>(); 
    [field: SerializeField] public Transform PoisonousTray { get; private set; }
    [field: SerializeField] public Transform NonPoisonousTray { get; private set; }
    [SerializeField] private TMP_Text resultText;
    private int _currentPoisonousCount;
    private int _currentNonPoisonousCount;
    [SerializeField] private QuestSO quest;
    private List<Vector3> initialPositions = new List<Vector3>();
    private void Start()
    {
        foreach (Insect insect in insects)
        {
            initialPositions.Add(insect.transform.position);
        }
        
        ResetGame();
    }
    public void PlaceInsect(int index, Transform tray)
    {
        Insect insect = insects[index];
        if (insect.onTray || insect.onNonTray) return;
        if (tray == PoisonousTray)
        {
            if (insect.IsVenomous)
            {
                _currentPoisonousCount++;
                resultText.text = "Правильный выбор! Ядовитое насекомое размещено.";
                insect.onTray = true;
                insect.gameObject.SetActive(false); 
            }
            else
            {
                resultText.text = "Неправильный выбор! Это не ядовитое насекомое.";
            }
        }
        else if (tray == NonPoisonousTray)
        {
            if (!insect.IsVenomous)
            {
                _currentNonPoisonousCount++;
                resultText.text = "Правильный выбор! Непядовитое насекомое размещено.";
                insect.onNonTray = true;
                insect.gameObject.SetActive(false); 
            }
            else
            {
                resultText.text = "Неправильный выбор! Это ядовитое насекомое.";
            }
        }
        CheckPlacement();
    }
    public void RemoveInsect(int index, Transform tray)
    {
        Insect insect = insects[index];
        if (insect.onTray)
        {
            _currentPoisonousCount--;
            insect.onTray = false;
        }
        else if (insect.onNonTray)
        {
            _currentNonPoisonousCount--;
            insect.onNonTray = false;
        }
        CheckPlacement();
    }
    private void CheckPlacement()
    {
        if (_currentPoisonousCount + _currentNonPoisonousCount == insects.Count)
        {
            resultText.text = "Поздравляем! Все насекомые расставлены правильно!";
            quest.CompleteQuest();
            StartCoroutine(RestartGameAfterDelay(2f));
        }
        else
        {
            if (_currentPoisonousCount > 5)
            {
                resultText.text = "Ошибка! В подносе для ядовитых насекомых больше правильных.";
            }
            else if (_currentNonPoisonousCount > 3)
            {
                resultText.text = "Ошибка! В подносе для неядовитых насекомых больше правильных.";
            }
        }
    }
    private IEnumerator RestartGameAfterDelay(float delay)
    {
        yield return new WaitForSeconds(delay);
        ResetGame();
        gameObject.SetActive(false);
    }
    public void ResetGame()
    {
        _currentPoisonousCount = 0;
        _currentNonPoisonousCount = 0;
        resultText.text = "Сортируйте насекомых!";
        for (int i = 0; i < insects.Count; i++)
        {
            insects[i].transform.position = initialPositions[i]; 
            insects[i].gameObject.SetActive(true); 
            insects[i].onTray = false;
            insects[i].onNonTray = false;
        }
    }
}