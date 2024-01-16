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

    public bool shieldEnabled = false;
    private HealthControl healthControl;
 
    void Start()
    {
        healthControl = GetComponent<HealthControl>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && healthControl.stamina >= 40)
        {
            ToggleShield();
            Debug.Log(healthControl.stamina);
        }


    }

    private void ToggleShield()
    {
        shieldEnabled = !shieldEnabled;
        
        shield.SetActive(shieldEnabled);
        
         
        if (!shieldEnabled)
        {
            healthControl.DecreaseStamina(40);
            fire.SetActive(true);

        }
        else
        {
            fire.SetActive(false);
        }
    }


}
