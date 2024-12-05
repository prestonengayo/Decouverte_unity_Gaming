using UnityEngine;

public class Trap : MonoBehaviour, IDamageable
{
    // Attributs s�rialis�s
    [SerializeField] private int _damageAmount = 10;

    // Inflige des d�g�ts au personnage
    public void Damage(int pDamage)
    {
        Debug.Log("Player has taken damage from trap");
        GameObject player = GameObject.FindGameObjectWithTag("Player");
        if (player != null)
        {
            Player playerComponent = player.GetComponent<Player>();
            if (playerComponent != null)
            {
                playerComponent.AddExperiences(-pDamage); // Exemple de logique pour infliger des d�g�ts
            }
        }
    }

    // M�thode Unity OnTriggerEnter2D
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Damage(_damageAmount);
        }
    }
}
