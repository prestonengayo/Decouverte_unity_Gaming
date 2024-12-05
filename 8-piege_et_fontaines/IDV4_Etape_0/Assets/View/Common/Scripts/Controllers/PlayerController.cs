using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour
{
    // Attributs sérialisés
    [SerializeField] private Player _player;
    private bool _isImmortal;
    [SerializeField] private float _speed = 5.0f;
    [SerializeField] private int _health = 100;

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
        TriggerCollectible(collision);
        TriggerDamageable(collision);
        TriggerIHealable(collision);
    }

    // Réinitialise la variable _isImmortal après 1 seconde
    private IEnumerator ResetIsImmortalFrame()
    {
        yield return new WaitForSeconds(1);
        _isImmortal = false;
    }

    // Collecte le collectible si l’objet passé en paramètre implémente l’interface ICollectible
    private void TriggerCollectible(Collider2D pCollider2D)
    {
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
        IDamageable damageable = pCollider2D.GetComponent<IDamageable>();
        if (damageable != null && !_isImmortal)
        {
            Debug.Log("Player taking damage from: " + damageable.ToString());
            damageable.Damage(10); // Exemple de dégâts infligés
            _health -= 10;
            _isImmortal = true;
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
            healable.Heal(_player.GetCharacter());
            _health += 20; // Exemple de soin apporté
        }
    }
}
