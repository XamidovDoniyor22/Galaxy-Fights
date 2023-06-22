using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UIButtons : MonoBehaviour
{
    public AudioSource audioSource;
    [SerializeField] public AudioClip audio;


    private void Start()
    {
        audioSource = GameObject.FindGameObjectWithTag("AudioSource").GetComponent<AudioSource>();
    }
    public void FirstLevel()
    {
        StartCoroutine(FirstLevelWait());
    }
    private IEnumerator FirstLevelWait()
    {
        audioSource.PlayOneShot(audio);
        yield return new WaitForSeconds(1f);
        SceneManager.LoadScene("SampleScene");
    }
    public void Menu()
    {
        StartCoroutine(MenuWait());
        
    }
    private IEnumerator MenuWait()
    {
        audioSource.PlayOneShot(audio);
        yield return new WaitForSeconds(1f);
        SceneManager.LoadScene("MenuScnene");
    }
    public void DialogueScene()
    {
        StartCoroutine(DialogueSceneWait());
       
    }
    private IEnumerator DialogueSceneWait()
    {
        audioSource.PlayOneShot(audio);
        yield return new WaitForSeconds(1f);
        SceneManager.LoadScene("DialogueScene");
    }
    
    public void Quit()
    {
        StartCoroutine(quitAppWait());
        
    }
    private IEnumerator quitAppWait()
    {
        audioSource.PlayOneShot(audio);
        yield return new WaitForSeconds(1f);
        Application.Quit();
    }
}
