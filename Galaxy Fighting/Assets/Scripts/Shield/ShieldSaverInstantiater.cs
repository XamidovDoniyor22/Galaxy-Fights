using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShieldSaverInstantiater : MonoBehaviour
{
    public GameObject[] objects;
    public Transform point;
    
    private void Start()
    {
        
        StartCoroutine(InstantiateObjects());
    }
    private IEnumerator InstantiateObjects()
    {
        while(true)
        {
            var bottleIndex = Random.Range(0, objects.Length);

            Instantiate(objects[bottleIndex], point.position, Quaternion.identity);

            yield return new WaitForSeconds(9f);
        }
    }
}
