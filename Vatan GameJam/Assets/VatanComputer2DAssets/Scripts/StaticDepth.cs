using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StaticDepth : MonoBehaviour
{
    // Bu script objelerin Y de�erine ba�l� olarak sprite order �n� de�i�tirerek 2D oyunlarda derinlik hissi vermek i�in kullan�l�r.
    //Dinamikten farkl� olarak sabit objeler i�in sadece bir kere Start'da �al���r
    SpriteRenderer _MySpren;  //SpriteRenderer Referans�
    [SerializeField]
    float _correction = 0;  //Correction, do�rudan yerin �zerinde olmayan (rafta duran, oyuncunun ta��d��� veya bir �ekilde havada duran) objeler i�in kullan�lacak.
                            //Bu de�er objenizin yere izd���m�nden y�ksekli�ine e�it olmal� (�rne�in 1 birim yukarda ta��nan obje i�in 1 olmal�).

    private void Awake()
    {
        _MySpren = GetComponent<SpriteRenderer>(); //referans al�m�
    }
    void Start()
    {
        _MySpren.sortingOrder = Mathf.FloorToInt((transform.position.y - _correction) * -100); //Y de�eri correction ile d�zeltilip,  -100 ile �arp�l�p, sorting order a e�itlenir
                                                                                              //Y si b�y�k olan objeler, arkada g�z�kmeli.

    }


}
