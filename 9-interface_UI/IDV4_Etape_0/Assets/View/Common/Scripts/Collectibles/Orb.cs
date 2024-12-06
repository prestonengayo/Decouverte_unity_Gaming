using UnityEngine;

public class Orb : MonoBehaviour, ICollectible
{
    [SerializeField] private int _quantity = 1;

    // Impl�mentation de la m�thode Collect
    public void Collect(Player pPlayer)
    {
        Debug.Log("Orb collected, adding " + _quantity + " orbs to player");
        pPlayer.AddOrb(_quantity);
        Destroy(gameObject); // D�truire l'objet une fois collect�
    }
}