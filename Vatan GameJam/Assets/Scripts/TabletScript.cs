using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TabletScript : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI textMesh;

    void Start()
    {
        BarcodeReaderScript brs = FindObjectOfType<BarcodeReaderScript>();
        if(brs != null)
            brs.SetProductEvent += Brs_SetProductEvent;

        DeleteAllText(textMesh);
    }

    void Brs_SetProductEvent(object sender, ProductInfo e)
    {
        DeleteAllText(textMesh);
        textMesh.text += e.productType + "<br>";
        textMesh.text += e.productName + "<br>";
        textMesh.text += e.productPrice + "<br><br>FEATURES<br>";

        if (e.features == null)
            textMesh.text += "<NONE><br>";
        else
            foreach (string f in e.features)
                textMesh.text += f + "<br>";
    }
    void DeleteAllText(TextMeshProUGUI TM) => TM.text = ""; 
}
