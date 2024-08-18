using UnityEngine;

public class WeaponSoundsView : BaseWeponView
{
    [SerializeField] private AudioSource _shotSound;

    protected override void OnShot()
    {
        _shotSound.Play();
    }
}