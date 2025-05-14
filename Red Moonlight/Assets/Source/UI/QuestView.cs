using Data;
using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class QuestView : ItemView<QuestSO>
{
    [SerializeField] private TMP_Text _itemName;
    [SerializeField] private Button _itemButton;
    public override void Init(QuestSO data, Action callback = null)
    {
        _itemName.text = data.QuestName; //TODO call Init(U data) from prefab component

        if (callback != null)
            _itemButton.onClick.AddListener(() => callback.Invoke());
    }
}
