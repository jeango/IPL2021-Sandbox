using UnityEngine;
using Random = UnityEngine.Random;

public class HitDetection : MonoBehaviour
{
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
        var direction = other.transform.position - transform.position;
        rb.AddForce(direction * 10, ForceMode.Impulse);
        rb.GetComponent<MovementController>()?.DisableMovement(1);
    }

    private void Relocate()
    {
        var xOffset = Random.Range(-5f, 5f);
        var zOffset = Random.Range(-5f, 5f);
        transform.Translate(xOffset, 0, zOffset);
    }
}
