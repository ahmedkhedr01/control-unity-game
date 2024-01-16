using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;


public class ShieldControl : MonoBehaviour
{
    // Start is called before the first frame update
    private PlayerInput player;
    [SerializeField]  private GameObject shield;
    [SerializeField] private GameObject fire;

    private bool shieldEnabled = false;
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            ToggleShield();
           
        }


    }

    private void ToggleShield()
    {
        shieldEnabled = !shieldEnabled;

        shield.SetActive(shieldEnabled);

        if (!shieldEnabled)
        {
            fire.SetActive(true);
        }
    }


}
