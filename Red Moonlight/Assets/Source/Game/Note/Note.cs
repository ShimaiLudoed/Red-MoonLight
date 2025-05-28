using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Note : MonoBehaviour
{
    public float fallSpeed = 5f; // Скорость падения
    private ButtonHander buttonHandler; // Ссылка на обработчик кнопок
    public bool isActive = false;
    void Update()
    {
        // Перемещение вниз по экрану
        transform.Translate(Vector2.down * fallSpeed * Time.deltaTime);
        // Уничтожаем ноту, если она вышла за пределы
        if (transform.position.y < -6)
        {
            Destroy(gameObject); // Удаляем ноту
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        // Проверяем, если нота попадает на кнопку
        if (collision.gameObject.CompareTag("PlayerKey"))
        {
            buttonHandler = collision.GetComponent<ButtonHander>(); // Получаем ссылку на ButtonHandler
            if (buttonHandler != null)
            {
                buttonHandler.note = this; // Устанавливаем связь с нотой
                Activate(); // Активируем ноту
            }
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        // Нота выходит за пределы кнопки
        if (collision.gameObject.CompareTag("PlayerKey"))
        {
            Deactivate(); // Деактивируем ноту
            buttonHandler.note = null; // Убираем ссылку из ButtonHandler
        }
    }
    public void Activate()
    {
        isActive = true; // Устанавливаем активное состояние
    }
    public void Deactivate()
    {
        isActive = false; // Устанавливаем неактивное состояние
    }
}
