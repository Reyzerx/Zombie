using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Vague : MonoBehaviour
{
    public SpawnZombie scriptSpawnZombie;

    private int nbZombieSpawn;
    private int zombieHealth;
    private int nbVague;

    private bool timerFinish;

    public TMP_Text timerText;

    // Start is called before the first frame update
    void Start()
    {
        nbZombieSpawn = scriptSpawnZombie.nbZombieSpawn;
        zombieHealth = 5;
        nbVague = 1;
        timerText.text = "Vague " + nbVague;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void InitVague()
    {
        zombieHealth += 2;
        nbZombieSpawn *= 2;
    }

    public void SpawnVague()
    {
        scriptSpawnZombie.SpawnPrefabZombie(nbZombieSpawn, zombieHealth);
    }

    public void testVagueFinish()
    {
        if(GameManager.zombies.Count == 0)
        {
            StartCoroutine(timerAffichage(10));
        }
        
    }

    public IEnumerator timerAffichage(int seconds)
    {
        int timer = seconds;
        while (timer >= 0)
        {
            yield return new WaitForSeconds(1);
            print("le text doit changer");
            timerText.text = timer.ToString() + " secondes";
            timer--;
        }

        if(timer <= 0)
        {
            nbVague++;
            timerText.text = "Vague " + nbVague;
            InitVague();
            SpawnVague();
        }
        yield return null;
    }


}
