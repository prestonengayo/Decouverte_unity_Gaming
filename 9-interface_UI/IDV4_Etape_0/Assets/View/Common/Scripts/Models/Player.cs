using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class Player : MonoBehaviour
{
    // Attributs s�rialis�s
    [SerializeField] private int _gems;
    [SerializeField] private int _orbs;
    [SerializeField] private int _symbols;
    [SerializeField] private int _level;
    [SerializeField] private string _name;
    [SerializeField] private Role _role;
    private float _experiences;
    private float _maxExperiences;
    private bool _isImmortal;

    [SerializeField] private int _health = 100; // Valeur par d�faut de sant�
    [SerializeField] private int _stamina = 100; // Valeur par d�faut de stamina

    private bool _isGameOver = false;

    // Retourne la sant� du joueur
    public int GetHealth()
    {
        return _health;
    }

    // D�finit la sant� du joueur
    public void SetHealth(int health)
    {
        _health = health;
    }

    // Retourne la stamina du joueur
    public int GetStamina()
    {
        return _stamina;
    }

    // D�finit la stamina du joueur
    public void SetStamina(int stamina)
    {
        _stamina = stamina;
    }

    // Retourne le nombre total de gemmes poss�d�es par le joueur
    public int GetGems()
    {
        return _gems;
    }

    // Ajoute des gemmes � celles poss�d�es par le joueur
    public void AddGem(int pGem)
    {
        _gems += pGem;
    }

    // Retourne le nombre total d'orbes poss�d�s par le joueur
    public int GetOrbs()
    {
        return _orbs;
    }

    // Ajoute des orbes � ceux poss�d�s par le joueur
    public void AddOrb(int pOrb)
    {
        _orbs += pOrb;
    }

    // Retourne le nombre total de symboles poss�d�s par le joueur
    public int GetSymbols()
    {
        return _symbols;
    }

    // Ajoute des symboles � ceux poss�d�s par le joueur
    public void AddSymbol(int pSymbol)
    {
        _symbols += pSymbol;
    }

    // Retourne le niveau actuel du joueur
    public int GetLevel()
    {
        return _level;
    }

    // Retourne l'exp�rience acquise par le joueur
    public float GetExperiences()
    {
        return _experiences;
    }

    // Ajoute de l'exp�rience au joueur
    public void AddExperiences(float pExperience)
    {
        _experiences += pExperience;
        if (IsReadyToLevelUp())
        {
            LevelUp();
        }
    }

    // V�rifie si le joueur peut augmenter de niveau, c'est-�-dire si l'exp�rience requise est atteinte ou d�pass�e.
    private bool IsReadyToLevelUp()
    {
        return _experiences >= _maxExperiences;
    }

    // Augmente le niveau du joueur et le nombre max d'exp�rience � avoir pour le prochain niveau.
    private void LevelUp()
    {
        _experiences -= _maxExperiences;
        _level++;
        _maxExperiences *= 1.2f; // Augmente la difficult� pour chaque niveau
    }

    // D�finit la valeur de _isImmortal � true pendant 3 secondes
    public IEnumerator LoadImmortalFrame()
    {
        _isImmortal = true;
        yield return new WaitForSeconds(3);
        _isImmortal = false;
    }

    // Inflige des d�g�ts au joueur, uniquement s'il n'est pas immortel
    public void Damage(int pDamage)
    {
        if (!_isImmortal && !_isGameOver)
        {
            _health -= pDamage;
            if (_health <= 0)
            {
                _health = 0; // Assurez-vous que la sant� ne soit jamais inf�rieure � 0
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
                _health = 100; // Limiter la sant� � 100
            }
        }
    }

    // M�thode appel�e lorsqu'un objet entre en collision avec ce GameObject (2D)
    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("Player collided with: " + collision.gameObject.name); // Log pour v�rifier les collisions

        // V�rifier si l'objet en collision est un collectible
        ICollectible collectible = collision.GetComponent<ICollectible>();
        if (collectible != null)
        {
            Debug.Log("Collecting item: " + collectible.ToString());
            collectible.Collect(this); // Passer l'instance du joueur pour la collecte
        }

        // V�rifier si l'objet en collision est un trap (�l�ment infligeant des dommages)
        TriggerDamageable(collision);
    }

    // Inflige des d�g�ts au joueur si l�objet pass� en param�tre impl�mente l'interface IDamageable
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
            damageable.Damage(10); // Exemple de d�g�ts inflig�s
            Damage(10);
            StartCoroutine(LoadImmortalFrame());
        }
    }

    // Soigne le joueur si l�objet pass� en param�tre impl�mente l�interface IHealable
    private void TriggerIHealable(Collider2D pCollider2D)
    {
        IHealable healable = pCollider2D.GetComponent<IHealable>();
        if (healable != null)
        {
            Debug.Log("Healing player from: " + healable.ToString());
            Heal(20); // Exemple de soin apport�
        }
    }

    // M�thode pour g�rer la fin de la partie avec une attente avant de r�initialiser
    private IEnumerator GameOver()
    {
        _isGameOver = true;

        // Appel � Die et attente avant de recharger la sc�ne
        Die();
        yield return new WaitForSeconds(1f);

        // Charger la sc�ne d'accueil ou une sc�ne de fin
        SceneManager.LoadScene("HomeScene");
    }

    // M�thode Die pour g�rer la logique de fin de vie du joueur
    private void Die()
    {
        Debug.Log("Player has died. Executing Die logic...");
        // Ajouter ici toute logique suppl�mentaire telle que d�sactiver des contr�les, jouer une animation, etc.
    }

    // M�thode pour r�initialiser le personnage (peut �tre utilis�e si besoin)
    public void ResetCharacter()
    {
        Debug.Log("Resetting character stats...");
        _health = 100;
        _isImmortal = false;
        _isGameOver = false;
    }
}
