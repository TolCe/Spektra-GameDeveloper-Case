using TMPro;
using UnityEngine;

public class UpgradeUIItem : MonoBehaviour
{
    [SerializeField] private TMP_Text _text;

    public void Initialize(string name)
    {
        _text.text = name;
        gameObject.SetActive(true);
    }
}
