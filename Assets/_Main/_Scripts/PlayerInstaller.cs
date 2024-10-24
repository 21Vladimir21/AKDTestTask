using _Main._Scripts.PlayerInputLogic;
using Zenject;

namespace _Main._Scripts
{
    public class PlayerInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            BindInput();
        }

        private void BindInput()
        {
            Container.BindInterfacesAndSelfTo<PlayerInput>().AsSingle();
        }
    }
}