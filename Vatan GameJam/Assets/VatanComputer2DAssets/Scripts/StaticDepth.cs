using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StaticDepth : MonoBehaviour
{
    // Bu script objelerin Y deðerine baðlý olarak sprite order ýný deðiþtirerek 2D oyunlarda derinlik hissi vermek için kullanýlýr.
    //Dinamikten farklý olarak sabit objeler için sadece bir kere Start'da çalýþýr
    SpriteRenderer _MySpren;  //SpriteRenderer Referansý
    [SerializeField]
    float _correction = 0;  //Correction, doðrudan yerin üzerinde olmayan (rafta duran, oyuncunun taþýdýðý veya bir þekilde havada duran) objeler için kullanýlacak.
                            //Bu deðer objenizin yere izdüþümünden yüksekliðine eþit olmalý (örneðin 1 birim yukarda taþýnan obje için 1 olmalý).

    private void Awake()
    {
        _MySpren = GetComponent<SpriteRenderer>(); //referans alýmý
    }
    void Start()
    {
        _MySpren.sortingOrder = Mathf.FloorToInt((transform.position.y - _correction) * -100); //Y deðeri correction ile düzeltilip,  -100 ile çarpýlýp, sorting order a eþitlenir
                                                                                              //Y si büyük olan objeler, arkada gözükmeli.

    }


}
