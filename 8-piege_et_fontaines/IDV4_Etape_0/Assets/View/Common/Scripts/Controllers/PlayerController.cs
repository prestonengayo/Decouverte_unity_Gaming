using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour
{
    // Attributs s�rialis�s
    [SerializeField] private Player _player;
    private bool _isImmortal;
    [SerializeField] private float _speed = 5.0f;
    [SerializeField] private int _health = 100;

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
        TriggerCollectible(collision);
        TriggerDamageable(collision);
        TriggerIHealable(collision);
    }

    // R�initialise la variable _isImmortal apr�s 1 seconde
    private IEnumerator ResetIsImmortalFrame()
    {
        yield return new WaitForSeconds(1);
        _isImmortal = false;
    }

    // Collecte le collectible si l�objet pass� en param�tre impl�mente l�interface ICollectible
    private void TriggerCollectible(Collider2D pCollider2D)
    {
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
        IDamageable damageable = pCollider2D.GetComponent<IDamageable>();
        if (damageable != null && !_isImmortal)
        {
            Debug.Log("Player taking damage from: " + damageable.ToString());
            damageable.Damage(10); // Exemple de d�g�ts inflig�s
            _health -= 10;
            _isImmortal = true;
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
            healable.Heal(_player.GetCharacter());
            _health += 20; // Exemple de soin apport�
        }
    }
}
