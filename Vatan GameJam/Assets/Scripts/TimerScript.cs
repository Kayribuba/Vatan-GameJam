using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TimerScript : MonoBehaviour
{
    [SerializeField] float TimeToElapse = 120f;
    [SerializeField] TextMeshProUGUI TimerText;

    float hiddenTime;
    bool searchEnded;
    bool timerRanOut;

    void Start()
    {
        hiddenTime = TimeToElapse;
    }
    void Update()
    {

        if (!timerRanOut)
        {
            hiddenTime -= Time.deltaTime;

            if (TimerText != null)
            {
                TimerText.text = "";
                int disposable1 = Mathf.FloorToInt(hiddenTime / 60);
                if (disposable1 < 10)
                    TimerText.text += "0";
                TimerText.text += disposable1.ToString() + ":";

                disposable1 = Mathf.FloorToInt(hiddenTime % 60);
                if (disposable1 < 10)
                    TimerText.text += "0";
                TimerText.text += disposable1;
            }

            if (hiddenTime < 1 && !searchEnded)
                EndSearch(); 
        }
    }

    void EndSearch()
    {
        searchEnded = true;
        timerRanOut = true;
        TimerText.color = Color.red;

        FindObjectOfType<MouseLook>().enabled = false;//evet hardcode ama yoruldum yeter
        FindObjectOfType<TalkToEmployee>().enabled = false;
        FindObjectOfType<BarcodeReaderScript>().enabled = false;
        FindObjectOfType<CharacterController>().enabled = false;
        DialogueManager.OnlyDialogueManager.GetComponentInChildren<Animator>().SetBool("open", false);
        DialogueManager.OnlyDialogueManager.enabled = false;
        FindObjectOfType<TabletScript>().gameObject.GetComponent<Animator>().SetBool("TabletIsOpen", false);
        FindObjectOfType<TabletScript>().enabled = false;

        if(GameMangaerScript.OnlyGameManagerScript != null)
            GameMangaerScript.OnlyGameManagerScript.SetEndSearchTime();
    }
    public void EndTime()
    {
        if (hiddenTime > 1)
            hiddenTime = 1;

        var AS = FindObjectOfType<RunAudioPlayer>();
        if (AS != null)
            AS.EndTime();
    }
}
