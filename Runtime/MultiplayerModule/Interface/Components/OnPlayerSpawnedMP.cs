using FishNet.Object;
using Debug = UnityEngine.Debug;
namespace MultiplayerModule.Interface.Components
{
    public class OnPlayerSpawnedMP : NetworkBehaviour
    {
        private void Awake()
        {
            StaticPlayerSpawnEvent.OnPlayerSpawn += OnStaticEventOnOnPlayerSpawn;
        }
        
        protected virtual void OnStaticEventOnOnPlayerSpawn(NetworkObject nob)
        {
            Debug.Log("Player Spawned");
        }
    }
}
