using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuyTrigger : MonoBehaviour
{
    [SerializeField]
    private PlayerShoot playerShoot;
    [SerializeField]
    private PlayerStats playerStats;
    [SerializeField]
    private PlayerWeapon playerWeapon;


    public int gunCost;
    public int munitionCost;
    public int munitionGiven;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && playerStats.inRange && playerWeapon.munition < playerWeapon.capacityMunition)
        {
            //Rechargement de l'arme
            buyMunition();
        }
    }

    public void buyGun()
    {

    }

    public void buyMunition()
    {
        if (playerStats.VerifDollarsNeedIsOk(munitionCost))
        {
            playerStats.DecreaseDollars(munitionCost);
            playerShoot.IncreaseAmmo(munitionGiven);
            playerShoot.UpdateUiDollars();
        }
        else
        {
            Debug.Log("Pas asser d'argent");
        }
    }


    private void OnTriggerEnter(Collider other)
    {
        if(other.name == "Player")
        {
            playerShoot.costText.text = "Gun \n" + gunCost + "$ \n \n";
            playerShoot.costText.text += munitionGiven + " munitions \n" + munitionCost + "$"; 

            playerShoot.costText.enabled = true;
            playerStats.inRange = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        playerShoot.costText.enabled = false;
        playerStats.inRange = false;
    }
}
