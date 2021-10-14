using UnityEngine;

public class Canon : MonoBehaviour
{
    [SerializeField] private Rigidbody projectile;
    [SerializeField] private float initialVelocity;
    [SerializeField] private ParticleSystem particles;

    public void Fire()
    {
        var obj = Instantiate(projectile, transform.position, transform.rotation);
        obj.AddForce(transform.forward * initialVelocity, ForceMode.VelocityChange);
        particles.Emit(30);
    }
 }
