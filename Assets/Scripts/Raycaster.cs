using UnityEngine;

public class Raycaster : MonoBehaviour
{
    [SerializeField] private LayerMask layerMask;
    [SerializeField] private Vector3 offset;
    [SerializeField] private Vector3 direction;
    [SerializeField] private float maxDistance;

    public bool Query()
    {
        var ray = new Ray(transform.position + offset, direction);
        Debug.DrawRay(ray.origin, ray.direction.normalized*maxDistance, Color.red);
        return Physics.Raycast(ray, maxDistance, layerMask);
    }
}
