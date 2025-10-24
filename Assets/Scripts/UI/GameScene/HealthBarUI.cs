using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public abstract class HealthBarUI : MonoBehaviour
{
    protected Entity _myEntity;
    protected CharacterStats _myStats;
    protected RectTransform _myTransform;
    protected Slider _slider;

    protected virtual void Start()
    {
        _myEntity = GetComponentInParent<Entity>();
        _myStats = GetComponentInParent<CharacterStats>();
        _myTransform = GetComponent<RectTransform>();
        _slider = GetComponentInChildren<Slider>();

        _myStats.OnValueChanged += UpdateHealthUI;
    }

    protected virtual void UpdateHealthUI()
    {
        _slider.maxValue = _myStats.GetMaxHealth();
        _slider.value = _myStats.currentHealth;
    }


    protected virtual void OnDisable()
    {
        _myStats.OnValueChanged -= UpdateHealthUI;
    }
}
