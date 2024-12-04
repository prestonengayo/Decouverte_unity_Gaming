using UnityEngine;

public class PlayerController : MonoBehaviour
{
    // Attributs sérialisés
    [SerializeField] private Player _player;

    // Méthode appelée chaque frame
    private void Update()
    {
        // À implémenter si nécessaire
    }

    // Méthode appelée lorsqu'un objet entre en collision avec ce GameObject (2D)
    private void OnTriggerEnter2D(Collider2D collision)
    {
        // À implémenter si nécessaire
    }
}
