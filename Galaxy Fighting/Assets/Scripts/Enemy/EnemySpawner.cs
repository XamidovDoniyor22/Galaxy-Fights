using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] private GameObject crawlingEnemy;
    [SerializeField] private GameObject flyingEnemy;

    [SerializeField] private int crawlingEnemyNumber;
    [SerializeField] private int flyingEnemyNumber; 

    [SerializeField] private Transform point;
    public enum columnType
    {
        leftColumn = 0,
        rightColumn = 1
    }
    public columnType column;

    private void Start()
    {
        EnemySpawnerColumn();
    }
    private void EnemySpawnerColumn()
    {
        if(column == columnType.leftColumn)
        {
            StartCoroutine(LeftColumn());
        }
        if (column == columnType.rightColumn)
        {
            StartCoroutine(RightColumn());
        }
    }
    private IEnumerator RightColumn()
    {
        while (true)
        {
            Instantiate(flyingEnemy, point.position, transform.rotation);
            yield return new WaitForSeconds(10f);
        }
    }
    private IEnumerator LeftColumn()
    {

        while (true)
        {
            Instantiate(crawlingEnemy, point.position, transform.rotation);
            yield return new WaitForSeconds(10f);
        }
    }
    
}
