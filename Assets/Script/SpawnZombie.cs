using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnZombie : MonoBehaviour
{
    private int indexZombie = 0;

    public GameObject prefabZombie;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            SpawnPrefabZombie();
        }
    }

    public void SpawnPrefabZombie()
    {
        indexZombie++;
        float aleaPosX = Random.Range(-10,10);
        float aleaPosZ = Random.Range(-10, 10);

        GameObject zombie = Instantiate(prefabZombie, new Vector3(aleaPosX, 0.5f, aleaPosZ), Quaternion.identity);
        zombie.GetComponent<Zombie>().RegisterZombie(indexZombie.ToString());
    }

}
