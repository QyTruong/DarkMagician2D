using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Stats
{
    [SerializeField] private int _baseValue;
    public List<int> modifiedValues;

    public int GetValue()
    {
        int finalValue = _baseValue;
        foreach (int modifier in modifiedValues)
            finalValue += modifier;
        return finalValue;
    }

    public void AddModifier(int value)
    {
        modifiedValues.Add(value);
    }

    public void RemoveModifier(int value)
    {
        modifiedValues.Remove(value);
    }

    public void SetDefaultModifier(int value)
    {
        _baseValue = value;
    }
}
