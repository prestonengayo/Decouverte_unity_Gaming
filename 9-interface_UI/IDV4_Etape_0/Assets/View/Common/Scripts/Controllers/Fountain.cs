using UnityEngine;

public class Fountain : MonoBehaviour, IHealable
{
    [SerializeField] private eHealable _healableType;

    public void Heal(Character pCharacter)
    {
        if (_healableType == eHealable.Life)
        {
            Debug.Log("Healing player's life");
            // Logique de régénération de la vie du personnage
            int healingAmount = 20; // Exemple de quantité de vie restaurée
            pCharacter.Heal(healingAmount);
        }
        else if (_healableType == eHealable.Stamina)
        {
            Debug.Log("Healing player's stamina");
            // Logique de régénération de la stamina du personnage
            float staminaAmount = 15.0f; // Exemple de quantité de stamina restaurée
            AdvancedCharacter advancedCharacter = pCharacter as AdvancedCharacter;
            if (advancedCharacter != null)
            {
                advancedCharacter.SetStamina(advancedCharacter.GetStamina() + staminaAmount);
            }
        }
    }
}
