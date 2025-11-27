using System.Runtime.InteropServices;
using TMPro;
using UnityEngine;

public class Timer : MonoBehaviour
{
    [Header("UI Reference")]
    [SerializeField] private TMP_Text timerText; 

    private float elapsedTime;
    private bool isRunning;
    [DllImport("__Internal")]
    private static extern void SetTime(string time);

  
    private void OnEnable()
    {
        GameManager.OnGameWin += StopTimer;

    }

    private void OnDisable()
    {
        GameManager.OnGameWin -= StopTimer;
    }
    void Start()
    {

        elapsedTime = 0f;
        isRunning = true; 
    }

    void Update()
    {
        if (isRunning)
        {
            
            elapsedTime += Time.deltaTime;

            
            UpdateTimerDisplay(elapsedTime);
        }
    }

    void UpdateTimerDisplay(float timeToDisplay)
    {
       
        float minutes = Mathf.FloorToInt(timeToDisplay / 60);

        
        float seconds = Mathf.FloorToInt(timeToDisplay % 60);

        
        timerText.text = string.Format("{0:00}:{1:00}", minutes, seconds);
    }


    public void StopTimer()
    {
        isRunning = false;


        float minutes = Mathf.FloorToInt(elapsedTime / 60);
        float seconds = Mathf.FloorToInt(elapsedTime % 60);

   
        string finalTime = string.Format("{0:00}:{1:00}", minutes, seconds);

        #if UNITY_WEBGL && !UNITY_EDITOR
                SetTime(finalTime);
        #endif
    }

    public void ResumeTimer()
    {
        isRunning = true;
    }

    public void ResetTimer()
    {
        elapsedTime = 0f;
        UpdateTimerDisplay(elapsedTime);
    }
}
