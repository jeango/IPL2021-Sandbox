using UnityEngine;

public class Damage : MonoBehaviour
{
    [SerializeField] private int damage;

    private void OnTriggerEnter(Collider other)
    {
        var body = other.attachedRigidbody;
        if (body)
            DealDamage(body.gameObject);
        else
            DealDamage(other.gameObject);
    }

    private void OnCollisionEnter(Collision other)
    {
        var body = other.rigidbody;
        if (body)
            DealDamage(body.gameObject);
        else
            DealDamage(other.gameObject);
    }

    void DealDamage(GameObject obj)
    {
        var dam = obj.GetComponent<IDamageable>();
        dam?.TakeDamage(damage);
    }
}