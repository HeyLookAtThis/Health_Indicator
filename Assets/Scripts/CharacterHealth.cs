using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using static UnityEngine.GraphicsBuffer;

public class CharacterHealth : MonoBehaviour
{
    private UnityAction _onChangedValue;

    private float _maxValue = 100.0f;
    private float _minValue = 0.0f;

    public float CurrentValue { get; private set; }

    private void Start()
    {
        CurrentValue = _maxValue;
    }

    public event UnityAction Changed
    {
        add => _onChangedValue += value;
        remove => _onChangedValue -= value;
    }

    public void Change(float changingValue)
    {
        CurrentValue += changingValue;

        if (CurrentValue < _minValue)
            CurrentValue = _minValue;
        else if(CurrentValue > _maxValue)
            CurrentValue = _maxValue;

        _onChangedValue?.Invoke();
    }
}
