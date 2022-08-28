using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloorTeleporter : MonoBehaviour
{
    //bu script kapýlarda ve merdiven baþlarýnda diðer kata teleport olmanýzý saðlar
    //ÖNEMLÝ : Sadece test amaçlý olarak, içeride oynayan basit bir Dummy karakter var
    // buradaki scriptler sadece bölümü göstermek için hýzlýca yapýlmýþ þeyler, mutlaka kendi yaklaþýmýnýzý deneyiniz.
    bool CanTeleport = false; //oyuncunun teleport alanýnda olup olmadýðýný kontrol eden bool
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
            DummyController.instance.transform.position = teleporLocation; //eðer doðru alandayken space e basýlýrsa singleton dummycontroller ý gitmesi gereken kata ýþýnlýyor.
        }
        
    }

    private void OnTriggerEnter2D(Collider2D collision) //character teleport alanýna girdi mi?
    {
        if (collision.CompareTag("CharacterTag")) { CanTeleport = true; }
    }

    private void OnTriggerExit2D(Collider2D collision) //character teleport alanýndan çýktý mý?
    {
        if (collision.CompareTag("CharacterTag")) { CanTeleport = false; }
    }
}
