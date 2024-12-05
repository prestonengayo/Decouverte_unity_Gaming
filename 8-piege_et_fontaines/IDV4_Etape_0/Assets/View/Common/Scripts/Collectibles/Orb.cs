using UnityEngine;

public class Orb : MonoBehaviour
{
    // L'attribut doit être sérialisé et doit pouvoir être manipulé avec un getter et un setter
    [SerializeField] private int _quantity;

    public int Quantity
    {
        get => _quantity;
        set => _quantity = value;
    }

    // Méthode Unity appelée lorsque le joueur entre en collision avec l'objet
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Collect(collision.gameObject.GetComponent<Player>());
        }
    }

    // Méthode pour ajouter la quantité d'orbes au joueur
    public void Collect(Player pPlayer)
    {
        if (pPlayer != null)
        {
            pPlayer.AddOrb(_quantity);
            Destroy(gameObject); // Détruit l'objet après la collecte
        }
    }

    // Retourne l'instance sous format string
    public override string ToString()
    {
        return $"Orb Quantity: {_quantity}";
    }
}
