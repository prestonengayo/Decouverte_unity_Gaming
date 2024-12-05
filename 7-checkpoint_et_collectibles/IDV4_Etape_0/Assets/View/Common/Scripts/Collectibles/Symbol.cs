using UnityEngine;

public class Symbol : MonoBehaviour
{
    [SerializeField] private int _quantity;

    public int Quantity
    {
        get => _quantity;
        set => _quantity = value;
    }

    private void Start()
    {
        // Définir la quantité à 3
        _quantity = 3;
    }
}
