using UnityEngine;
using UnityEngine.SceneManagement;

[CreateAssetMenu(fileName = "New Character", menuName = "ScriptableObjects/Character")]
public class Character : ScriptableObject
{
    [SerializeField] private int _life;
    [SerializeField] private int _maxLife;
    private bool _isInDanger;

    public bool IsInDanger() => _isInDanger;

    public int GetMaxLife() => _maxLife;

    public int GetLife() => _life;

    public void SetIsInDanger(bool pAction) => _isInDanger = pAction;

    protected void SetLife(int pLife) => _life = pLife;

    public void SetMaxLife(int pMaxLife) => _maxLife = pMaxLife;

    public override string ToString() => $"Life: {_life}/{_maxLife}, In Danger: {_isInDanger}";

    public void Die() => SceneManager.LoadScene("Home");

    public void Damage(int pDamage) => _life -= pDamage;

    public bool IsAlive() => _life > 0;

    public void Heal(int pHeal) => _life += pHeal;

    public void ResetCharacter()
    {
        _life = _maxLife;
        _isInDanger = false;
    }

    public void OnEnable() => ResetCharacter();
}
