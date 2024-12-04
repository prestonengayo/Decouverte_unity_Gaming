using System.Collections;
using UnityEngine;

[CreateAssetMenu(fileName = "New Advanced Character", menuName = "ScriptableObjects/AdvancedCharacter")]
public class AdvancedCharacter : Character
{
    [SerializeField] private float _stamina;
    [SerializeField] private float _maxStamina;
    [SerializeField] private int _regenLife;
    [SerializeField] private int _regenStamina;
    [SerializeField] private float _timeBeforeRegenLife;
    [SerializeField] private float _timeBeforeRegenStamina;

    public int GetRegenLife() => _regenLife;
    public float GetStamina() => _stamina;
    public float GetMaxStamina() => _maxStamina;
    public int GetRegenStamina() => _regenStamina;
    public float GetTimeBeforeRegenLife() => _timeBeforeRegenLife;
    public float GetTimeBeforeRegenStamina() => _timeBeforeRegenStamina;

    public void SetStamina(float pStamina) => _stamina = pStamina;
    public void SetMaxStamina(float pMaxStamina) => _maxStamina = pMaxStamina;

    public IEnumerator RegenLife()
    {
        while (!IsInDanger() && GetLife() < GetMaxLife())
        {
            SetLife(GetLife() + GetRegenLife());
            yield return new WaitForSeconds(_timeBeforeRegenLife);
        }
    }

    public IEnumerator RegenStamina()
    {
        while (!IsInDanger() && _stamina < _maxStamina)
        {
            _stamina += _regenStamina;
            yield return new WaitForSeconds(_timeBeforeRegenStamina);
        }
    }

    public new void ResetCharacter()
    {
        base.ResetCharacter();
        _stamina = _maxStamina;
    }

    public new void OnEnable() => ResetCharacter();
}
