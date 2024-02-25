using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

// Based on HealthManager.cs from https://github.com/COMP30019/Workshop-4-Solution 
public class HealthManager : MonoBehaviour
{
    [SerializeField] public int startingHealth;
    [SerializeField] public float healthChange;
    [SerializeField] private UnityEvent onDeath;
    [SerializeField] public UnityEvent onHealthChanged;
    [SerializeField] public UnityEvent onDamageTaken;

    public float _currentHealth;
    public float CurrentHealth
    {
        get
        {
            return _currentHealth;
        }
        set
        {
            _currentHealth = value;
            onHealthChanged.Invoke();
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        ResetHealth();
    }

    public void ResetHealth()
    {
        CurrentHealth = this.startingHealth;
    }

    public void Heal(float healAmount)
    {
        if (CurrentHealth + healAmount > startingHealth)
        {
            CurrentHealth = startingHealth;
        }
        else
        {
            CurrentHealth += healAmount;
            onHealthChanged.Invoke();
        }
    }

    public void ApplyDamage(float damage)
    {
        CurrentHealth -= damage;
        onDamageTaken.Invoke();
    }


    void Update()
    {
        CurrentHealth -= healthChange * Time.deltaTime;
        if (_currentHealth <= 0 && onDeath != null)
        {
            onDeath.Invoke();
        }
    }
}
