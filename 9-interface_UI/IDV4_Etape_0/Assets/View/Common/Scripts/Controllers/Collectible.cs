using UnityEngine;

public class Collectible : MonoBehaviour, ICollectible
{
    // Attributs s�rialis�s
    [SerializeField] private int _quantity;

    public int Quantity
    {
        get => _quantity;
        set => _quantity = value;
    }

    // Impl�mentation des m�thodes de l'interface ICollectible
    public void Collect(Player pPlayer)
    {
        // Logique pour ajouter la quantit� collectible au joueur
        pPlayer.AddGem(_quantity);
        Destroy(gameObject);
    }

    // M�thode Unity OnTriggerEnter2D
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
