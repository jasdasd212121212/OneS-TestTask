using Zenject;

public class PauseInstaller : MonoInstaller
{
    public override void InstallBindings()
    {
        Container.Bind<PauseModel>().FromInstance(new PauseModel()).AsSingle().Lazy();       
    }
}