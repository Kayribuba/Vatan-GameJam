using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloorTeleporter : MonoBehaviour
{
    //bu script kap�larda ve merdiven ba�lar�nda di�er kata teleport olman�z� sa�lar
    //�NEML� : Sadece test ama�l� olarak, i�eride oynayan basit bir Dummy karakter var
    // buradaki scriptler sadece b�l�m� g�stermek i�in h�zl�ca yap�lm�� �eyler, mutlaka kendi yakla��m�n�z� deneyiniz.
    bool CanTeleport = false; //oyuncunun teleport alan�nda olup olmad���n� kontrol eden bool
    [SerializeField]
    Vector3 teleporLocation; //teleport olunacak nokta
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (CanTeleport && Input.GetKeyDown(KeyCode.Space))
        {
            DummyController.instance.transform.position = teleporLocation; //e�er do�ru alandayken space e bas�l�rsa singleton dummycontroller � gitmesi gereken kata ���nl�yor.
        }
        
    }

    private void OnTriggerEnter2D(Collider2D collision) //character teleport alan�na girdi mi?
    {
        if (collision.CompareTag("CharacterTag")) { CanTeleport = true; }
    }

    private void OnTriggerExit2D(Collider2D collision) //character teleport alan�ndan ��kt� m�?
    {
        if (collision.CompareTag("CharacterTag")) { CanTeleport = false; }
    }
}
