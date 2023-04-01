using System;

namespace GameData
{
    public static class GameStatus
    {
        // By default the player should be moving
        public static bool isMoving = true;

        // By default, the textBox should not be animating
        public static bool isAnimating = false;

        // By default the player can press the keyboard
        public static bool enableKeyPress = true;


        // The Last song that was play 
        public static string lastSong = "";

        public static bool IsMoving
        {
            get { return isMoving; }
            set { isMoving = value; }
        }

        public static bool IsAnimating
        {
            get { return isAnimating; }
            set { isAnimating = value; }
        }
    }

    [Serializable]
    public class GameDataInfo
    {
        public string previousLocation;
        public string nextLocation;
        public float x_cord;

        public float y_cord;
    }


}

