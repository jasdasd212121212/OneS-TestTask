using Zenject;

public class InputInstaller : MonoInstaller
{
    public override void InstallBindings()
    {
        Container.Bind<IMoveInputSystem>().FromInstance(new DesktopMoveInputSystem()).AsSingle().NonLazy();
    }
}