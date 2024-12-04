using System.Collections;

public interface IAdvancedCharacter : ICharacter
{
    IEnumerator RegenLife();
    IEnumerator RegenStamina();
}
