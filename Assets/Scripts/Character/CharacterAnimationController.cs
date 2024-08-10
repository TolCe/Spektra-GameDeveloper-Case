using UnityEngine;

public class CharacterAnimationController : MonoBehaviour
{
    [SerializeField] private Animator _animator;

    public void ChangeBool(string aName, bool state)
    {
        _animator.SetBool(aName, state);
    }
    public void ChangeTrigger(string aName)
    {
        _animator.SetTrigger(aName);
    }
    public void ChangeFloat(string aName, float aValue)
    {
        _animator.SetFloat(aName, aValue);
    }
}
