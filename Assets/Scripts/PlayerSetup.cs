using UnityEngine;
using UnityEngine.Networking;

namespace Assets
{
    public class PlayerSetup : NetworkBehaviour
    {
        [SerializeField]
        private Behaviour[] _componentsToDisable;

        private Camera sceneCamera;

        void Start()
        {
            // Disable all comopnents if it is not the local player
            if (!isLocalPlayer)
            {
                for (int i = 0; i < _componentsToDisable.Length; i++)
                {
                    _componentsToDisable[i].enabled = false;
                }
            }
            else
            {
                // If it IS the local player, disable the main scene camera
                sceneCamera = Camera.main;
                if( sceneCamera != null)
                    sceneCamera.gameObject.SetActive(false);
            }
        }


        void OnDisable()
        {
            if (sceneCamera != null)
                sceneCamera.gameObject.SetActive(true);
        }
    }
}
