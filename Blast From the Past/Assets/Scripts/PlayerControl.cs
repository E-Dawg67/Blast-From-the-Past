using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.LowLevel;
using System.Collections;
public class PlayerControl : MonoBehaviour
{
    float x, y, prevUP;
    Vector3 move;
    public GameObject collided;
    private Rigidbody rb;
    private bool jump = true;
    public Animator swordAnimator;
    public GameObject sword, bullet;
    public Transform spawnPoint;
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
        if (Input.GetMouseButtonDown(1))
        {
            StartCoroutine(PerformSlash());
        }
        if (Keyboard.current.spaceKey.wasPressedThisFrame && jump)
        {
            rb.linearVelocity = new Vector3(this.gameObject.GetComponent<Rigidbody>().linearVelocity.x, 15f, this.gameObject.GetComponent<Rigidbody>().linearVelocity.z);
        }
        if (Input.GetMouseButtonDown(0) && GameObject.Find("GameManager").GetComponent<UIThings>().currentAmmo > 0)
        {
            GameObject bulletClone = Instantiate(bullet, spawnPoint.position, spawnPoint.rotation);
            GameObject.Find("GameManager").GetComponent<UIThings>().currentAmmo--;
        }
        if (Keyboard.current.rKey.wasPressedThisFrame)
        {
            GameObject.Find("GameManager").GetComponent<UIThings>().currentAmmo = 0;
            Invoke("reload", 3f);
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
    private IEnumerator PerformSlash()
    {
        swordAnimator.SetBool("swing", true);
        sword.GetComponent<BoxCollider>().enabled = true;
        yield return new WaitForSeconds(1f);
        sword.GetComponent<BoxCollider>().enabled = false;
        swordAnimator.SetBool("swing", false);
    }
    private void reload()
    {
        GameObject.Find("GameManager").GetComponent<UIThings>().currentAmmo = 30;
    }
}
