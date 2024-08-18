using UnityEngine;

public class WeaponParticlesView : BaseWeponView
{
    [SerializeField] protected ParticleSystem _fireParticles;

    protected override void OnShot()
    {
        _fireParticles.Play();
    }
}