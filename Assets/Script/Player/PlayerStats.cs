using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PlayerStats : MonoBehaviour
{
    public bool inRange = false;

    public int dollars;
    [SerializeField]
    private int hp = 1;

   

    // Start is called before the first frame update
    void Start()
    {
        dollars = 0;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void DecreaseDollars(int amount)
    {
        dollars -= amount;
    }
    public void IncreaseDollars(int amount)
    {
        dollars += amount;
    }

    public bool VerifDollarsNeedIsOk(int amount)
    {
        if (dollars >= amount)
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    public void DecreaseHp(int amount)
    {
        hp -= amount;
    }

}
