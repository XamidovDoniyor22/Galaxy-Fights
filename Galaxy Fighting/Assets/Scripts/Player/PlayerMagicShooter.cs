using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
public class PlayerMagicShooter : MonoBehaviour
{
    [SerializeField] private GameObject bombPrefab;

    [SerializeField] private float reloadTime;
    [SerializeField] private float startReloadTime;
    [SerializeField] private Transform point;

    [Space]
    public UiController uiController;
    public BulletCountMechanism count;

    [Header("Hammer")]
    [SerializeField] private GameObject hammer;
    [SerializeField] private Animator animator;

    [Header("Shield")]
    [SerializeField] private GameObject shield;
    [SerializeField] private UiController shieldActive;
    [Header("SoundSettings")]
    public AudioSource audioSource;
    public AudioClip hammerClip;
    public AudioClip shieldClip;
    public AudioClip bombClip;


    private void Start()
    {
        uiController = GameObject.Find("Canvas").GetComponent<UiController>();
        count = GameObject.FindGameObjectWithTag("Player").GetComponent<BulletCountMechanism>();
      
        hammer = transform.GetChild(4).gameObject;
        animator = hammer.GetComponent<Animator>();
        hammer.SetActive(false);
        shield = transform.GetChild(5).gameObject;
        shield.SetActive(false);
        shieldActive = GameObject.Find("Canvas").GetComponent<UiController>();
        audioSource = GameObject.FindGameObjectWithTag("AudioSource").GetComponent<AudioSource>(); 
    }

    public void BombShooting()
    {
        //if (EventSystem.current.IsPointerOverGameObject()) return;
        if (uiController.greenMagicSelected && count.bombNumber > 0)
        {
            //if (startReloadTime > reloadTime)
            //{
            //    if (Input.GetMouseButtonDown(0))
            //    {
            audioSource.PlayOneShot(bombClip);
            count.bombNumber--;
            Instantiate(bombPrefab, point.position, transform.rotation);
            reloadTime = startReloadTime;
        }
        
    }
   
    public void HammerMechanism()
    {
        //if (EventSystem.current.IsPointerOverGameObject()) return;
        //if (Input.GetKey(KeyCode.Q))
        //    {
            if (uiController.hammerSelected && count.hammerAccesible)
            {             
                hammer.SetActive(true);
                audioSource.PlayOneShot(hammerClip);
                StartCoroutine(wait());
                count.hammerAccesible = false;
            }
        //}
       if(!animator.GetCurrentAnimatorStateInfo(0).IsName("HammerAnimation")) 
        {
            hammer.SetActive(false);
        }
    }
    private IEnumerator wait()
    {
        yield return new WaitForSeconds(1f);
    }
    private void Shield()
    {
        if (EventSystem.current.IsPointerOverGameObject()) return;
        if (count.shieldIsAccessible && uiController.shieldSelected)
        {
            audioSource.PlayOneShot(shieldClip);
            StartCoroutine(ShieldWork());
            count.shieldIsAccessible = false;
            //uiController.shieldSelected = false;
        }
    }
    private IEnumerator ShieldWork()
    {
        shield.SetActive(true);
        shieldActive.shieldSelected = true;
        yield return new WaitForSeconds(5);
        shield.SetActive(false);
        shieldActive.shieldSelected = false;
    }

    private void Update()
    {
        //BombShooting();
        
        //HammerMechanism();
        Shield();
    }
}
