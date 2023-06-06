using UnityEngine;
using UnityEngine.UI;

public class UIHelper : MonoBehaviour
{
    private Player _player;
    public Slider SliderHealth;
    public Slider SliderStrength;

    private void Start()
    {
        _player = FindObjectOfType<Player>();
        HealthUI();
    }

    private void Update()
    {
        HealthUI();
    }

    private void HealthUI()
    {
        if (SliderHealth != null)
        {
            SliderHealth.value = _player.CurrentHealth;
        }
        if (SliderStrength != null)
        {
            SliderStrength.value = _player.CurrentStrength;
        }
    }
}
