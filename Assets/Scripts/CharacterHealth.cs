using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

[RequireComponent(typeof(CharacterHealth))]

public class CharacterHealth : MonoBehaviour
{
    private static CharacterHealth Storage;

    private float _maxValue = 100.0f;
    private float _minValue = 0.0f;

    public float CurrentValue { get; private set; }

    private void Start()
    {
        Storage = GetComponent<CharacterHealth>();
        CurrentValue = _maxValue;
    }

    public static CharacterHealth Initialize()
    {
        return Storage;
    }

    public void Change(float changingValue)
    {
        CurrentValue += changingValue;

        if (CurrentValue < _minValue)
            CurrentValue = _minValue;
        else if(CurrentValue > _maxValue)
            CurrentValue = _maxValue;
    }
}