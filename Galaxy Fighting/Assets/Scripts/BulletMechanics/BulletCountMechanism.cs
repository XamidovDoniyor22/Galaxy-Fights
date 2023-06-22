using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletCountMechanism : MonoBehaviour
{
    [SerializeField] public int bombNumber;
   
    public bool hammerAccesible;
    public bool shieldIsAccessible;

    public void BombNumber()
    {
        bombNumber += 10;
    }
    
    public void HammerCount()
    {
        hammerAccesible = true;
    }
    public void ShieldCount()
    {
        shieldIsAccessible = true;
    }
}
