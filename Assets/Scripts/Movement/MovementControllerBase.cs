using UnityEngine;
using UnityEngine.Serialization;

public abstract class MovementControllerBase : MonoBehaviour
{
    [SerializeField] protected float speed;
    [FormerlySerializedAs("rb")] [SerializeField]
    protected Rigidbody body;

    [SerializeField] protected Raycaster groundDetection;
    
    protected virtual void Update()
    {
        Jump();
        Fire();
        Move();
    }

    protected virtual void FixedUpdate()
    {
        PhysicsMove();
    }
    protected abstract void PhysicsMove();
    protected abstract void Fire();
    protected abstract void Jump();
    protected abstract void Move();
}

public class EnemyController : MovementControllerBase
{
    protected override void PhysicsMove()
    {
        throw new System.NotImplementedException();
    }

    protected override void Fire()
    {
        throw new System.NotImplementedException();
    }

    protected override void Jump()
    {
        throw new System.NotImplementedException();
    }

    protected override void Move()
    {
        throw new System.NotImplementedException();
    }
}