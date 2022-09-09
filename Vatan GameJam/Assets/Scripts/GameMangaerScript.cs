using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameMangaerScript : MonoBehaviour
{
    public static GameMangaerScript OnlyGameManagerScript { get; private set; }
    [SerializeField] float EndGameAfterSeconds = 3f;

    [SerializeField] SceneManagerScript sms;
    float endGameAt = float.MaxValue;
    GameObject player;

    void Awake()
    {
        if (OnlyGameManagerScript == null)
            OnlyGameManagerScript = this;
        else
            Destroy(this);

        if (sms == null)
            sms = FindObjectOfType<SceneManagerScript>();

        player = GameObject.FindGameObjectWithTag(Constants.PlayerTag);
    }
    void Update()
    {
        if (endGameAt <= Time.time)
        {
            var AS = FindObjectOfType<RunAudioPlayer>();
            if (AS != null)
                AS.EndTime();

            sms.GoToNextLevel();

            endGameAt = float.MaxValue;
        }

    }

    public void EndSearch()
    {

    }public void SetEndSearchTime() => endGameAt = Time.time + EndGameAfterSeconds;
}
