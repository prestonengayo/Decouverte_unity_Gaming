using UnityEngine;

public class PlayerController : MonoBehaviour
{
    // Attributs s�rialis�s
    [SerializeField] private Player _player;

    // M�thode appel�e chaque frame
    private void Update()
    {
        // � impl�menter si n�cessaire
    }

    // M�thode appel�e lorsqu'un objet entre en collision avec ce GameObject (2D)
    private void OnTriggerEnter2D(Collider2D collision)
    {
        // � impl�menter si n�cessaire
    }
}
