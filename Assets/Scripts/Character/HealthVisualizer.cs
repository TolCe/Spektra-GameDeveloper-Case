using UnityEngine;

public class HealthVisualizer : MonoBehaviour
{
    [SerializeField] private GameObject _armourContainer;
    [SerializeField] private GameObject _healthContainer;

    [SerializeField] private SpriteRenderer _armourSprite;
    [SerializeField] private SpriteRenderer _healthSprite;

    public void Initialize()
    {
        _armourContainer.SetActive(true);
        _healthContainer.SetActive(true);

        _armourSprite.size = Vector2.one;
        _healthSprite.size = Vector2.one;
    }

    public void ModifyArmourBar(float ratio)
    {
        _armourSprite.size = new Vector2(ratio, 1);

        if (ratio <= 0)
        {
            _armourContainer.SetActive(false);
        }
    }

    public void ModifyHealthBar(float ratio)
    {
        _healthSprite.size = new Vector2(ratio, 1);

        if (ratio <= 0)
        {
            _healthContainer.SetActive(false);
        }
    }
}
