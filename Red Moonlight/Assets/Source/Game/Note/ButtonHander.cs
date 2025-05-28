using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonHander : MonoBehaviour
{
    public Note note; // Ссылка на ноту, ассоциированную с кнопкой
    private NoteGameManager gameManager;
    void Start()
    {
        gameManager = FindObjectOfType<NoteGameManager>();
    }
    public void OnButtonClick()
    {
        if (note != null && note.isActive) // Проверяем активность ноты
        {
            gameManager.AddScore(); // Увеличиваем счёт
            Destroy(note.gameObject); // Удаляем ноту при нажатии на кнопку
            note = null; // Удаляем ссылку на ноту
        }
    }
}
