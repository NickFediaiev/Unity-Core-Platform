using System;
using FishNet.Object;
using MultiplayerModule.Interface.Components;
namespace MultiplayerModule.System.Components
{
    public class PlayerSpawnEventInvoker : NetworkBehaviour
    {
        public static event Action OnPlayerSpawn;
    
        public override void OnStartClient()
        {
            base.OnStartClient();

            if (!IsOwner)
                return;
            
            StaticPlayerSpawnEvent.InvokeOnPlayerSpawn(GetComponent<NetworkObject>());
        }
    }
}