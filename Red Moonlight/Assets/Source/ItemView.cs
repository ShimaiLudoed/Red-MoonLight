using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class ItemView<U> : MonoBehaviour
{
    public abstract void Init(U data, Action callback = null);
}
