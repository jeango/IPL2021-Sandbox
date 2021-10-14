using UnityEngine;
using UnityEngine.Serialization;

public class MovementController : MonoBehaviour
{
    [SerializeField] private float speed;
    [SerializeField] private int rotationSpeed;
    [SerializeField] private bool autoMode = false;
    [SerializeField] private Transform target;
    [FormerlySerializedAs("rb")] [SerializeField] private Rigidbody body;
    [SerializeField] private Raycaster groundDetection;
    [SerializeField] private Canon canon;
    

    private Vector3 direction;

    private float _sleepDuration;
    public bool CanMove => _sleepDuration <= 0 && groundDetection.Query();

    // Update is called once per frame
    void Update()
    {
        if (_sleepDuration > 0)
            _sleepDuration -= Time.deltaTime;
        Jump();
        Fire();
        Move();
    }

    private void FixedUpdate()
    {
        PhysicsMove();
    }

    private void PhysicsMove()
    {
        if (CanMove)
        {
            var velocityAdjust = body.velocity;
            velocityAdjust.y = 0;
            Debug.DrawRay(transform.position, direction * speed, Color.magenta);
            body.AddForce(direction * speed - velocityAdjust, ForceMode.VelocityChange);
        }
    }

    public void DisableMovement(float duration)
    {
        _sleepDuration = duration;
    }
    private void Fire()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            canon.Fire();
        }
        
    }

    private void Jump()
    {
        if (Input.GetButtonDown("Jump"))
            Debug.Log("Jump!");
    }

    private void Move()
    {
        if (autoMode)
            direction = target.position-transform.position;
        else
            direction = new Vector3(Input.GetAxisRaw("Horizontal"), 0, Input.GetAxisRaw("Vertical"));
        direction = Vector3.ProjectOnPlane(direction, Vector3.up);
        if (direction.magnitude > 0)
        {
            var targetRotation = Quaternion.LookRotation(direction);
            transform.rotation =
                Quaternion.RotateTowards(transform.rotation, 
                    targetRotation, 
                    rotationSpeed * Time.deltaTime);
        }
        direction.Normalize();
        /*
        var newPos = transform.position;
        newPos += dir.normalized * Time.deltaTime * speed;
        transform.position = newPos;
        */
    }
}
