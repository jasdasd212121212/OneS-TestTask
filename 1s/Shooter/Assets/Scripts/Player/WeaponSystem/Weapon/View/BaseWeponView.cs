using UnityEngine;

public abstract class BaseWeponView : MonoBehaviour
{
    private IWeapon _weapon;

    private void OnValidate()
    {
        if (GetComponent<IWeapon>() == null)
        {
            Debug.LogError($"GameObject: {gameObject.name} are not contains any script realises interface: {nameof(IWeapon)}");
        }
    }

    private void Awake()
    {
        _weapon = GetComponent<IWeapon>();
        _weapon.shoted += OnShot;
    }

    private void OnDestroy()
    {
        _weapon.shoted -= OnShot;
    }

    protected abstract void OnShot();
}