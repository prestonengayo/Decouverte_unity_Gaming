using UnityEngine;

public class Fountain : MonoBehaviour, IHealable
{
    [SerializeField] private eHealable _healableType;

    public void Heal(Character pCharacter)
    {
        if (_healableType == eHealable.Life)
        {
            Debug.Log("Healing player's life");
            // Logique de r�g�n�ration de la vie du personnage
            int healingAmount = 20; // Exemple de quantit� de vie restaur�e
            pCharacter.Heal(healingAmount);
        }
        else if (_healableType == eHealable.Stamina)
        {
            Debug.Log("Healing player's stamina");
            // Logique de r�g�n�ration de la stamina du personnage
            float staminaAmount = 15.0f; // Exemple de quantit� de stamina restaur�e
            AdvancedCharacter advancedCharacter = pCharacter as AdvancedCharacter;
            if (advancedCharacter != null)
            {
                advancedCharacter.SetStamina(advancedCharacter.GetStamina() + staminaAmount);
            }
        }
    }
}
