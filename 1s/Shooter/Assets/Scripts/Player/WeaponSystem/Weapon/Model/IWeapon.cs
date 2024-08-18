using System;

public interface IWeapon
{
    void StartShooting();
    void StopShooting();

    event Action shoted;
}