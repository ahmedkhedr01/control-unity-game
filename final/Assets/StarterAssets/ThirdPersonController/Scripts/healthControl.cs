using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class healthControl : MonoBehaviour
{
    // Start is called before the first frame update
    private PlayerInput _playerInput;
    public int healthPoints = 100 ;
    public int stamina = 100;
    public int energy = 100;
    void Start()
    {
        _playerInput = GetComponent<PlayerInput>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown("space"))
        {
            Debug.Log(stamina);
            DecreaseStamina(5);
            Debug.Log(stamina);
        }
    }
    public void IncreaseStamina(int s)
    {
        if(s + stamina > 100)
        {
            stamina = 100;
        }
        else
        {
            stamina += s;
        }
    }

    public void IncreaseEnergy(int e)
    {

        if (e + energy > 100)
        {
            energy = 100;
        }
        else
        {
            energy += e;
        }
    }


    public void IncreaseHealth(int h)
    {

        if (healthPoints + h > 100)
        {
            healthPoints = 100;
        }
        else
        {
            healthPoints += h;
        }
    }

    public void DecreaseStamina(int s)
    {
        if (stamina - s < 0)
        {
            stamina = 0;
        }
        else
        {
            stamina -= s;
        }
    }

    public void DecreaseEnergy(int e)
    {
        if (energy - e < 0)
        {
            energy = 0;
        }
        else
        {
            energy -= e;
        }
    }

    public void DecreaseHealth(int h)
    {
        if (healthPoints - h < 0)
        {
            healthPoints = 0;
        }
        else
        {
            healthPoints -= h;
        }
    }
}
