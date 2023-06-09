using UnityEngine;

public class Zombie : MonoBehaviour
{
    [SerializeField]
    private int maxHealth = 5;

    private int currentHealth;

    private int dollarsGiven;

    // Start is called before the first frame update
    void Start()
    {
        currentHealth = maxHealth;
        dollarsGiven = 100;
    }

    public void TakeBodyDamage(int amount)
    {
        currentHealth -= amount;
        Debug.Log(transform.name + " a maintenant " + currentHealth + " point de vies");
    }
    public void TakeHeadDamage(int amount)
    {
        currentHealth -= amount*3;
        Debug.Log(transform.name + " a maintenant " + currentHealth + " point de vies");
    }

    public void Death()
    {
        Destroy(this.gameObject);
    }

    public int getCurrentHealth()
    {
        return currentHealth;
    }

    public void RegisterZombie(string id)
    {
        GameManager.RegisterZombie(id, GetComponent<Zombie>());
    }

    public int GetDollarsGiven()
    {
        return dollarsGiven;
    }

    public void setMaxHealth(int amount)
    {
        maxHealth = amount;
    }

    public int getMaxHealth()
    {
        return maxHealth;
    }
}
