using _Main._Scripts.PlayerInputLogic;
using _Main._Scripts.PlayerLogic;
using UnityEngine;
using Zenject;

namespace _Main._Scripts.Installers
{
    public class PlayerInstaller : MonoInstaller
    {
        [SerializeField] private PlayerConfig playerConfig;
        [SerializeField] private GameObject playerPrefab;
        [SerializeField] private Transform playerSpawnPoint;


        public override void InstallBindings()
        {
            BindInput();
            BindPlayerConfig();
            BindPlayer();
        }

        private void BindPlayer()
        {
            var player = Container.InstantiatePrefab(playerPrefab, playerSpawnPoint.position, playerSpawnPoint.rotation,
                null);
            Container.Bind<GameObject>().FromInstance(player)
                .AsSingle(); // GameObject можно заменить на класс Player, но в данной реализации в этом нет необходимости
        }

        private void BindInput() => Container.BindInterfacesAndSelfTo<PlayerInput>().AsSingle();
        private void BindPlayerConfig() => Container.BindInstance(playerConfig).AsSingle();
    }
}