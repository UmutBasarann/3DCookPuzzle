using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace CP.Scripts.Core.UI
{
    public class SafeArea : MonoBehaviour
    {

        #region Fields

        private Rect _safeArea;
        private RectTransform _rectTransform;

        #endregion
        
        #region Awake | Start | Update

        private void Awake()
        {
            _rectTransform = GetComponent<RectTransform>();
            _safeArea = Screen.safeArea;
        }

        private void Start()
        {
            SetSize();
        }

        #endregion

        #region Set: Size

        private void SetSize()
        {
            Debug.Log($"SafeArea Size: {_safeArea.size}");
            Debug.Log($"SafeArea Width: {_safeArea.width}");
            Debug.Log($"SafeArea Height: {_safeArea.height}");
            Debug.Log($"SafeArea Position: {_safeArea.position}");
            Debug.Log($"SafeArea (XMax, YMax): ({_safeArea.xMax}, {_safeArea.yMax})");
            Debug.Log($"SafeArea (XMin, YMin): ({_safeArea.xMin}, {_safeArea.yMin})");
            Debug.Log($"SafeArea X: {_safeArea.x}");
            Debug.Log($"SafeArea Y: {_safeArea.y}");

            _rectTransform.sizeDelta = _safeArea.size;
        }

        #endregion
    }
}
