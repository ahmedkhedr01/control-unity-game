using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;



public class HealthControl : MonoBehaviour
{
    private PlayerInput _playerInput;
    public int healthPoints = 100;
    public bool isDead = false;
    public int stamina = 100;
    public int energy = 100;
    public Animator chargedanim;
    public bool hasIncreasedHealth = false; // Flag to track if health has been increased
    public bool hasDecreasedHealth = false; // Flag to track if health has been decreased
    private WaitForSeconds increaseDelay = new WaitForSeconds(1f); // Wait for 1 second
    public bool justFiredWeapon = false;

    private HealthBar healthBar;


    private WaitForSeconds staminaRegenerationDelay = new WaitForSeconds(1f);
    private ShieldControl shieldControl;
    private float lastStaminaRegenerationTime;
    void Start()
    {
        GameObject healthBarGameObject = GameObject.FindWithTag("HealthBar").transform.gameObject;
        healthBar = healthBarGameObject.GetComponent<HealthBar>();
        
        
        
        shieldControl = GetComponent<ShieldControl>();
       
        StartCoroutine(IncreaseHealthOverTime());
        StartCoroutine(IncreaseEnergyOverTime());
    }

    private void Update()
    {
        if (transform.position.y < -10.0f)
        {
            isDead = true;
            healthBar.UpdateHealthBar(0, 100);
            healthPoints = 0;
        }
        if (healthPoints <= 0)
        {
            isDead = true;
            Debug.Log("You are dead by health");
        }
        // check for the active scene
        if (UnityEngine.SceneManagement.SceneManager.GetActiveScene().name == "Playground")
        {
            if (chargedanim.GetBool("explosion"))
            {
                if (healthPoints <= 50 && !hasDecreasedHealth)
                {
                    DecreaseHealth(50);
                    hasDecreasedHealth = true;
                    chargedanim.SetBool("explosion", false);
                    Debug.Log("2");
                }
                else if (healthPoints > 50 && !hasIncreasedHealth)
                {
                    DecreaseHealth(55);
                    hasIncreasedHealth = true;
                    chargedanim.SetBool("explosion", false);
                    StartCoroutine(IncreaseHealthOverTime());
                    Debug.Log("1");
                    hasDecreasedHealth = true;
                    hasIncreasedHealth = false;

                }
            }
        }

           
        }
        if (stamina < 100 && Time.time - lastStaminaRegenerationTime >= 1f)
        {
            StartCoroutine(RegenerateStaminaOverTime());
            lastStaminaRegenerationTime = Time.time;
        }



    }

    private IEnumerator IncreaseHealthOverTime()
    {
        while (true)
        {
            yield return increaseDelay;

            if (!hasIncreasedHealth)
            {
                IncreaseHealth(5);
                hasIncreasedHealth = true;
                // Reset hasIncreasedHealthThisSecond after 1 second
                yield return new WaitForSeconds(1f);
                hasIncreasedHealth = false;
            }
        }
    }

    private IEnumerator IncreaseEnergyOverTime()
    {

        while (true)
        {
            if (!justFiredWeapon)
            {
                IncreaseEnergy(5);

                yield return new WaitForSeconds(1f);
            }
            else
            {
                // If the weapon was just fired, wait for 2 seconds
                yield return new WaitForSeconds(10f);

                // Reset justFiredWeapon after 2 seconds
                justFiredWeapon = false;
            }
        }

    }



    public void IncreaseStamina(int s)
    {
        if (s + stamina > 100)
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
        healthBar.UpdateHealthBar(healthPoints, 100);
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
        justFiredWeapon = true;
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
        healthBar.UpdateHealthBar(healthPoints, 100);
    }


    private IEnumerator RegenerateStaminaOverTime()
    {
        if(!shieldControl.shieldEnabled)
        {
            IncreaseStamina(5);
            yield return staminaRegenerationDelay;
                
            
        }
        Debug.Log("no increase" + stamina);
        
    }

}