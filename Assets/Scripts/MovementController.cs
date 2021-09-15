using TMPro;
using UnityEngine;

public class MovementController : MonoBehaviour
{
    [SerializeField] private float speed;

    // Start is called before the first frame update
    void Awake()
    {
    }

    // Update is called once per frame
    void Update()
    {
        Move();
    }

    private void Move()
    {
        var newPos = transform.position;
        newPos += transform.forward * Time.deltaTime * speed;
        transform.position = newPos;
    }
}
