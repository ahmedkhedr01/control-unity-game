using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponsControl : MonoBehaviour
{
    public GameObject Slot1;
    public GameObject Slot2;
    public GameObject Slot3;
    public GameObject Slot4;

    // public  RuntimeAnimatorController anim;
    private Animator anim;
    // Start is called before the first frame update
    void Start()
    {
       anim = gameObject.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown("1"))
        {
            Equip1();
        }
        if (Input.GetKeyDown("2"))
        {
            Equip2();
           
        }
        if (Input.GetKeyDown("3"))
        {
            Equip3();
        }
        if (Input.GetKeyDown("4"))
        {
            Equip4();
        }
        if (Input.GetKeyDown("8"))
        {
            Debug.Log("Spin Fire1");
            ShootSpin();
            Debug.Log("Spin Fire2");
        }

    }

    void Equip1()
    {
        Slot1.SetActive(true);
        Slot2.SetActive(false);
        Slot3.SetActive(false);
        Slot4.SetActive(false);

    }
    void Equip2()
    {
        Slot1.SetActive(false);
        Slot2.SetActive(true);
        Slot3.SetActive(false);
        Slot4.SetActive(false);
       
    }
    void Equip3()
    {
        Slot1.SetActive(false);
        Slot2.SetActive(false);
        Slot3.SetActive(true);
        Slot4.SetActive(false);
    }
    void Equip4()
    {
        Slot1.SetActive(false);
        Slot2.SetActive(false);
        Slot3.SetActive(false);
        Slot4.SetActive(true);
    }

    void ShootSpin()
    {
        anim.SetBool("SpinFire", true);
        //anim.Play("SpinShoot");

    }
}
