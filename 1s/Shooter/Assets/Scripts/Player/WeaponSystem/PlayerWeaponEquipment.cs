using System.Collections.Generic;
using UnityEngine;

public class PlayerWeaponEquipment : MonoBehaviour
{
    [SerializeField] private GameObject[] _weaponGameObjects;

    private IWeapon[] _weapons;

    public IWeapon CurrentWeapon { get; private set; }

    private void OnValidate()
    {
        try
        {
            if (_weaponGameObjects != null && _weaponGameObjects.Length != 0)
            {
                List<GameObject> valid = new List<GameObject>();

                foreach (GameObject weapon in _weaponGameObjects)
                {
                    if (weapon.GetComponent<IWeapon>() == null)
                    {
                        Debug.LogError($"GameObject: {weapon.name} are not contains any script realises interface: {nameof(IWeapon)}");
                    }
                    else
                    {
                        valid.Add(weapon);
                    }
                }

                _weaponGameObjects = valid.ToArray();
            }
        }
        catch { }
    }

    private void Awake()
    {
        _weapons = new IWeapon[_weaponGameObjects.Length];

        for (int i = 0; i < _weapons.Length; i++)
        {
            _weapons[i] = _weaponGameObjects[i].GetComponent<IWeapon>();
        }

        SwitchWeapon(0);
    }

    public void SwitchWeapon(int index)
    {
        if (index < 0 || index > (_weapons.Length - 1))
        {
            Debug.LogError($"Critical error -> can`t switch to weapon by index {index}; Index out of bounds; BOUNDS: (0, {_weapons.Length - 1})");
            return;
        }

        DisbaleAllWeapons();

        CurrentWeapon = _weapons[index];
        _weaponGameObjects[index].SetActive(true);
    }

    private void DisbaleAllWeapons()
    {
        foreach (GameObject weapon in _weaponGameObjects)
        {
            weapon.SetActive(false);
        }
    }
}