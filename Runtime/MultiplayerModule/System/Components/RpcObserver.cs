using System;
using FishNet.Connection;
using FishNet.Object;
using UnityEngine;
namespace MultiplayerModule.System.Components
{
    public class RpcObserver : NetworkBehaviour
    {
        public event Action<NetworkObject> OnPlayerSpawned;

        public void NotifyOnPlayerSpawned(NetworkObject obj)
        {
            if (IsServer)
                PlayerSpawnerOnSpawned(obj);
        }

        /// <summary>
        /// Received when the server has spawned the character.
        /// </summary>
        /// <param name="character"></param>
        [TargetRpc]
        public void TargetCharacterSpawned(NetworkConnection conn, NetworkObject character)
        {
            GameObject playerObj = (character == null) ? null : playerObj = character.gameObject;
            //OnCharacterUpdated?.Invoke(playerObj);

            //If player was spawned.
            if (playerObj != null)
                OnPlayerSpawned?.Invoke(character);
        }

        [ObserversRpc] //[TargetRpc]
        private void PlayerSpawnerOnSpawned(NetworkObject obj)
        {
            if (!obj.Owner.IsLocalClient) 
                return;
            
            OnPlayerSpawned?.Invoke(obj);
        }
    }
}
