using UnityEngine;

public class Player : MonoBehaviour
{
    // Attributs s�rialis�s
    [SerializeField] private int _gems;
    [SerializeField] private int _orbs;
    [SerializeField] private int _symbols;
    [SerializeField] private int _level;
    [SerializeField] private string _name;
    private float _experiences;
    private float _maxExperiences;

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

    // D�finit le nombre de gemmes poss�d�es par le joueur
    private void SetGems(int pGems)
    {
        _gems = pGems;
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

    // D�finit le nombre d'orbes poss�d�s par le joueur
    private void SetOrbs(int pOrbs)
    {
        _orbs = pOrbs;
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

    // D�finit le nombre de symboles poss�d�s par le joueur
    private void SetSymbols(int pSymbols)
    {
        _symbols = pSymbols;
    }

    // Retourne le niveau actuel du joueur
    public int GetLevel()
    {
        return _level;
    }

    // D�finit le niveau du joueur
    private void SetLevel(int pLevel)
    {
        _level = pLevel;
    }

    // Retourne le nom du joueur
    public string GetName()
    {
        return _name;
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

    // D�finit l'exp�rience acquise par le joueur
    private void SetExperiences(float pExperiences)
    {
        _experiences = pExperiences;
    }

    // Retourne l'exp�rience requise pour atteindre le prochain niveau
    public float GetMaxExperiences()
    {
        return _maxExperiences;
    }

    // D�finit l'exp�rience maximum � avoir pour atteindre le prochain niveau du joueur
    private void SetMaxExperiences(float pMaxExperiences)
    {
        _maxExperiences = pMaxExperiences;
    }

    // V�rifie si le joueur peut augmenter de niveau, c'est-�-dire si l'exp�rience requise est atteinte ou d�pass�e.
    private bool IsReadyToLevelUp()
    {
        return _experiences >= _maxExperiences;
    }

    // Augmente le niveau du joueur et le nombre max d'exp�rience � avoir pour le prochain niveau.
    // Si le joueur poss�de plus d'exp�rience que n�cessaire, l'exc�dent s'ajoute au nouveau niveau.
    private void LevelUp()
    {
        _experiences -= _maxExperiences;
        _level++;
        _maxExperiences *= 1.2f; // Augmente la difficult� pour chaque niveau
    }

    // Retourne le script player sous format string
    public override string ToString()
    {
        return $"Name: {_name}, Level: {_level}, Gems: {_gems}, Orbs: {_orbs}, Symbols: {_symbols}, Experience: {_experiences}/{_maxExperiences}";
    }
}
