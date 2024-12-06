using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class Player : MonoBehaviour
{
    // Attributs sérialisés
    [SerializeField] private int _gems;
    [SerializeField] private int _orbs;
    [SerializeField] private int _symbols;
    [SerializeField] private int _level;
    [SerializeField] private string _name;
    [SerializeField] private Role _role;
    private float _experiences;
    private float _maxExperiences;
    private bool _isImmortal;

    [SerializeField] private int _health = 100; // Valeur par défaut de santé
    [SerializeField] private int _stamina = 100; // Valeur par défaut de stamina

    private bool _isGameOver = false;

    // Retourne la santé du joueur
    public int GetHealth()
    {
        return _health;
    }

    // Définit la santé du joueur
    public void SetHealth(int health)
    {
        _health = health;
    }

    // Retourne la stamina du joueur
    public int GetStamina()
    {
        return _stamina;
    }

    // Définit la stamina du joueur
    public void SetStamina(int stamina)
    {
        _stamina = stamina;
    }

    // Retourne le nombre total de gemmes possédées par le joueur
    public int GetGems()
    {
        return _gems;
    }

    // Ajoute des gemmes à celles possédées par le joueur
    public void AddGem(int pGem)
    {
        _gems += pGem;
    }

    // Retourne le nombre total d'orbes possédés par le joueur
    public int GetOrbs()
    {
        return _orbs;
    }

    // Ajoute des orbes à ceux possédés par le joueur
    public void AddOrb(int pOrb)
    {
        _orbs += pOrb;
    }

    // Retourne le nombre total de symboles possédés par le joueur
    public int GetSymbols()
    {
        return _symbols;
    }

    // Ajoute des symboles à ceux possédés par le joueur
    public void AddSymbol(int pSymbol)
    {
        _symbols += pSymbol;
    }

    // Retourne le niveau actuel du joueur
    public int GetLevel()
    {
        return _level;
    }

    // Retourne l'expérience acquise par le joueur
    public float GetExperiences()
    {
        return _experiences;
    }

    // Ajoute de l'expérience au joueur
    public void AddExperiences(float pExperience)
    {
        _experiences += pExperience;
        if (IsReadyToLevelUp())
        {
            LevelUp();
        }
    }

    // Vérifie si le joueur peut augmenter de niveau, c'est-à-dire si l'expérience requise est atteinte ou dépassée.
    private bool IsReadyToLevelUp()
    {
        return _experiences >= _maxExperiences;
    }

    // Augmente le niveau du joueur et le nombre max d'expérience à avoir pour le prochain niveau.
    private void LevelUp()
    {
        _experiences -= _maxExperiences;
        _level++;
        _maxExperiences *= 1.2f; // Augmente la difficulté pour chaque niveau
    }

    // Définit la valeur de _isImmortal à true pendant 3 secondes
    public IEnumerator LoadImmortalFrame()
    {
        _isImmortal = true;
        yield return new WaitForSeconds(3);
        _isImmortal = false;
    }

    // Inflige des dégâts au joueur, uniquement s'il n'est pas immortel
    public void Damage(int pDamage)
    {
        if (!_isImmortal && !_isGameOver)
        {
            _health -= pDamage;
            if (_health <= 0)
            {
                _health = 0; // Assurez-vous que la santé ne soit jamais inférieure à 0
                Debug.Log("Player is dead");
                StartCoroutine(GameOver());
            }
        }
    }

    // Soigne le joueur
    public void Heal(int amount)
    {
        if (!_isGameOver)
        {
            _health += amount;
            if (_health > 100)
            {
                _health = 100; // Limiter la santé à 100
            }
        }
    }

    // Méthode appelée lorsqu'un objet entre en collision avec ce GameObject (2D)
    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("Player collided with: " + collision.gameObject.name); // Log pour vérifier les collisions

        // Vérifier si l'objet en collision est un collectible
        ICollectible collectible = collision.GetComponent<ICollectible>();
        if (collectible != null)
        {
            Debug.Log("Collecting item: " + collectible.ToString());
            collectible.Collect(this); // Passer l'instance du joueur pour la collecte
        }

        // Vérifier si l'objet en collision est un trap (élément infligeant des dommages)
        TriggerDamageable(collision);
    }

    // Inflige des dégâts au joueur si l’objet passé en paramètre implémente l'interface IDamageable
    private void TriggerDamageable(Collider2D pCollider2D)
    {
        if (_isImmortal)
        {
            Debug.Log("Player is currently immortal, no damage taken.");
            return;
        }

        IDamageable damageable = pCollider2D.GetComponent<IDamageable>();
        if (damageable != null && !_isGameOver)
        {
            Debug.Log("Player taking damage from: " + damageable.ToString());
            damageable.Damage(10); // Exemple de dégâts infligés
            Damage(10);
            StartCoroutine(LoadImmortalFrame());
        }
    }

    // Soigne le joueur si l’objet passé en paramètre implémente l’interface IHealable
    private void TriggerIHealable(Collider2D pCollider2D)
    {
        IHealable healable = pCollider2D.GetComponent<IHealable>();
        if (healable != null)
        {
            Debug.Log("Healing player from: " + healable.ToString());
            Heal(20); // Exemple de soin apporté
        }
    }

    // Méthode pour gérer la fin de la partie avec une attente avant de réinitialiser
    private IEnumerator GameOver()
    {
        _isGameOver = true;

        // Appel à Die et attente avant de recharger la scène
        Die();
        yield return new WaitForSeconds(1f);

        // Charger la scène d'accueil ou une scène de fin
        SceneManager.LoadScene("HomeScene");
    }

    // Méthode Die pour gérer la logique de fin de vie du joueur
    private void Die()
    {
        Debug.Log("Player has died. Executing Die logic...");
        // Ajouter ici toute logique supplémentaire telle que désactiver des contrôles, jouer une animation, etc.
    }

    // Méthode pour réinitialiser le personnage (peut être utilisée si besoin)
    public void ResetCharacter()
    {
        Debug.Log("Resetting character stats...");
        _health = 100;
        _isImmortal = false;
        _isGameOver = false;
    }
}
