using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

namespace MF
{
    public struct PlayerData
    {
        //public string Name;
        public Vector3 Position;
        public Quaternion Rotation;
        public int Health;
        public bool PlayerDead;

        public PlayerData(Player _player)
        {
            //Name = _player.name;
            Position = _player.transform.position;
            Rotation = _player.transform.rotation;
            Health = _player.Health;
            PlayerDead = _player.IsDead;
        }
    }

    public class Player : Unit
    {
        public PlayerData _playerData;
        private ISaveData _saveData;
        public Transform PlayerDot;

        public override void Move(float x, float y, float z)
        {
            PlayerDot.position = new Vector3(x, y, z);
            if (_rb)
            {
                _rb.AddForce(new Vector3(_transform.position.x, PlayerDot.position.y, _transform.position.z));
            }
        }
        public override void Awake()
        {
            base.Awake();
            Health = 100;
            _saveData = new XMLData();

            _playerData = new PlayerData(this);
            _saveData.SaveData(_playerData);

            PlayerData temp = new PlayerData();
            temp = _saveData.Load();
        }
    }
}

