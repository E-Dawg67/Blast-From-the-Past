using UnityEngine;
using UnityEngine.AI;

public class EnemyShooter : MonoBehaviour
{
    private Transform playerTarget;
    private NavMeshAgent agent;
    void Start()
    {
        GameObject playerObject = GameObject.Find("Main Camera");
        agent = this.gameObject.GetComponent<NavMeshAgent>();
        if (playerObject != null)
        {
            playerTarget = playerObject.transform;
        }
    }

    void FixedUpdate()
    {
        if (playerTarget != null)
        {
            Vector3 targetPosition = playerTarget.position;
            targetPosition.y = transform.position.y;
            agent.SetDestination(targetPosition);
            transform.LookAt(targetPosition);
            transform.Rotate(0f, 0f, 0f);
        }
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            GameObject.Find("GameManager").GetComponent<UIThings>().health -= -5;
        }
    }
}