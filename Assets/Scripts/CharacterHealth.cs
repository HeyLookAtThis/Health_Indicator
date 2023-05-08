using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using static UnityEngine.GraphicsBuffer;

public class CharacterHealth : MonoBehaviour
{
    [SerializeField] private UnityEvent _onChanged;

    private float _maxValue = 100.0f;
    private float _minValue = 0.0f;

    public float CurrentValue { get; private set; }

    private void Start()
    {
        CurrentValue = _maxValue;
    }

    public event UnityAction OnChanged
    {
        add => _onChanged.AddListener(value);
        remove => _onChanged.RemoveListener(value);
    }

    public void Change(float changingValue)
    {
        CurrentValue += changingValue;

        if (CurrentValue < _minValue)
            CurrentValue = _minValue;
        else if(CurrentValue > _maxValue)
            CurrentValue = _maxValue;

        _onChanged.Invoke();
    }
}
