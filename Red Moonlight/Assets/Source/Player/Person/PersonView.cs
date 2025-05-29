using Data;
using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class PersonView : ItemView<NPCSO>
{
    [SerializeField] private TMP_Text _itemName;
    [SerializeField] private Button _itemButton;
    
    public override void Init(NPCSO data, Action callback = null)
    {
        _itemName.text = data.NPCName; //TODO call Init(U data) from prefab component
        _itemButton.image.sprite = data.ImageForBook;

        if (callback != null)
            _itemButton.onClick.AddListener(() => callback.Invoke());
    }
}
