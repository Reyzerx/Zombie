using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnZombie : MonoBehaviour
{
    private int indexZombie = 0;

    public int nbZombieSpawn;

    public GameObject prefabZombie;

    public Transform[] spawnPoints;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.C))
        {
            SpawnPrefabZombie(nbZombieSpawn, 5);
        }
    }

    public void SpawnPrefabZombie(int number, int health)
    {
        for (int i = 0; i < number; i++)
        {
            //Choix du point de spawn
            int spawnPointIndex = Random.Range(0, spawnPoints.Length);
            Transform spawnPoint = spawnPoints[spawnPointIndex];

            indexZombie++;
            float aleaPosX = Random.Range(spawnPoint.position.x-2, spawnPoint.position.x+2);
            float aleaPosZ = Random.Range(spawnPoint.position.z - 4, spawnPoint.position.z + 4);

            GameObject zombie = Instantiate(prefabZombie, new Vector3(aleaPosX, 0.5f, aleaPosZ), Quaternion.identity);
            zombie.GetComponent<Zombie>().RegisterZombie(indexZombie.ToString());
        }
    }
    //Pour chaque point de spawn he veux faire spawn un ou plusieur zombie
    //C'est a dire que chaque zombie qui va spawn va spawn a un point de spawn aleatoire
    //Si on as 3 pts de spawn et 10 zombie il peu y avoir 5 zombie pts 1 3 zombie pts 2 et 2 zombie pts3

}
