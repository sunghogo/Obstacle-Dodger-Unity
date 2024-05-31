using UnityEngine;

public class Car : MonoBehaviour
{
    public float MovementSpeed;
    public float RotationSpeed;
    [SerializeField] private bool _isColliding;
    private Rigidbody _rb;

    // Start is called before the first frame update
    void Start()
    {
        MovementSpeed = 20f;
        RotationSpeed = 10f;
        _isColliding = false;
        _rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        ProcessInput();
    }

    void OnCollisionEnter(Collision other) {
        if (!other.gameObject.CompareTag("Ground")) _isColliding = true;
    }

    void OnCollisionExit(Collision other) {
        if (!other.gameObject.CompareTag("Ground")) {
            _isColliding = false;
            ResetForces();
        }
    }

    private void ProcessInput() {
        if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.UpArrow)) Move(Vector3.forward);
        if (Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.DownArrow)) Move(Vector3.back);
        if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow)) Rotate(new Vector3(0, -15, 0));
        if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow)) Rotate(new Vector3(0, 15, 0));
    }

    private void Move(Vector3 vector) {
        transform.Translate(vector * Time.deltaTime * (_isColliding ? 1f : MovementSpeed));
    }

    private void Rotate(Vector3 vector) {
        transform.Rotate(vector * Time.deltaTime * RotationSpeed);
    }

    private void ResetForces() {
        _rb.velocity = Vector3.zero;
        _rb.angularVelocity = Vector3.zero;
    }
}   
