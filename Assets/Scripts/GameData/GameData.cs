using System;
using System.Collections.Generic;
using UnityEngine;

namespace GameData
{

    [CreateAssetMenu(fileName = "GameData", menuName = "Game Data", order = 1)]
    [Serializable]
    public class GameData : ScriptableObject
    {
        // A list of all of our gameDataInfo , the cordianates to go to if the game autosave
        public List<GameDataInfo> gameDataInfo;

        // A list of all of our character potrait
        public List<GameDataPotrait> gameDataPotraits;

        // A list of all our illustrations for the game
        public List<GameObject> gameDataIllustrations;

        // A list of all our songs for the game 
        public List<AudioClip> gameSongs;

        private static GameData _instance;

        public static GameData Instance => GetInstance();

        private static GameData GetInstance()
        {
            if (_instance != null)
            {
                return _instance;
            }
            return _instance = Resources.Load<GameData>("Data/GameData");
        }


    }
}
