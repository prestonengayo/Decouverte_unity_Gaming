using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour
{
    // Attributs sérialisés
    [SerializeField] private Player _player;
    private bool _isImmortal;
    [SerializeField] private float _speed = 5.0f;
    [SerializeField] private int _health = 100;
    public CanvasGroup hitmarkerCanvasGroup;

    // Méthode appelée chaque frame
    private void Update()
    {
        // Contrôle du déplacement du joueur
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");

        Vector2 movement = new Vector2(horizontal, vertical);
        movement.Normalize();

        // Déplacement du joueur
        _player.transform.Translate(movement * _speed * Time.deltaTime);

        // Vérification de l'état du joueur
        if (_health <= 0)
        {
            Debug.Log("Player is dead");
            // Logique de fin de partie ou de respawn
        }
    }

    // Méthode appelée lorsqu'un objet entre en collision avec ce GameObject (2D)
    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("Player collided with: " + collision.gameObject.name); // Log pour vérifier les collisions
        TriggerCollectible(collision);
        TriggerDamageable(collision);
        TriggerIHealable(collision);
    }

    // Réinitialise la variable _isImmortal après 3 secondes
    private IEnumerator ResetIsImmortalFrame()
    {
        Debug.Log("Resetting immortality frame and hiding Hitmarker...");
        yield return new WaitForSeconds(3);
        _isImmortal = false;

        // Désactiver le hitmarker en rendant l'alpha 0
        if (hitmarkerCanvasGroup != null)
        {
            hitmarkerCanvasGroup.alpha = 0;
        }
    }

    // Collecte le collectible si l’objet passé en paramètre implémente l’interface ICollectible
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

    // Inflige des dégâts au player si l’objet passé en paramètre implémente l'interface IDamageable
    private void TriggerDamageable(Collider2D pCollider2D)
    {
        // Si le joueur est dans la phase d'immortalité, aucun dommage ne devrait être pris.
        if (_isImmortal)
        {
            Debug.Log("Player is currently immortal, no damage taken.");
            return;
        }

        IDamageable damageable = pCollider2D.GetComponent<IDamageable>();
        if (damageable != null)
        {
            Debug.Log("Player taking damage from: " + damageable.ToString());
            damageable.Damage(10); // Exemple de dégâts infligés
            _health -= 10;
            Debug.Log("Hitmarker " + hitmarkerCanvasGroup);

            // Activer le hitmarker et démarrer l'immortalité
            if (hitmarkerCanvasGroup.alpha == 0)
            {
                hitmarkerCanvasGroup.alpha = 1; // Rendre le hitmarker visible
                Debug.Log("Hitmarker is now visible");
            }

            _isImmortal = true;

            // Lancer la coroutine pour réinitialiser l'immortalité et désactiver le hitmarker
            StartCoroutine(ResetIsImmortalFrame());
        }
    }

    // Soigne le player si l’objet passé en paramètre implémente l’interface IHealable
    private void TriggerIHealable(Collider2D pCollider2D)
    {
        IHealable healable = pCollider2D.GetComponent<IHealable>();
        if (healable != null)
        {
            Debug.Log("Healing player from: " + healable.ToString());
            _player.Heal(20); // Mettre à jour la santé via Player
        }
    }
}
