using UnityEngine;
using UnityEngine.Events;

public class Health : MonoBehaviour, IDamageable
{
    [SerializeField] float maxHealth = 100f;
    [SerializeField] float currentHealth;

    public UnityEvent<float> onDamaged; // passes the damage amount
    public UnityEvent onDeath;

    public float MaxHealth => maxHealth;
    public float CurrentHealth => currentHealth;
    public bool IsDead => currentHealth <= 0f;

    void Awake()
    {
        currentHealth = maxHealth;
    }

    public void TakeDamage(float amount)
    {
        if (IsDead || amount <= 0f) return;

        currentHealth = Mathf.Max(0f, currentHealth - amount);
        onDamaged?.Invoke(amount);

        if (IsDead)
            onDeath?.Invoke();
    }
}