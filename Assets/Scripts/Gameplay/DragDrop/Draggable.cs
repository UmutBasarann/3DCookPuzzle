using System;
using System.Collections;
using System.Collections.Generic;
using CP.Scripts.Core;
using UnityEngine;
using UnityEngine.EventSystems;

namespace CP.Scripts.Gameplay
{
    public class Draggable : MonoBehaviour, IPointerDownHandler, IDragHandler, IBeginDragHandler, IEndDragHandler
    {
        #region SerializeFields

        

        #endregion
        
        #region Fields

        private CanvasGroup _canvasGroup;
        private RectTransform _rectTransform;

        #endregion

        #region Awake | Start | Update

        private void Awake()
        {
            _rectTransform = GetComponent<RectTransform>();
            _canvasGroup = GetComponent<CanvasGroup>();
        }

        #endregion

        #region Event: OnPointerDown

        public void OnPointerDown(PointerEventData eventData)
        {
            _canvasGroup.alpha = .65f;
        }

        #endregion

        #region Event: OnDrag

        public void OnDrag(PointerEventData eventData)
        {
            _canvasGroup.blocksRaycasts = false;
            _rectTransform.anchoredPosition += eventData.delta / Game.Instance.GetScaleFactor();
        }

        #endregion

        #region Event: OnBeginDrag

        public void OnBeginDrag(PointerEventData eventData)
        {
            Debug.Log("OnBeginDrag");
        }

        #endregion

        #region Event: OnEndDrag

        public void OnEndDrag(PointerEventData eventData)
        {
            _canvasGroup.blocksRaycasts = true;
            _canvasGroup.alpha = 1f;
        }

        #endregion
    }    
}

