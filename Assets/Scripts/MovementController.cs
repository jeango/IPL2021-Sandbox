using UnityEngine;

public class MovementController : MonoBehaviour
{
    [SerializeField] private float speed;
    [SerializeField] private int rotationSpeed;
    [SerializeField] private bool autoMode = false;
    [SerializeField] private Transform target;

    // Update is called once per frame
    void Update()
    {
        Jump();
        Fire();
        Move();
    }

    private void Fire()
    {
        if (Input.GetButton("Fire1"))
            Debug.Log("Fire!");
        
    }

    private void Jump()
    {
        if (Input.GetButtonDown("Jump"))
            Debug.Log("Jump!");
    }

    private void Move()
    {
        Vector3 dir;
        if (autoMode)
            dir = target.position-transform.position;
        else
            dir = new Vector3(Input.GetAxisRaw("Horizontal"), 0, Input.GetAxisRaw("Vertical"));
        if (dir.magnitude > 0)
        {
            var targetRotation = Quaternion.LookRotation(dir);
            transform.rotation =
                Quaternion.RotateTowards(transform.rotation, 
                    targetRotation, 
                    rotationSpeed * Time.deltaTime);
        }
        var newPos = transform.position;
        newPos += dir.normalized * Time.deltaTime * speed;
        transform.position = newPos;
    }
}
