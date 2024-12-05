using UnityEngine;

public class Orb : MonoBehaviour, ICollectible
{
    [SerializeField] private int _quantity = 1;

    // Implémentation de la méthode Collect
    public void Collect(Player pPlayer)
    {
        Debug.Log("Orb collected, adding " + _quantity + " orbs to player");
        pPlayer.AddOrb(_quantity);
        Destroy(gameObject); // Détruire l'objet une fois collecté
    }
}