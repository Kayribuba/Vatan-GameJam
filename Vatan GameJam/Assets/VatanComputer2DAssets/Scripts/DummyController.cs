using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DummyController : MonoBehaviour
{
    //Hariyat� g�sterbilmek i�in haz�rlanm�� basit bir character controller.
    public static DummyController instance; //h�zl�ca ula�mak i�in singleton kullan�yoruz.
    float x, y;
    Rigidbody2D _MyRigBod;
    [SerializeField]
    float MoveSpeed;
    Vector2 _direction;
    private void Awake()
    {
        if(instance!=null && instance != this) { Destroy(gameObject); }
        else { instance = this; }
        _MyRigBod = GetComponent<Rigidbody2D>();
        
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        GetInput();
    }

    private void FixedUpdate()
    {
        Move();
    }

    void GetInput() //input al�m�
    {
        x = Input.GetAxis("Horizontal");
        y = Input.GetAxis("Vertical");
    }

    void Move() //inputa ba�l� hareket, basit�e tasarland�
    {
        _direction = new Vector2(x, y);
        if(_direction.magnitude>0)
        {
            _MyRigBod.velocity = _direction.normalized * MoveSpeed;
        }
        else
        {
            _MyRigBod.velocity = Vector2.zero;
        }
    }
}
