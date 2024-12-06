using UnityEngine;

public class Gem : MonoBehaviour, ICollectible
{
    [SerializeField] private int _quantity = 5;

    // Impl�mentation de la m�thode Collect
    public void Collect(Player pPlayer)
    {
        Debug.Log("Gem collected, adding " + _quantity + " gems to player");
        pPlayer.AddGem(_quantity);
        Destroy(gameObject); // D�truire l'objet une fois collect�
    }
}
