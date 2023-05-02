using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static Dictionary<string, Zombie> zombies = new Dictionary<string, Zombie>();

    public static void RegisterZombie(string id, Zombie zombie)
    {
        string zombieId = "Zombie" + id;
        zombies.Add(zombieId, zombie);
        zombie.transform.name = zombieId;
    }

    public static void UnregisterZombie(string id)
    {
        zombies.Remove(id);
    }

    /*private void OnGUI()
    {
        GUILayout.BeginArea(new Rect(200, 200, 200, 500));
        GUILayout.BeginVertical();

        foreach(string zombieId in zombies.Keys)
        {
            GUILayout.Label(zombieId + " - " + zombies[zombieId].transform.name);
        }

        GUILayout.EndVertical();
        GUILayout.EndArea();
    }*/


    public static Zombie GetZombie(string zombieId)
    {
        return zombies[zombieId];
    }
}
