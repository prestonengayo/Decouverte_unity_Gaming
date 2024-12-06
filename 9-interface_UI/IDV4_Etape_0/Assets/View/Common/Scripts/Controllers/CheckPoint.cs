using UnityEngine;

public class CheckPoint : MonoBehaviour, ICheckPoint
{
    // Attributs sérialisés
    [SerializeField] private bool _isSpawner;
    [SerializeField] private bool _active;
    [SerializeField] private RectTransform _spawnArea;

    // Propriétés pour manipuler les attributs sérialisés
    public bool Active
    {
        get => _active;
        set => _active = value;
    }

    // Méthode pour retourner le spawn area
    public RectTransform GetSpawnArea()
    {
        return _spawnArea;
    }

    // Implémentation des méthodes de l'interface ICheckPoint
    public void Save()
    {
        // Logique pour sauvegarder le joueur sur ce checkpoint
        Debug.Log("Player saved at checkpoint");
        // Exemple : Mettre à jour la position du joueur pour qu'elle corresponde à celle du checkpoint
        GameObject player = GameObject.FindGameObjectWithTag("Player");
        if (player != null)
        {
            player.transform.position = transform.position;
        }
    }

    public void ResetCheckPoint()
    {
        // Logique pour réinitialiser le joueur au premier checkpoint (spawner)
        Debug.Log("Resetting to first checkpoint");
        if (_isSpawner)
        {
            GameObject player = GameObject.FindGameObjectWithTag("Player");
            if (player != null)
            {
                player.transform.position = transform.position;
            }
        }
    }

    public void Load()
    {
        // Logique pour charger le joueur au dernier checkpoint atteint
        Debug.Log("Loading player to last checkpoint");
        GameObject player = GameObject.FindGameObjectWithTag("Player");
        if (player != null)
        {
            player.transform.position = transform.position;
        }
    }

    // Méthode Unity OnTriggerEnter2D
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Save();
        }
    }
}
