using UnityEngine;
using UnityEngine.SceneManagement;

public class Bullet : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    Rigidbody rb;
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.linearVelocity = transform.forward * 25f;
    }
    private void OnTriggerEnter(Collider collision)
    {
        if(collision.gameObject.tag == "Enemy")
        {
            GameObject.Find("GameManager").GetComponent<UIThings>().currentBossHealth--;
            if (GameObject.Find("GameManager").GetComponent<UIThings>().currentBossHealth <= 0)
            {
                Destroy(collision.gameObject);
            }
        }
        Destroy(gameObject);
    }
}
