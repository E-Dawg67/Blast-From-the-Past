using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.LowLevel;

public class PlayerControl : MonoBehaviour
{
    float x, y, prevUP;
    Vector3 move;
    public GameObject collided;
    private Rigidbody rb;
    private bool jump = true;

    void Start()
    {
        Cursor.visible = false;
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        this.transform.Rotate(0, Input.GetAxis("Mouse X") * 5f, 0);
        if (Keyboard.current.spaceKey.wasPressedThisFrame && jump)
        {
            rb.linearVelocity = new Vector3(this.gameObject.GetComponent<Rigidbody>().linearVelocity.x, 5f, this.gameObject.GetComponent<Rigidbody>().linearVelocity.z);
        }
    }

    private void FixedUpdate()
    {
        x = Input.GetAxis("Horizontal");
        y = Input.GetAxis("Vertical");
        move = transform.right * x + transform.forward * y;
        prevUP = rb.linearVelocity.y;
        rb.linearVelocity = move * 1000f * Time.fixedDeltaTime;
        rb.linearVelocity = new Vector3(rb.linearVelocity.x, prevUP, rb.linearVelocity.z);
    }
    private void OnTriggerEnter(Collider other)
    {
        if (collided == null)
        {
            jump = true;
            collided = other.gameObject;
        }
    }
}
