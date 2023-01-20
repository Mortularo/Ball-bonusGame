using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MF
{
    public class MiniCam : MonoBehaviour
    {
        public Shader _newShader;
        private Camera miniMapCam;
        private void Awake()
        {
            miniMapCam = GetComponent<Camera>();
            _newShader = Shader.Find("Unlit/Texture");
            if(_newShader)
            {
                miniMapCam.SetReplacementShader(_newShader, "RenderTipe");

            }
        }
        private void OnDisable()
        {
            miniMapCam.ResetReplacementShader();
        }
    }
}