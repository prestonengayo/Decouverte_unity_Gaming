using UnityEngine;

public class Collectible : MonoBehaviour, ICollectible
{
    // Attributs sérialisés
    [SerializeField] private int _quantity;

    public int Quantity
    {
        get => _quantity;
        set => _quantity = value;
    }

    // Implémentation des méthodes de l'interface ICollectible
    public void Collect(Player pPlayer)
    {
        // Logique pour ajouter la quantité collectible au joueur
        pPlayer.AddGem(_quantity);
        Destroy(gameObject);
    }

    // Méthode Unity OnTriggerEnter2D
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Collect(collision.gameObject.GetComponent<Player>());
        }
    }

    // Retourne la valeur de la variable _quantity
    public int GetQuantity()
    {
        return _quantity;
    }

    // Retourne l'instance sous format string
    public override string ToString()
    {
        return $"Collectible Quantity: {_quantity}";
    }
}
