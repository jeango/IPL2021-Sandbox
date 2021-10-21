using UnityEngine;

public class Health : MonoBehaviour, IDamageable
{
    [SerializeField] private int initHealth;
    [SerializeField] private int currentHealth;

    private void OnEnable()
    {
        currentHealth = initHealth;
    }

    public void TakeDamage(int damage)
    {
        currentHealth -= damage;
        if (currentHealth <= 0)
            Die();
    }

    private void Die()
    {
        Destroy(gameObject);
    }
}