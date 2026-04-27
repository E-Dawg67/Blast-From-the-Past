using UnityEngine;

public class PowerUps : MonoBehaviour
{
    public GameObject attackPower;
    public GameObject healthPower;
    public GameObject timePower;
    float minX = -12f;
    float maxX = 12f;
    float minZ = -12f;
    float maxZ = 12f;
    float y = 1f;
    float timer = 0f;
    float cooldown = 5f;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        if (timer >= cooldown)
        {
            SpawnRandomPowerUp();
            timer = 0f;
        }
    }

    void SpawnRandomPowerUp()
    {
        Vector3 powerPos = new Vector3(
        Random.Range(minX, maxX), y, Random.Range(minZ, maxZ));
        int choice = Random.Range(0, 3);
        if (choice == 0)
        {
            Instantiate(attackPower, powerPos, Quaternion.identity);
        }
        else if (choice == 1)
        {
            Instantiate(healthPower, powerPos, Quaternion.identity);
        }
        else
        {
            Instantiate(timePower, powerPos, Quaternion.identity);
        }
    }
}
