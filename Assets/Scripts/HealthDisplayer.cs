using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Slider))]

public class HealthDisplayer : MonoBehaviour
{
    [SerializeField] private float _speed;
    [SerializeField] private float _seconds;
    [SerializeField] private CharacterHealth _health;

    private Slider _slider;
    private Coroutine _valueChanger; 

    private void Start()
    {
        _slider = GetComponent<Slider>();
    }

    public void BeginChange()
    {
        if (_valueChanger != null)
            StopCoroutine(_valueChanger);

        _valueChanger = StartCoroutine(ValueChanger());
    }

    private IEnumerator ValueChanger()
    {
        var waitTime = new WaitForSeconds(_seconds);

        bool isRightValue = _health.CurrentValue == _slider.value;

        while (isRightValue == false)
        {
            _slider.value = Mathf.MoveTowards(_slider.value, _health.CurrentValue, _speed);
            yield return waitTime;
        }

        if (isRightValue)
            yield break;
    }
}
