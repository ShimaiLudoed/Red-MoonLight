using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonHander : MonoBehaviour
{
    public Note note; 
    private NoteGameManager gameManager;
    void Start()
    {
        gameManager = FindObjectOfType<NoteGameManager>();
    }
    public void OnButtonClick()
    {
        if (note != null && note.IsActive) 
        {
            gameManager.AddScore(); 
            Destroy(note.gameObject); 
            note = null; 
        }
    }
}
