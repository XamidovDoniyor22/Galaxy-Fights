using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UiController : MonoBehaviour
{
    [SerializeField] private GameObject inventoryPanel;
    [SerializeField] private bool inventoryPanelIsOpen;

    [SerializeField] public bool greenMagicSelected;
   
    [SerializeField] public bool hammerSelected;
    [SerializeField] public bool shieldSelected;

    [SerializeField] private Image bombButton;
    
    [SerializeField] private Image hammerButton;
    [SerializeField] private Image shieldButton;

    [Header("InventoryIndicators")]
    public Text bombNumbers;
    public Text shieldText;
    public Text hammerText;

    [Header("Selected")]
    public Text bombSelectedText;
    public Text shielSelectedText;
    public Text hammerSelectedText;

    [Space]
    public BulletCountMechanism checks;

    private void Awake()
    {
        inventoryPanelIsOpen = false;   
        inventoryPanel.SetActive(false);

        checks = GameObject.FindGameObjectWithTag("Player").GetComponent<BulletCountMechanism>();
    }
    private void Update()
    {
        InventoryPanel();
        bombNumbers.text = checks.bombNumber.ToString();
        shieldText.text =  checks.shieldIsAccessible.ToString();
        hammerText.text = checks.hammerAccesible.ToString();

        bombSelectedText.text = greenMagicSelected.ToString();
        hammerSelectedText.text = hammerSelected.ToString();
        shielSelectedText.text = shieldSelected.ToString();
       
    }
    private void FixedUpdate()
    {
        if(checks.bombNumber > 0)
        {
            bombButton.color = Color.green;
            bombNumbers.color = Color.green;
        }
        if(checks.bombNumber <= 0)
        {
            bombButton.color = Color.red;
        }
       
        if (checks.hammerAccesible)
        {
            hammerButton.color = Color.green;
            hammerText.color = Color.green;
        }
        if(!checks.hammerAccesible)
        {
            hammerButton.color = Color.red;
        }

        if(checks.shieldIsAccessible)
        {
            shieldButton.color = Color.green;
            shieldText.color = Color.green;
        }
        if(!checks.shieldIsAccessible)
        {
            shieldButton.color = Color.red;
        }
    }
    private void InventoryPanel()
    {
        if (Input.GetKeyDown(KeyCode.Tab))
        {
            inventoryPanelIsOpen = !inventoryPanelIsOpen;
            inventoryPanel.gameObject.SetActive(inventoryPanelIsOpen);

        }
    }
    public void GreenMagicButton()
    {
        if (checks.bombNumber > 0)
        {
            greenMagicSelected = true;
           
        }
        else
        { 
            greenMagicSelected = false;
        }
    }
    public void HammerButton()
    {
        if(checks.hammerAccesible)
        {
            hammerSelected = true;
            greenMagicSelected = false;
           
        }
        else
        {
            hammerSelected  = false;
         
        }
    }
    public void ShieldButton()
    {
        if(checks.shieldIsAccessible)        
        shieldSelected = true;        
    }
}
