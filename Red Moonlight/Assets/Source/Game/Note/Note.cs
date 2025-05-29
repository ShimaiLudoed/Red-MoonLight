using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Note : MonoBehaviour
{
    [SerializeField] private float fallSpeed = 20f; 
    private ButtonHander _buttonHandler; 
    public bool IsActive = false;
    void Update()
    {
        transform.Translate(Vector2.down * fallSpeed * Time.deltaTime);
        if (transform.position.y < -6)
        {
            Destroy(gameObject); 
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.gameObject.CompareTag("PlayerKey"))
        {
            _buttonHandler = collision.GetComponent<ButtonHander>(); 
            if (_buttonHandler != null)
            {
                _buttonHandler.note = this; 
                Activate(); 
            }
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("PlayerKey"))
        {
            Deactivate(); 
            _buttonHandler.note = null; 
        }
    }
    public void Activate()
    {
        IsActive = true; 
    }
    public void Deactivate()
    {
        IsActive = false;
    }
}
