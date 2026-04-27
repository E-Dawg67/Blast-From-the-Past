using UnityEngine;

public class TimePowerUp : MonoBehaviour
{
    UIThings timer;

    private void Start()
    {
        timer = FindAnyObjectByType<UIThings>();
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            timer.ReduceTime(10f);
            Destroy(gameObject);
        }
    }
}
