using UnityEngine;

public class Orb : MonoBehaviour
{
    // L'attribut doit �tre s�rialis� et doit pouvoir �tre manipul� avec un getter et un setter
    [SerializeField] private int _quantity;

    public int Quantity
    {
        get => _quantity;
        set => _quantity = value;
    }

    // M�thode Unity appel�e lorsque le joueur entre en collision avec l'objet
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Collect(collision.gameObject.GetComponent<Player>());
        }
    }

    // M�thode pour ajouter la quantit� d'orbes au joueur
    public void Collect(Player pPlayer)
    {
        if (pPlayer != null)
        {
            pPlayer.AddOrb(_quantity);
            Destroy(gameObject); // D�truit l'objet apr�s la collecte
        }
    }

    // Retourne l'instance sous format string
    public override string ToString()
    {
        return $"Orb Quantity: {_quantity}";
    }
}
