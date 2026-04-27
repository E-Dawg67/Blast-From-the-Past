using UnityEngine;
using UnityEditor.EditorTools;
using TMPro;

public class UIThings : MonoBehaviour
{
    float timer = 90f;
    public TextMeshProUGUI timerText;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        timer -= Time.deltaTime;
        int minutes = Mathf.FloorToInt(timer / 60);
        int seconds = Mathf.FloorToInt(timer % 60);
        timerText.text = "Recharged In: "+ string.Format("{0:00}:{1:00}", minutes, seconds);
    }

    public void ReduceTime(float amount)
    {
        timer -= amount;
    }
}
