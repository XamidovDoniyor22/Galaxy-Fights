using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemies : MonoBehaviour
{
    [SerializeField]
    private float distance;
    [SerializeField]
    private float distanceCrawlingEnemy;
    [SerializeField]
    private float distanceFlyingEnemy;
    [SerializeField]
    private GameObject enemy;
    [SerializeField]
    private GameObject player;
    [SerializeField]
    private Transform playerTransform;
    [SerializeField]
    private int speedForCrawling = 3;
    [SerializeField]
    private int speedForFlying = 5;
    [SerializeField]
    private ShieldSaver shieldSaver;

    [Space]
    [Header("SoundEffects")]
    public AudioSource audioSource;
    public AudioClip clip;

    public enemies enemyType;
    public enum enemies
    {
        crawlingEnemy = 0,
        flyingEnemy = 1
    }
    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        playerTransform = player.transform;
        shieldSaver = GameObject.FindGameObjectWithTag("ShieldSaver").GetComponent<ShieldSaver>();
        audioSource = GameObject.FindGameObjectWithTag("AudioSource").GetComponent<AudioSource>();
    }
    private void DistanceChecker()
    {
        distance = Vector3.Distance(enemy.transform.position, player.transform.position);
    }
    private void Enemy()
    {
       if(enemyType == enemies.crawlingEnemy)
        {
           
            if(distance <= distanceCrawlingEnemy && !shieldSaver.shieldActive)
            {
                transform.position = Vector3.MoveTowards(this.transform.position, playerTransform.transform.position, speedForCrawling * Time.deltaTime);
            }
        }
        if (enemyType == enemies.flyingEnemy)
        {
            if (distance <= distanceFlyingEnemy && !shieldSaver.shieldActive)
            {
                transform.position = Vector3.MoveTowards(this.transform.position, playerTransform.transform.position, speedForFlying * Time.deltaTime);

            }
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Bomb")
        {
            Destroy(gameObject);
            Destroy(other.gameObject);
        }
    }
    private void Update()
    {
        DistanceChecker();
        Enemy();
        
    }
   
}
