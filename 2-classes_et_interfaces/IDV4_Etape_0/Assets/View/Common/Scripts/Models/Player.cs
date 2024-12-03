using UnityEngine;

public class Player : MonoBehaviour
{
    // Attributs sérialisés
    [SerializeField] private int _gems;
    [SerializeField] private int _orbs;
    [SerializeField] private int _symbols;
    [SerializeField] private int _level;
    [SerializeField] private string _name;
    private float _experiences;
    private float _maxExperiences;

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

    // Définit le nombre de gemmes possédées par le joueur
    private void SetGems(int pGems)
    {
        _gems = pGems;
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

    // Définit le nombre d'orbes possédés par le joueur
    private void SetOrbs(int pOrbs)
    {
        _orbs = pOrbs;
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

    // Définit le nombre de symboles possédés par le joueur
    private void SetSymbols(int pSymbols)
    {
        _symbols = pSymbols;
    }

    // Retourne le niveau actuel du joueur
    public int GetLevel()
    {
        return _level;
    }

    // Définit le niveau du joueur
    private void SetLevel(int pLevel)
    {
        _level = pLevel;
    }

    // Retourne le nom du joueur
    public string GetName()
    {
        return _name;
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

    // Définit l'expérience acquise par le joueur
    private void SetExperiences(float pExperiences)
    {
        _experiences = pExperiences;
    }

    // Retourne l'expérience requise pour atteindre le prochain niveau
    public float GetMaxExperiences()
    {
        return _maxExperiences;
    }

    // Définit l'expérience maximum à avoir pour atteindre le prochain niveau du joueur
    private void SetMaxExperiences(float pMaxExperiences)
    {
        _maxExperiences = pMaxExperiences;
    }

    // Vérifie si le joueur peut augmenter de niveau, c'est-à-dire si l'expérience requise est atteinte ou dépassée.
    private bool IsReadyToLevelUp()
    {
        return _experiences >= _maxExperiences;
    }

    // Augmente le niveau du joueur et le nombre max d'expérience à avoir pour le prochain niveau.
    // Si le joueur possède plus d'expérience que nécessaire, l'excédent s'ajoute au nouveau niveau.
    private void LevelUp()
    {
        _experiences -= _maxExperiences;
        _level++;
        _maxExperiences *= 1.2f; // Augmente la difficulté pour chaque niveau
    }

    // Retourne le script player sous format string
    public override string ToString()
    {
        return $"Name: {_name}, Level: {_level}, Gems: {_gems}, Orbs: {_orbs}, Symbols: {_symbols}, Experience: {_experiences}/{_maxExperiences}";
    }
}
