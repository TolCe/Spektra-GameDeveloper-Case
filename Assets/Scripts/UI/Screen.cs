using UnityEngine;

public class Screen : MonoBehaviour
{
    [SerializeField] private GameObject _screen;

    public void Show()
    {
        _screen.SetActive(true);
    }

    public void Hide()
    {
        _screen.SetActive(false);
    }
}
