using UnityEngine;
using UnityEngine.XR;

public class BallController : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created

    public Rigidbody sphereRigidbody;
    public float ballSpeed = 2f;
    public float jumpForce = 10f;
    public bool isGrounded = true;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 inputVector = Vector2.zero;
        if (Input.GetKey(KeyCode.W)) {
            inputVector += Vector2.up;
        }
        if (Input.GetKey(KeyCode.A)) {
            inputVector += Vector2.left;
        }
        if (Input.GetKey(KeyCode.S)) {
            inputVector += Vector2.down;
        }
        if (Input.GetKey(KeyCode.D)) {
            inputVector += Vector2.right;
        }

        Vector3 inputXZPlane = new Vector3(inputVector.x, 0, inputVector.y);
        sphereRigidbody.AddForce(inputXZPlane);

        Debug.Log("Resultant Vector: " + inputVector);
        Debug.Log("Resultant 3D Vector: " + inputXZPlane * ballSpeed);

        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            sphereRigidbody.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            isGrounded = false;
        }
        
    }
    void OnCollisionEnter(Collision collision)
    {
        // Reset isGrounded when the sphere touches the ground
        if (collision.contacts.Length > 0 && collision.contacts[0].point.y <= transform.position.y)
        {
            isGrounded = true;
        }
    }
}
