using UnityEngine;

public class MovementController : MonoBehaviour
{
    // Attributs s�rialis�s
    [SerializeField] private float _speed;

    private Animator _animator;

    // M�thode appel�e au d�marrage
    private void Start()
    {
        // Initialisation de l'animator si n�cessaire
        _animator = GetComponent<Animator>();
    }

    // M�thode appel�e chaque frame
    private void Update()
    {
        // � impl�menter si n�cessaire
    }
}
