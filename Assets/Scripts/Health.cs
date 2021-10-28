using UnityEngine;
using UnityEngine.Events;

public class Health : MonoBehaviour, IDamageable
{
    [SerializeField] private int initHealth;
    [SerializeField] private int currentHealth;
    [SerializeField] private DamageEvent OnDamaged;
    [SerializeField] private UnityEvent OnDeath;

    private void OnEnable()
    {
        currentHealth = initHealth;
    }

    public void TakeDamage(int damage)
    {
        currentHealth -= damage;
        OnDamaged?.Invoke(damage);
        if (currentHealth <= 0)
            Die();
    }

    private void Die()
    {
        OnDeath?.Invoke();
        Destroy(gameObject);
    }
}