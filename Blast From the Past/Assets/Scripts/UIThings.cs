using UnityEngine;
using UnityEditor.EditorTools;
using TMPro;

public class UIThings : MonoBehaviour
{
    float timer = 90f;
    public TextMeshProUGUI timerText;

    int health = 5;
    public TextMeshProUGUI healthText;

    // Matthew: So basically there is ammo and boss health variables here, when scripts for shooting with ammo and boss health are added in
    // you can swap this stuff out with the actual stats. These are kinda just placeholders for when that stuff gets added.

    public int currentAmmo = 30;
    public TextMeshProUGUI ammoText;

    public float currentBossHealth = 100f;
    public TextMeshProUGUI bossHealthText;
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        timer -= Time.deltaTime;
        int minutes = Mathf.FloorToInt(timer / 60);
        int seconds = Mathf.FloorToInt(timer % 60);
        timerText.text = "Recharged In: " + string.Format("{0:00}:{1:00}", minutes, seconds);

        healthText.text = "Health: " + health;

        ammoText.text = "Ammo: " + currentAmmo;
        bossHealthText.text = "Boss Health: " + currentBossHealth;
    }

    public void ReduceTime(float amount)
    {
        timer -= amount;
    }

    public void Heal()
    {
        health++;
    }

    public void UseAmmo(int amountUsed)
    {
        currentAmmo -= amountUsed;
    }

    public void DamageBoss(float damageTaken)
    {
        currentBossHealth -= damageTaken;
    }
}