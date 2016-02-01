using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Timer : MonoBehaviour
{

    //public Text TimeText;
    public Text winText;

    private bool GameOver;
    private int seconds;
    private int minutes;
    private int hours;
    private int days;


    public float timer;
    public string timerFormatted;



    void Start()
    {


        // SetTimeText();
      //  winText.text = "";

        // GameOver = false;


    }


    void Update()
    {
        //SetTimeText();
        timer += Time.deltaTime;


        /*
        System.TimeSpan t = System.TimeSpan.FromSeconds(timer);
        timerFormatted = string.Format("{0:D2}h:{1:D2}m:{2:D2}s:{3:D3}ms"
        , t.Hours, t.Minutes, t.Seconds, t.Milliseconds);

        TimeText.text = timerFormatted;
        */
    }


    void OnGUI()
    {
        hours = Mathf.FloorToInt(timer / 3600F);
        minutes = Mathf.FloorToInt(timer / 60F);
        seconds = Mathf.FloorToInt(timer - minutes * 60);

        string niceTime = string.Format("{0:00}:{1:00}:{2:00}", hours, minutes, seconds);

        GUI.Label(new Rect(10, 10, 250, 100), niceTime);
    }
}
