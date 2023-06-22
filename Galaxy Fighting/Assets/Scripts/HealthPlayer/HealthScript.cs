using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthScript : MonoBehaviour
{
    [SerializeField]
    public int playerHealth = 100;
    public Text healthText;

    [Header("ShieldChecks")]
    public UiController uiController;
    public BulletCountMechanism bulletCountMechanism;

    public HealthBarScript healthBarScript;

    [Header("ParticleSystem")]
    public ParticleSystem crawlingEnemyEffect;
    public ParticleSystem flyingEneyEffect;
    public ParticleSystem bombTowerEffect;

    [Header("Sounds")]
    public AudioSource audioSource;
    public AudioClip clip;
    public AudioClip deathSound;

    [Header("UI")]
    public GameObject losePanel;


    private void Start()
    {
        uiController = GameObject.Find("Canvas").GetComponent<UiController>();
        healthBarScript = GameObject.FindGameObjectWithTag("HealthBar").GetComponent<HealthBarScript>();
        healthBarScript.SetHealth(playerHealth);
        audioSource = GameObject.FindGameObjectWithTag("AudioSource").GetComponent<AudioSource>();
        losePanel.SetActive(false);
    }


    private void OnTriggerEnter(Collider other)
    {
        if (!uiController.shieldSelected)
        {
            if (other.gameObject.tag == "CrawlingEnemy")
            {
                Instantiate(crawlingEnemyEffect, this.transform.position, transform.rotation);
                audioSource.PlayOneShot(clip);
                playerHealth -= 10;
                healthBarScript.HealthBar(playerHealth);
            }
            if (other.gameObject.tag == "FlyingEnemy")
            {
                Instantiate(flyingEneyEffect, this.transform.position, transform.rotation);
                audioSource.PlayOneShot(clip);
                playerHealth -= 20;
                healthBarScript.HealthBar(playerHealth);
            }
            if (other.gameObject.tag == "TowerBomb")
            {
                Instantiate(bombTowerEffect, this.transform.position, transform.rotation);
                audioSource.PlayOneShot(clip);
                playerHealth -= 6;
                healthBarScript.HealthBar(playerHealth);
            }
        }
    }


    private void HealthChecker()
    {
        if(playerHealth <= 0)
        {
            audioSource.PlayOneShot(deathSound);
            losePanel.SetActive(true);
            Debug.Log("Lose");
        }
    }
    private void Update()
    {
        HealthChecker();
        healthText.text = playerHealth.ToString() + " / 100";
    }
    
}
