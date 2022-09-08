using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class HostDialogue : MonoBehaviour //evet hardcode ama napim sýkýldým
{
    [SerializeField] TextMeshProUGUI textMesh;
    [SerializeField] float nextInputWaitTime = .2f;
 
    Queue<string> DialogueQueue = new Queue<string>();
    float cooldown = float.MaxValue;

    string[] Types;
    string[] Names;
    string[][] Features;
    int[] Prices;

    bool lockAnswer;

    void Start()
    {
        DialogueQueue.Enqueue("And now ladies and gentlemen we are here with our last contestant.");
        DialogueQueue.Enqueue("Our dear contestant, are you ready?");
        DialogueQueue.Enqueue("(Press E or LMB to start the competition)");

        DialogueQueue.Enqueue("Alright then, here is your first product!");

        for (int i = 0; i < Types.Length;i++)
        {
            string sentence = "";

            if (i == 0)
                sentence = "First we have a ";
            else if (i == Types.Length - 1)
                sentence = "Lastly we have a ";
            else
                sentence = "Next is a ";

            sentence += Types[i] + $", {Names[i]}.";

            DialogueQueue.Enqueue(sentence);

            DialogueQueue.Enqueue("It's features are like this:");

            sentence = "";
            for(int n = 0; n < Features[i].Length; n++)
            {
                sentence += Features[i][n];

                if (n == Features[i].Length - 2)//son özellikten bi önce
                    sentence += " and ";
                else if (n == Features[i].Length - 1)//son özellik
                    sentence += ".";
                else
                    sentence += ", ";
            }
            DialogueQueue.Enqueue(sentence);
            DialogueQueue.Enqueue("So... What's it's price?<br>(Click then give your answer)");
            DialogueQueue.Enqueue("(a " + Types[i].ToString() + " with " + sentence + ")");

            //fiyatý vericek

            DialogueQueue.Enqueue("You gave your answer.");
        }
        DialogueQueue.Enqueue("And that concludes your turn!");

        textMesh.text = DialogueQueue.Dequeue();
        cooldown = Time.time;

        //int number = DialogueQueue.Count;
        //for (int i = 0; i < number; i++)
        //{
        //    Debug.Log(DialogueQueue.Dequeue());
        //}
    }

    void Update()
    {
        if (!lockAnswer)
        {
            if ((Input.GetMouseButtonDown(0) || Input.GetKeyDown(KeyCode.E)) && cooldown <= Time.time)
            {
                if (DialogueQueue.Count > 0)
                {
                    textMesh.text = DialogueQueue.Dequeue();
                    cooldown = Time.time + nextInputWaitTime;
                }
            }
        }
    }

    public void SetInfo(string[] types, string[] names, string[][] features, int[] prices)
    {
        Types = types;
        Names = names;
        Features = features;
        Prices = prices;
    }
}
