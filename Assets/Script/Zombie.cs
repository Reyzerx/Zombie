using UnityEngine;

public class Zombie : MonoBehaviour
{
    [SerializeField]
    private int maxHealth = 3;

    private int currentHealth;

    // Start is called before the first frame update
    void Start()
    {
        currentHealth = maxHealth;
        GameManager.RegisterZombie("1", GetComponent<Zombie>());
    }

    public void TakeDamage(int amount)
    {
        currentHealth -= amount;
        Debug.Log(transform.name + "a maintenant " + currentHealth + " point de vies");
    }
}
