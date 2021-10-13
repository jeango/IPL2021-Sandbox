using System.Linq;
using UnityEngine;
using Random = UnityEngine.Random;

public class HitDetection : MonoBehaviour
{
    [SerializeField] private LayerMask groundLayer;
    [SerializeField] private LayerMask playerLayer;
    [SerializeField] private float blastRadius;
    [SerializeField] private float blastPower;

    private void OnTriggerStay(Collider other)
    {
        Relocate();
    }

    private void OnTriggerEnter(Collider other)
    {
        Bump(other);
        Relocate();
    }

    private void Bump(Collider other)
    {
        var rb = other.attachedRigidbody;
        var position = transform.position;
        var direction = other.transform.position - position;

        Instantiate(rb);

        var colliders = Physics.OverlapSphere(position, blastRadius, playerLayer);
        var bodies = colliders.Select(c => c.attachedRigidbody).Distinct();

        foreach (var body in bodies)
        {
            body.AddExplosionForce(blastPower, position, blastRadius, 1f, ForceMode.Impulse);
            body.GetComponent<MovementController>()?.DisableMovement(1);
        }
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
