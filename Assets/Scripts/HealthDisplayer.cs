using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Slider))]

public class HealthDisplayer : MonoBehaviour
{
    [SerializeField] private float _speed = 20.0f;
    [SerializeField] private CharacterHealth _health;

    private Slider _slider;

    void Start()
    {
        _slider = GetComponent<Slider>();
    }

    private void FixedUpdate()
    {
        float targetValue = _health.CurrentValue;
        _slider.value = Mathf.MoveTowards(_slider.value, targetValue, _speed * Time.fixedDeltaTime);
    }
}
