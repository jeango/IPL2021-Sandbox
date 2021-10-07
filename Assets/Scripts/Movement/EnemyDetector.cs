using UnityEngine;
using UnityEngine.Events;

public class EnemyDetector : MonoBehaviour
{
    [SerializeField] private LayerMask enemyLayer;
    [SerializeField] private UnityEvent onEntry;
    [SerializeField] private UnityEvent onExit;

    private void OnTriggerEnter(Collider other)
    {
        if (enemyLayer == (enemyLayer | 1 << other.gameObject.layer))
            onEntry?.Invoke();
    }

    private void OnTriggerExit(Collider other)
    {
        if (enemyLayer == (enemyLayer | 1 << other.gameObject.layer))
            onExit?.Invoke();
    }
}
