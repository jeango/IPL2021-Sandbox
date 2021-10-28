using UnityEngine;
using Random = UnityEngine.Random;

public class HitDetection : MonoBehaviour
{
    [SerializeField] private LayerMask groundLayer;
    [SerializeField] private LayerMask playerLayer;

    private void OnTriggerStay(Collider other)
    {
        if (playerLayer != (playerLayer | 1 << other.gameObject.layer)) return;
        Relocate();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (playerLayer != (playerLayer | 1 << other.gameObject.layer)) return;
        Bump(other);
        Relocate();
    }

    private void Bump(Collider other)
    {
        var rb = other.attachedRigidbody;
        var direction = other.transform.position - transform.position;
        rb.AddForce(direction * 5, ForceMode.Impulse);
        rb.GetComponent<MovementController>()?.DisableMovement(1);
    }

    private void Relocate()
    {
        for (int i = 0; i < 100; i++)
        {
            var offset = new Vector3(Random.Range(-5f, 5f), 100f, Random.Range(-5f, 5f));
            if (!Physics.Raycast(transform.position + offset, Vector3.down, out var result, 200f, groundLayer))
                continue;
            Debug.DrawRay(result.point + Vector3.up * 10f, Vector3.down * 10f, Color.blue, 1f);
            if (Physics.CheckSphere(result.point, 4f, playerLayer))
                continue;
            var t = transform;
            t.position = result.point;
            var forward = Vector3.ProjectOnPlane(t.forward, result.normal);
            transform.rotation = Quaternion.LookRotation(forward, result.normal);
            break;
        }
    }
}
