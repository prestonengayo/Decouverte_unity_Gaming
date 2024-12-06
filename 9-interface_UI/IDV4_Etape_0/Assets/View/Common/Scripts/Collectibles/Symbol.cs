using UnityEngine;

public class Symbol : MonoBehaviour, ICollectible
{
    [SerializeField] private int _quantity = 3;

    // Impl�mentation de la m�thode Collect
    public void Collect(Player pPlayer)
    {
        Debug.Log("Symbol collected, adding " + _quantity + " symbols to player");
        pPlayer.AddSymbol(_quantity);
        Destroy(gameObject); // D�truire l'objet une fois collect�
    }
}