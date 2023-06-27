using System;
using Player;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Global
{
    public class AstriaManager : MonoBehaviour
    {
        public static AstriaManager Instance;
        public PlayerInformation LocalPlayerInformation;
        public bool LocalPlayerMovementEnabled = true;
        private void Awake()
        {
            if (Instance is null)
            {
                Instance = this;
                LocalPlayerInformation = new PlayerInformation();
            }
            DontDestroyOnLoad(this);
        }

        public void OpenScene(string sceneName)
        {
            SceneManager.LoadScene (sceneName:sceneName);
        }

        public void ChangeUsername(string newUsername)
        {
            LocalPlayerInformation.PlayerName = newUsername;
            Debug.Log("Changing Username of Player: " + LocalPlayerInformation.PlayerName);
        }
        
        public void SetWalkable(bool isWalkable)
        {
            AstriaManager.Instance.LocalPlayerMovementEnabled = isWalkable;
        }
    }
}