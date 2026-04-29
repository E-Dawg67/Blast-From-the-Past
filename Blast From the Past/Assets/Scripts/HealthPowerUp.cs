using UnityEngine;

public class HealthPowerUp : MonoBehaviour
{
    UIThings health;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        health = FindAnyObjectByType<UIThings>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            health.Heal();
            Destroy(gameObject);
        }
    }
}
