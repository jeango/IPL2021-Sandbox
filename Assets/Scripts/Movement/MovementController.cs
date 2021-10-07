using UnityEngine;

public class MovementController : MovementControllerBase
{
    [SerializeField] private int rotationSpeed;
    [SerializeField] private bool autoMode = false;
    [SerializeField] private Transform target;


    private Vector3 direction;

    private float _sleepDuration;
    public bool CanMove => _sleepDuration <= 0 && groundDetection.Query();

    protected override void Update()
    {
        if (_sleepDuration > 0)
            _sleepDuration -= Time.deltaTime;
        base.Update();
    }

    protected override void PhysicsMove()
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

    protected override void Fire()
    {
        if (Input.GetButton("Fire1"))
            Debug.Log("Fire!");
        
    }

    protected override void Jump()
    {
        if (Input.GetButtonDown("Jump"))
            Debug.Log("Jump!");
    }

    protected override void Move()
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

    public void SetAutoMode(bool mode)
    {
        autoMode = mode;
    }
}
