using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class HostDialogue : MonoBehaviour //evet hardcode ama napim sýkýldým
{
    [SerializeField] GameObject GoToDisable;
    [SerializeField] GameObject GoToEnable;
    [SerializeField] TextMeshProUGUI textMesh;
    [SerializeField] TextMeshProUGUI textMeshAfterDestruction;
    [SerializeField] TextMeshProUGUI textMeshScoreBoard;
    [SerializeField] TextMeshProUGUI NumTakerDigitalText;
    [SerializeField] Camera cameraToTurn;
    [SerializeField] float nextInputWaitTime = .2f;
    [SerializeField] [Range(1, 100)] int[] tresholds = new int[] { 90, 75, 60, 45, 30, 15 };
    [SerializeField] GameObject NumTaker;
 
    Queue<string> DialogueQueue = new Queue<string>();
    float cooldown = float.MaxValue;

    string[] Types;
    string[] Names;
    string[][] Features;
    int[] Prices;

    int[] PlayerAnswers;

    bool lockAnswer;
    bool acceptAnswer;
    int currentAnswer = -1;
    int playerAnswerIndex;
    bool gameEnded;
    bool OneTimeEnterPass;

    void Start()
    {

        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;

        if (Types != null)
        {
            PlayerAnswers = new int[Prices.Length];

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
                DialogueQueue.Enqueue("(a " + Types[i].ToString() + " named " + Names[i].ToString() + " with " + sentence + ")<GetAnswer>");//<GetAnswer> aþaðýda updatede siliniyo ve cevap isteniyo

                DialogueQueue.Enqueue("You chose your answer to be <CurrentAnswer>TL. The correct answer was <CorrectAnswer>TL.");
            }
            DialogueQueue.Enqueue("And that concludes your turn!");
            DialogueQueue.Enqueue("Lets see your score!<br>(Press E or LMB to see your score)");
            DialogueQueue.Enqueue("<GoToScoreboard>");

            textMesh.text = DialogueQueue.Dequeue();
            cooldown = Time.time;

            foreach (int i in Prices)
            {
                Debug.Log(i);
            }
        }
        else
        {
            textMesh.text = "I'm sorry my dear audience but it seems our staff forgot to select items. >:(";
            Debug.Log("<ERROR - No selected object found...>");
        }
    }

    void Update()
    {
        if (gameEnded && (Input.GetMouseButtonDown(0) || Input.GetKeyDown(KeyCode.E)))
        {
            SceneManager.LoadScene(1);
        }
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
                    if(sentence.Contains("<CurrentAnswer>") && PlayerAnswers.Length > playerAnswerIndex - 1)
                    {
                        sentence = sentence.Replace("<CurrentAnswer>", PlayerAnswers[playerAnswerIndex - 1].ToString());
                    }
                    if(sentence.Contains("<CorrectAnswer>"))
                    {
                        sentence = sentence.Replace("<CorrectAnswer>", Prices[playerAnswerIndex - 1].ToString());
                    }
                    if (sentence.Contains("<GoToScoreboard>"))
                    {
                        sentence = sentence.Replace("<GoToScoreboard>", "");

                        int MaxScore = 0;
                        int PlayerScore = 0;

                        foreach (int i in Prices)
                            MaxScore += i;


                        for (int i = 0; i < Prices.Length; i++)
                        {
                            int disposable = PlayerAnswers[i];
                            if (PlayerAnswers[i] > Prices[i])
                            {
                                int fark = PlayerAnswers[i] - Prices[i];
                                disposable = PlayerAnswers[i] - 2 * fark;

                                if (disposable < 0)
                                    disposable = 0;
                            }
                            PlayerScore += disposable; 
                        }

                        textMeshScoreBoard.text = "<align=\"center\"><size=120%>SCORE BOARD<br><size=100%></align><br>";

                        List<string> names = new List<string>() { "Kayra     ", "Murat     ", "Utku      ", "Berke     ", "Cem       ", "Ecem      "};
                        bool nameIsUsed = false;
                        int yourPlace = 0;
                        for(int i = 0; i < tresholds.Length; i++)
                        {
                            if (PlayerScore >= MaxScore * tresholds[i] / 100 && !nameIsUsed)
                            {
                                nameIsUsed = true;
                                yourPlace = i + 1;
                                textMeshScoreBoard.text += $"<color=\"red\">YOU<color=\"white\">       with {PlayerScore} score<br>";
                            }

                            int randomInt = Random.Range(0, tresholds.Length - i);
                            textMeshScoreBoard.text += names[randomInt] + $"with {MaxScore * tresholds[i] / 100} score<br>";
                            names.RemoveAt(randomInt);
                        }

                        if(PlayerScore < MaxScore * tresholds[5] / 100)
                        {
                            textMeshScoreBoard.text += $"<color=\"red\"> YOU<color=\"white\">        with {PlayerScore} score<br>";
                            yourPlace = 7;
                        }
                        textMeshAfterDestruction.text = $"You are number {yourPlace} out of 7.";

                        GoToDisable.SetActive(false);
                        GoToEnable.SetActive(true);
                        lockAnswer = true;
                    }
                    textMesh.text = sentence;
                    cooldown = Time.time + nextInputWaitTime;
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
            PlayerAnswers[playerAnswerIndex] = currentAnswer;
            playerAnswerIndex++;

            lockAnswer = false;
            acceptAnswer = false;
            currentAnswer = -1;
            NumTaker.SetActive(false);
            OneTimeEnterPass = true;

            if (GetComponent<AudioSource>() != null && (PlayerAnswers[playerAnswerIndex - 1] == Prices[playerAnswerIndex - 1]))
                GetComponent<AudioSource>().Play();
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
