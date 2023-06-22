using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class KeyaUI : MonoBehaviour
{
    public GameObject keyFolder;
    public Image backGroundImage;
    public bool fourKeysReady = false;


    public GameObject[] keyImages;

    public Keys keys;

    private void Start()
    {
        keys = GameObject.FindGameObjectWithTag("KeyFolder").GetComponent<Keys>();
        keyFolder = GameObject.FindGameObjectWithTag("KeyFolderUI");
        
        keyImages[0] = keyFolder.transform.GetChild(0).GetChild(0).gameObject;
        keyImages[1] = keyFolder.transform.GetChild(1).GetChild(0).gameObject;
        keyImages[2] = keyFolder.transform.GetChild(2).GetChild(0).gameObject;
        keyImages[3] = keyFolder.transform.GetChild(3).GetChild(0).gameObject;
       
        keyImages[0].SetActive(false);
        keyImages[1].SetActive(false);
        keyImages[2].SetActive(false);
        keyImages[3].SetActive(false);       
    }
    private void Checker()
    {
        if (keys.keys == 4)
        {
            backGroundImage.color = Color.green;
            fourKeysReady = true;
        }
    }
    private void Update()
    {
        Checker();
    }

}
  

