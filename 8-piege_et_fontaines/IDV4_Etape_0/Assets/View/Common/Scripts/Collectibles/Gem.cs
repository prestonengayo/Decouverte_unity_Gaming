using UnityEngine;

public class Gem : MonoBehaviour
{
    // Attribut s�rialis� pour la quantit�
    [SerializeField] private int _quantity;

    // Getter et setter pour la quantit�
    public int Quantity
    {
        get => _quantity;
        set => _quantity = value;
    }

    // M�thode Unity OnTriggerEnter2D
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Collect(collision.gameObject.GetComponent<Player>());
        }
    }

    // M�thode pour collecter la gemme
    public void Collect(Player player)
    {
        if (player != null)
        {
            player.AddGem(_quantity);
            Destroy(gameObject); // D�truit l'objet une fois collect�
        }
    }
}
