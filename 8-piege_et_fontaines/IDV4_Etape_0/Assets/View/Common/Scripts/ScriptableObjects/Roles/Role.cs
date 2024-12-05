using UnityEngine;

[CreateAssetMenu(fileName = "New Role", menuName = "ScriptableObjects/Role")]
public class Role : ScriptableObject
{
    [SerializeField] private int _attack;
    [SerializeField] private int _defense;

    public int Attack { get => _attack; set => _attack = value; }
    public int Defense { get => _defense; set => _defense = value; }

    public override string ToString()
    {
        return $"Role: Attack = {Attack}, Defense = {Defense}";
    }
}
