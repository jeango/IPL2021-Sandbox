using UnityEngine;
using Random = UnityEngine.Random;

public class HitDetection : MonoBehaviour
{
    [SerializeField] private LayerMask groundLayer;
    [SerializeField] private Rigidbody body;

    private void OnTriggerStay(Collider other)
    {
        //Relocate();
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
        var relocated = false;
        while (!relocated)
        {
            Vector3 offset = new Vector3(
                Random.Range(-5f, 5f),
                100f,
                Random.Range(-5f, 5f)
            );
            Physics.Raycast(offset + transform.position, 
                Vector3.down, 
                out var result, 
                200f, 
                groundLayer);
            if (!result.collider) continue;
            body.MovePosition(result.point);
            Debug.DrawRay(result.point, result.normal * 5, Color.blue, 1f);
            var r = body.rotation * Quaternion.AngleAxis(- Vector3.Angle(result.normal, Vector3.up), transform.right);
            body.MoveRotation(r);
            relocated = true;
        }
    }
}
