using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShieldSaver : MonoBehaviour
{
    public bool shieldActive = false;
   
    public Material material;

    public HealthScript healthPlus;
    public HealthBarScript healthBar;

    private void Start()
    {
        healthPlus = GameObject.FindGameObjectWithTag("Player").GetComponent<HealthScript>();
        healthBar = GameObject.FindGameObjectWithTag("HealthBar").GetComponent<HealthBarScript>();
    }
    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            shieldActive = true;
            material.color = Color.green;
            HpPlus();
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            shieldActive = false;
            material.color = Color.red;
        }
    }
    private void HpPlus()
    {
        if (healthPlus.playerHealth < 100)
        {
            healthPlus.playerHealth++;
            healthBar.HealthBar(healthPlus.playerHealth);
        }

        if (healthPlus.playerHealth >= 100) healthPlus.playerHealth = 100;
    }
   
       
    
}
