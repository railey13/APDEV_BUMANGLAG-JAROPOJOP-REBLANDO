
using System;
using UnityEngine;

[Serializable]
public class CardValue
{
    [SerializeField]
    private int _value;
    public int Value { get { return _value; } set {  _value = value; } }

    [SerializeField]
    private bool _isRed;
    public bool IsRed { get { return _isRed; } set { _isRed = value; } }

    [SerializeField]
    private bool _hasChild;
    public bool HasChild { get { return _hasChild; } set { _hasChild = value; } }
}
