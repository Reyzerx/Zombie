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
}
