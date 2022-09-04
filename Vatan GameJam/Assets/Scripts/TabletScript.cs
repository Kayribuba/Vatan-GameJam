using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TabletScript : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI textMesh;
    [SerializeField] Canvas canvas;
    [SerializeField] Animator animator;

    bool tabletIsOpen;

    void Start()
    {
        BarcodeReaderScript brs = FindObjectOfType<BarcodeReaderScript>();
        if(brs != null)
            brs.SetProductEvent += Brs_SetProductEvent;

        if (animator == null)
            animator = GetComponent<Animator>();

        DeleteAllText(textMesh);
    }
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            tabletIsOpen = !tabletIsOpen;
            animator.SetBool("TabletIsOpen", tabletIsOpen);
        }
    }

    void Brs_SetProductEvent(object sender, ProductInfo e)
    {
        DeleteAllText(textMesh);
        textMesh.text += "<b>Name : </b>" + e.productName + "<br>";
        textMesh.text += "<b>Type : </b>" + e.productType + "<br><br>";
        textMesh.text += e.productPrice +" TL"+ "<br><br><b><size=120%><align=\"center\">FEATURES</align><size=100%></b><br>";

        if (e.features == null)
            textMesh.text += "<br><NONE>";
        else
            foreach (string f in e.features)
                textMesh.text += "<br>" + f;
    }
    void DeleteAllText(TextMeshProUGUI TM) => TM.text = ""; 
}
