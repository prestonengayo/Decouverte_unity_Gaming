using UnityEngine;

public class Symbol : MonoBehaviour, ICollectible
{
    [SerializeField] private int _quantity = 3;

    // Implémentation de la méthode Collect
    public void Collect(Player pPlayer)
    {
        Debug.Log("Symbol collected, adding " + _quantity + " symbols to player");
        pPlayer.AddSymbol(_quantity);
        Destroy(gameObject); // Détruire l'objet une fois collecté
    }
}