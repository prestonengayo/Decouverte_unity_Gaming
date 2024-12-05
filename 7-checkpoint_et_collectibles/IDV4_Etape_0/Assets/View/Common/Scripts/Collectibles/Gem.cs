using UnityEngine;

public class Gem : MonoBehaviour
{
    // Attribut sérialisé pour la quantité
    [SerializeField] private int _quantity;

    // Getter et setter pour la quantité
    public int Quantity
    {
        get => _quantity;
        set => _quantity = value;
    }

    // Méthode Unity OnTriggerEnter2D
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Collect(collision.gameObject.GetComponent<Player>());
        }
    }

    // Méthode pour collecter la gemme
    public void Collect(Player player)
    {
        if (player != null)
        {
            player.AddGem(_quantity);
            Destroy(gameObject); // Détruit l'objet une fois collecté
        }
    }
}
