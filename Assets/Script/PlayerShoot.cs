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
            Debug.LogError("Pas de Camera renseign�e sur le syst�me de tir");
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

        if (Physics.Raycast(cam.transform.position, cam.transform.forward, out hit, weapon.range, mask))
        {
            if (hit.collider.tag == "Zombie")
            {
                Zombie zombie = GameManager.GetZombie(hit.collider.name);

                zombie.TakeDamage(weapon.damage);
            }
            Debug.Log("Objet touch� : " + hit.collider.name);
        }

        
    }
}
