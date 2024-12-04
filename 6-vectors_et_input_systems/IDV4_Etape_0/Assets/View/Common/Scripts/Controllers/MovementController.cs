using UnityEngine;

public class MovementController : MonoBehaviour
{
    // Attributs sérialisés
    [SerializeField] private float _speed;

    private Animator _animator;

    // Méthode Start
    private void Start()
    {
        // Initialisation de l'Animator
        _animator = GetComponent<Animator>();
    }

    // Méthode Update
    private void Update()
    {
        Vector2 dir = Vector2.zero;

        if (Input.GetKey(KeyCode.Z) || Input.GetKey(KeyCode.W)) // Aller vers le haut (AZERTY: Z, QWERTY: W)
        {
            dir += Vector2.up;
            _animator.SetInteger("Direction", 3);
        }
        if (Input.GetKey(KeyCode.S)) // Aller vers le bas
        {
            dir += Vector2.down;
            _animator.SetInteger("Direction", 2);
        }
        if (Input.GetKey(KeyCode.Q) || Input.GetKey(KeyCode.A)) // Aller vers la gauche (AZERTY: Q, QWERTY: A)
        {
            dir += Vector2.left;
            _animator.SetInteger("Direction", 1);
        }
        if (Input.GetKey(KeyCode.D)) // Aller vers la droite
        {
            dir += Vector2.right;
            _animator.SetInteger("Direction", 0);
        }

        dir.Normalize();
        _animator.SetBool("IsMoving", dir.magnitude > 0);

        // Déplacement du personnage
        transform.Translate(dir * _speed * Time.deltaTime);
    }
}
