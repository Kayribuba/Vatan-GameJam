using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EmployeeScript : MonoBehaviour
{
    //DialogueManager DM;
    [Range(0, 100)] [SerializeField] int possibilityOfTypeInfo = 5;
    public ProductInfo givenProduct { get; private set; }
    public List<string> sentences { get; private set; } = new List<string>();
    [SerializeField] bool debugProducts;

    private void Start()
    {
        //    if (FindObjectOfType<DialogueManager>() != null)
        //        DM = FindObjectOfType<DialogueManager>();
        //    else
        //        Debug.Log("There is no dialogue manager in scene");

        sentences.Add("Do you want to know about the products from the show?");
        sentences.Add("I'm only allowed to say couple of things.");

        int randomDisposable1 = Random.Range(0, possibilityOfTypeInfo);

        if (randomDisposable1 == 0)
        {
            string feature = givenProduct.features[Random.Range(0, givenProduct.features.Length)];
            sentences.Add($"I can tell you that one of the products is going to be a {givenProduct.productType} with {feature}.");
        }
        else if (randomDisposable1 > 0)
        {
            string feature = "I can tell you that the product has ";

            if (givenProduct.features.Length <= 0)
                feature = "It has no features lol";
            else
            {
                int randomDisposable2;

                if (givenProduct.features.Length < 3)
                {
                    randomDisposable2 = Random.Range(0, givenProduct.features.Length);
                    feature += givenProduct.features[randomDisposable2] + ".";
                }
                else if (givenProduct.features.Length >= 3)
                {
                    randomDisposable2 = Random.Range(0, givenProduct.features.Length);
                    feature += givenProduct.features[randomDisposable2] + " and ";


                    while (true)
                    {
                        int RD3 = Random.Range(0, givenProduct.features.Length);
                        if (RD3 != randomDisposable2)
                        {
                            feature += givenProduct.features[RD3] + ".";
                            break;
                        }
                    }
                }
                else
                {
                    //List<int> usedNums = new List<int>();
                    //for (int i = 0; i < 3; i++)
                    //{

                    //    while (true)
                    //    {
                    //        int randomDisposable2 = Random.Range(0, givenProduct.features.Length);

                    //        if (!usedNums.Contains(randomDisposable2))
                    //        {
                    //            usedNums.Add(randomDisposable2);
                    //            feature += givenProduct.features[randomDisposable2];

                    //            switch (i)
                    //            {
                    //                case 0:
                    //                    feature += ", ";
                    //                    break;
                    //                case 1:
                    //                    feature += " and ";
                    //                    break;
                    //                case 2:
                    //                    feature += ".";
                    //                    break;
                    //            }

                    //            break;
                    //        }
                    //    }
                    //}
                }
            }

            sentences.Add(feature);
        }

        sentences.Add("That's about all I can tell.");

        if (debugProducts)
        {
            string pd = "";
            foreach (string s in sentences)
            {
                pd += s + " |||| ";
            }
            Debug.Log(pd);
        }
    }

    public void SetProduct(ProductInfo p) => givenProduct = p;
    public string[] GetSentences() => sentences.ToArray();
}
