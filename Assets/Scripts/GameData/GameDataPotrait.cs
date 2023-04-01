using UnityEngine;
using System;
using System.Collections.Generic;

namespace GameData
{
    // This is not good practices , I can't seperate them in different file for some reason it throw errors
    public enum Character
    {
        super = 0,
        armstrong = 1,

        lexi = 2,
        goro = 3,
        stef = 4,
        ayaya = 5,
        nam = 6,
        owfrog = 7,
        porohappy = 8
    }

    [Serializable]
    public class GameDataPotrait
    {
        public Character character;
        public List<Sprite> character_sprites;

        public float sprite_x;

        public float sprite_y;

    }



}

