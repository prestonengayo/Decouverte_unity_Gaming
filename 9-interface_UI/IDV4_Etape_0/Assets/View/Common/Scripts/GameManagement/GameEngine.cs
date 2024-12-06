using UnityEngine;
using UnityEngine.UI;

public class GameEngine : MonoBehaviour
{
    [SerializeField] private Text gemsText;
    [SerializeField] private Text orbsText;
    [SerializeField] private Text symbolsText;
    [SerializeField] private Text healthText;
    [SerializeField] private Text staminaText;

    private Player player;

    private void Start()
    {
        player = FindObjectOfType<Player>();
    }

    private void Update()
    {
        gemsText.text = player.GetGems().ToString();
        orbsText.text = player.GetOrbs().ToString();
        symbolsText.text = player.GetSymbols().ToString();
        healthText.text = player.GetHealth().ToString();
        staminaText.text = player.GetStamina().ToString();
    }
}
