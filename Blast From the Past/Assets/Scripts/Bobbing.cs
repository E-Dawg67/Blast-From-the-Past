using UnityEngine;

public class Bobbing : MonoBehaviour
{
    private float amplitude = .05f; // How high it bobs
    private float frequency = 8f;   // How fast it bobs

    Vector3 startPos;
    private void Start()
    {
        startPos = transform.localPosition;
    }
    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    private void Update()
    {
        if (!(Input.GetAxis("Horizontal") == 0 && Input.GetAxis("Vertical") == 0))
        {
            transform.localPosition = startPos + new Vector3(0, Mathf.Sin(Time.time * frequency) * amplitude, 0);
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Enemy")
        {
            GameObject.Find("GameManager").GetComponent<UIThings>().currentBossHealth -= -5;
            if (GameObject.Find("GameManager").GetComponent<UIThings>().currentBossHealth <= 0)
            {
                Destroy(other.gameObject);
            }
        }
    }
}
