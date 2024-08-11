using UnityEngine;

public class CharacterAnimationController : MonoBehaviour
{
    [SerializeField] private Animator _animator;

    public void ModifyFloat(string aName, float aValue)
    {
        _animator.SetFloat(aName, aValue);
    }
}
