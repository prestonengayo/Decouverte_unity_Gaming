using UnityEngine;

public class MovementController : MonoBehaviour
{
    // Attributs sérialisés
    [SerializeField] private float _speed;

    private Animator _animator;

    // Méthode appelée au démarrage
    private void Start()
    {
        // Initialisation de l'animator si nécessaire
        _animator = GetComponent<Animator>();
    }

    // Méthode appelée chaque frame
    private void Update()
    {
        // À implémenter si nécessaire
    }
}
