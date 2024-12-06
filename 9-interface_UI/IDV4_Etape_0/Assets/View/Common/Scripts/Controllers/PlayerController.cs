using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour
{
    // Attributs s�rialis�s
    [SerializeField] private Player _player;
    private bool _isImmortal;
    [SerializeField] private float _speed = 5.0f;
    [SerializeField] private int _health = 100;
    public CanvasGroup hitmarkerCanvasGroup;

    // M�thode appel�e chaque frame
    private void Update()
    {
        // Contr�le du d�placement du joueur
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");

        Vector2 movement = new Vector2(horizontal, vertical);
        movement.Normalize();

        // D�placement du joueur
        _player.transform.Translate(movement * _speed * Time.deltaTime);

        // V�rification de l'�tat du joueur
        if (_health <= 0)
        {
            Debug.Log("Player is dead");
            // Logique de fin de partie ou de respawn
        }
    }

    // M�thode appel�e lorsqu'un objet entre en collision avec ce GameObject (2D)
    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("Player collided with: " + collision.gameObject.name); // Log pour v�rifier les collisions
        TriggerCollectible(collision);
        TriggerDamageable(collision);
        TriggerIHealable(collision);
    }

    // R�initialise la variable _isImmortal apr�s 3 secondes
    private IEnumerator ResetIsImmortalFrame()
    {
        Debug.Log("Resetting immortality frame and hiding Hitmarker...");
        yield return new WaitForSeconds(3);
        _isImmortal = false;

        // D�sactiver le hitmarker en rendant l'alpha 0
        if (hitmarkerCanvasGroup != null)
        {
            hitmarkerCanvasGroup.alpha = 0;
        }
    }

    // Collecte le collectible si l�objet pass� en param�tre impl�mente l�interface ICollectible
    private void TriggerCollectible(Collider2D pCollider2D)
    {
        Debug.Log("Trigger on something");
        ICollectible collectible = pCollider2D.GetComponent<ICollectible>();
        if (collectible != null)
        {
            Debug.Log("Collecting item: " + collectible.ToString());
            collectible.Collect(_player);
        }
    }

    // Inflige des d�g�ts au player si l�objet pass� en param�tre impl�mente l'interface IDamageable
    private void TriggerDamageable(Collider2D pCollider2D)
    {
        // Si le joueur est dans la phase d'immortalit�, aucun dommage ne devrait �tre pris.
        if (_isImmortal)
        {
            Debug.Log("Player is currently immortal, no damage taken.");
            return;
        }

        IDamageable damageable = pCollider2D.GetComponent<IDamageable>();
        if (damageable != null)
        {
            Debug.Log("Player taking damage from: " + damageable.ToString());
            damageable.Damage(10); // Exemple de d�g�ts inflig�s
            _health -= 10;
            Debug.Log("Hitmarker " + hitmarkerCanvasGroup);

            // Activer le hitmarker et d�marrer l'immortalit�
            if (hitmarkerCanvasGroup.alpha == 0)
            {
                hitmarkerCanvasGroup.alpha = 1; // Rendre le hitmarker visible
                Debug.Log("Hitmarker is now visible");
            }

            _isImmortal = true;

            // Lancer la coroutine pour r�initialiser l'immortalit� et d�sactiver le hitmarker
            StartCoroutine(ResetIsImmortalFrame());
        }
    }

    // Soigne le player si l�objet pass� en param�tre impl�mente l�interface IHealable
    private void TriggerIHealable(Collider2D pCollider2D)
    {
        IHealable healable = pCollider2D.GetComponent<IHealable>();
        if (healable != null)
        {
            Debug.Log("Healing player from: " + healable.ToString());
            _player.Heal(20); // Mettre � jour la sant� via Player
        }
    }
}
