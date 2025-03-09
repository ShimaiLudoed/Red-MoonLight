using Data;
using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

namespace Player
{
  public class Inventory1 : APlayerPanel
  {
    private void Start()
    {
      _objects = new List<ScriptableObject>(new List<ItemSO>());
    }
    
  }
}
