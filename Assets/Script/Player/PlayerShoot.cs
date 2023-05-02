using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PlayerShoot : MonoBehaviour
{
    public PlayerWeapon weapon;
    public ParticleSystem flashGun;
    public PlayerStats playerStats;
    public Vague vague;

    [SerializeField]
    private Camera cam;

    [SerializeField]
    private LayerMask mask;

    public TMP_Text ammoText;
    public TMP_Text costText;
    public TMP_Text dollarsText;



    private RaycastHit hitr;

    // Start is called before the first frame update
    void Start()
    {
        if(cam == null)
        {
            Debug.LogError("Pas de Camera renseignée sur le système de tir");
            this.enabled = false;
        }

        UpdateUiAmmo();
        costText.enabled = false;

        playerStats = GetComponent<PlayerStats>();
        dollarsText.text = "0$";
    }

    // Update is called once per frame
    void Update()
    {
        Debug.DrawRay(cam.transform.position, cam.transform.forward * weapon.range, Color.blue);
        if (Input.GetButtonDown("Fire1") && weapon.ammo > 0)
        {
            //tir coup par coup
            Shoot();
        }
        if (Input.GetKeyDown(KeyCode.R))
        {
            //Rechargement de l'arme
            Reload();
        }
    }
    private void Shoot()
    {
        RaycastHit hit;

        //Animation flashGun
        flashGun.Play();

        //Reduit le nombre de munition dans l'arme et update UI
        DecreaseAmmo();
        UpdateUiAmmo();

        if (Physics.Raycast(cam.transform.position, cam.transform.forward, out hit, weapon.range, mask, QueryTriggerInteraction.Ignore))
        {
            if (hit.collider.tag == "Zombie")
            {
                Zombie zombie = GameManager.GetZombie(hit.collider.transform.parent.name);

                if(hit.collider.transform.gameObject.layer == LayerMask.NameToLayer("ZombieHead")){
                    zombie.TakeHeadDamage(weapon.damage);
                }
                else if (hit.collider.transform.gameObject.layer == LayerMask.NameToLayer("ZombieBody"))
                {
                    zombie.TakeBodyDamage(weapon.damage);
                }

                if(zombie.getCurrentHealth() <= 0)
                {
                    GameManager.UnregisterZombie(hit.collider.transform.parent.name);
                    playerStats.IncreaseDollars(zombie.GetDollarsGiven());
                    UpdateUiDollars();
                    zombie.Death();
                    vague.testVagueFinish();
                }
            }
            Debug.Log("Objet touché : " + hit.collider.name);
        }

        
    }

    private void Reload()
    {
        int ammoNeed = weapon.capacityAmmo - weapon.ammo;

        if(weapon.munition >= ammoNeed)
        {
            weapon.ammo += ammoNeed;
            weapon.munition -= ammoNeed;
        }
        else
        {
            weapon.ammo += weapon.munition;
            weapon.munition = 0;
        }

        UpdateUiAmmo();
    }

    private void DecreaseAmmo()
    {
        weapon.ammo--;
    }
    public void IncreaseAmmo(int amount)
    {
        if((amount + weapon.munition) > weapon.capacityMunition)
        {
            weapon.munition = weapon.capacityMunition;
        }
        else
        {
            weapon.munition += amount;
        }

        UpdateUiAmmo();
    }

    private void UpdateUiAmmo()
    {
        ammoText.text = weapon.ammo + " / " + weapon.munition;
    }

    public void UpdateUiDollars()
    {
        dollarsText.text = playerStats.dollars + "$";
    }
}
