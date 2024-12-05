using UnityEngine;

public class Gem : MonoBehaviour, ICollectible
{
    [SerializeField] private int _quantity = 5;

    // Implémentation de la méthode Collect
    public void Collect(Player pPlayer)
    {
        Debug.Log("Gem collected, adding " + _quantity + " gems to player");
        pPlayer.AddGem(_quantity);
        Destroy(gameObject); // Détruire l'objet une fois collecté
    }
}
