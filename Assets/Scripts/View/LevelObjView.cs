using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MF
{
    public class LevelObjView : MonoBehaviour
    {
        [SerializeField] private Transform _transform;
        [SerializeField] private Collider _col;
        [SerializeField] private Renderer _rend;

        public Transform Transform { get => _transform; set => _transform = value; }
        public Collider Col { get => _col; set => _col = value; }
        public Renderer Rend { get => _rend; set => _rend = value; }

        /*void Awake()
        {
            if (!TryGetComponent<Transform>(out _transform))
            {
                Debug.Log("NO Transform component!");
            }
            if (!TryGetComponent<Renderer>(out _rend))
            {
                Debug.Log("NO Renderer component!");
            }
            if (!TryGetComponent<Collider>(out _col))
            {
                Debug.Log("NO Collider component!");
            }
        }*/
    }
}

