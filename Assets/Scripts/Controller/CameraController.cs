using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MF
{
    public class CameraController : IExecute
    {
        private Transform _player, _mainCam;
        private Vector3 _offset;

        public CameraController(Transform player, Transform mainCam)
        {
            _player = player;
            _mainCam = mainCam;
            _offset = _mainCam.position - _player.position;
            _mainCam.LookAt(_player);
        }

        public void Update()
        {
            _mainCam.position = _player.position + _offset;
        }
    }
}

