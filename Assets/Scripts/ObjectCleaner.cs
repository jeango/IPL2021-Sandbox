using UnityEngine;

public class ObjectCleaner : MonoBehaviour
{
    [SerializeField] private LayerMask layerMask;

    private void OnTriggerEnter(Collider other)
    {
        Clean(other);
    }

    private void Clean(Collider other)
    {
        var obj = other.attachedRigidbody?.gameObject;
        if (!obj || layerMask != (layerMask | 1 << obj.layer))
            return;
        Destroy(obj);
    }
}
