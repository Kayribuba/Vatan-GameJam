using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class HostDialogue : MonoBehaviour //evet hardcode ama napim sýkýldým
{
    [SerializeField] TextMeshProUGUI textMesh;
    [SerializeField] TextMeshProUGUI NumTakerDigitalText;
    [SerializeField] float nextInputWaitTime = .2f;
    [SerializeField] GameObject NumTaker;
 
    Queue<string> DialogueQueue = new Queue<string>();
    float cooldown = float.MaxValue;

    string[] Types;
    string[] Names;
    string[][] Features;
    int[] Prices;

    bool lockAnswer;
    bool acceptAnswer;
    int currentAnswer = -1;
    int pricesIndex;
    bool OneTimeEnterPass;

    void Start()
    {
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;

        if (Types != null)
        {
            DialogueQueue.Enqueue("And now ladies and gentlemen we are here with our last contestant.");
            DialogueQueue.Enqueue("Our dear contestant, are you ready?");
            DialogueQueue.Enqueue("(Press E or LMB to start the competition)");

            DialogueQueue.Enqueue("Alright then, here is your first product!");

            for (int i = 0; i < Types.Length; i++)
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
                for (int n = 0; n < Features[i].Length; n++)
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
                DialogueQueue.Enqueue("(a " + Types[i].ToString() + " with " + sentence + ")<GetAnswer>");//<GetAnswer> aþaðýda updatede siliniyo ve cevap isteniyo

                DialogueQueue.Enqueue("You chose your answer to be <CurrentAnswer>TL.");
            }
            DialogueQueue.Enqueue("And that concludes your turn!");

            textMesh.text = DialogueQueue.Dequeue();
            cooldown = Time.time;
        }
        else
        {
            textMesh.text = "I'm sorry my dear audience but it seems our staff forgot to select items. >:(";
            Debug.Log("<ERROR - No selected object found...>");
        }
    }

    void Update()
    {
        if (!lockAnswer)
        {
            if (((Input.GetMouseButtonDown(0) || Input.GetKeyDown(KeyCode.E)) && cooldown <= Time.time) || OneTimeEnterPass)
            {
                OneTimeEnterPass = false;

                if (DialogueQueue.Count > 0)
                {
                    string sentence = "";
                    sentence = DialogueQueue.Dequeue();

                    if (sentence.Contains("<GetAnswer>"))
                    {
                        sentence = sentence.Replace("<GetAnswer>", "");

                        lockAnswer = true;
                        acceptAnswer = true;
                        currentAnswer = -1;
                        NumTaker.SetActive(true);
                    }
                    else if(sentence.Contains("<CurrentAnswer>") && Prices.Length > pricesIndex - 1)
                    {
                        sentence = sentence.Replace("<CurrentAnswer>", Prices[pricesIndex - 1].ToString());
                    }
                    textMesh.text = sentence;
                    cooldown = Time.time + nextInputWaitTime;
                }
                else
                {
                    //bitir lan hakem BÝTÝÝÝR ÇAL DÜDÜÐÜ HAKEEEEEEEEEAAM
                }
            }
        }
        if(acceptAnswer)
        {
            if (currentAnswer >= 0 && currentAnswer < 100000)
            {
                NumTakerDigitalText.text = currentAnswer.ToString();
            }
            else
                NumTakerDigitalText.text = "";
        }
    }

    public void SetAnswer(int numToAdd)
    {
        if (acceptAnswer)
        {
            string textVersion = currentAnswer.ToString();

            if (currentAnswer < 0)
                textVersion = "";

            textVersion += numToAdd.ToString();
            int targetAnswer = System.Convert.ToInt32(textVersion);

            if (targetAnswer <= 99999)
                currentAnswer = targetAnswer;

        }
    }
    public void DeleteCurrentAnswersLastNumber()
    {
        if (acceptAnswer)
        {
            string textVersion = currentAnswer.ToString();

            if(currentAnswer > 9)
            {
                textVersion = textVersion.Substring(0, textVersion.Length - 1);
                int targetAnswer = System.Convert.ToInt32(textVersion);
                currentAnswer = targetAnswer;
            }
            else
                currentAnswer = -1;
        }
    }
    public void ConcludeAnswer()
    {
        if (currentAnswer >= 0 && currentAnswer < 100000 && acceptAnswer)
        {
            Prices[pricesIndex] = currentAnswer;
            pricesIndex++;

            lockAnswer = false;
            acceptAnswer = false;
            currentAnswer = -1;
            NumTaker.SetActive(false);
            OneTimeEnterPass = true;
        }
    }
    public void SetInfo(string[] types, string[] names, string[][] features, int[] prices)
    {
        Types = types;
        Names = names;
        Features = features;
        Prices = new int[prices.Length];
    }
}
