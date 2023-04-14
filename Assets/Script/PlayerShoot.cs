using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShoot : MonoBehaviour
{
    public PlayerWeapon weapon;

    [SerializeField]
    private Camera cam;

    [SerializeField]
    private LayerMask mask;

    // Start is called before the first frame update
    void Start()
    {
        if(cam == null)
        {
            Debug.LogError("Pas de Camera renseignée sur le système de tir");
            this.enabled = false;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            //tir coup par coup
            Shoot();
        }
        Debug.DrawRay(cam.transform.position, cam.transform.forward * weapon.range, Color.blue);
    }

    private void Shoot()
    {
        RaycastHit hit;

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
                    zombie.Death();
                }
            }
            Debug.Log("Objet touché : " + hit.collider.name);
        }

        
    }
}
