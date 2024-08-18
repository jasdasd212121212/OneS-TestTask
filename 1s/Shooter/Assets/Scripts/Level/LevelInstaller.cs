using Zenject;

public class LevelInstaller : MonoInstaller
{
    public override void InstallBindings()
    {
        Container.Bind<LevelModel>().FromInstance(new LevelModel()).AsSingle().Lazy();
    }
}