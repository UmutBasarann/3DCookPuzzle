using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace CP.Scripts.Gameplay.DragDrop
{
    public class Droppable : MonoBehaviour, IDropHandler
    {
        #region Event | Action

        public static event Action<GameObject> OnIngredientDropped;

        #endregion
        
        #region Fields

        private RectTransform _draggableRectTransform;
        private RectTransform _droppableRectTransform;

        private bool _isZoneTaken = false;
        
        #endregion

        #region Awake | Start | Update

        private void Awake()
        {
            _droppableRectTransform = GetComponent<RectTransform>();
        }

        #endregion

        #region Event: OnDrop

        public void OnDrop(PointerEventData eventData)
        {
            if (eventData.pointerDrag is null)
            {
                Debug.LogError("Draggable item is null.");
                return;
            }

            if (_isZoneTaken)
            {
                Debug.LogError("This seat taken.");
                return;
            }
            
            _draggableRectTransform = eventData.pointerDrag.GetComponent<RectTransform>();
            _draggableRectTransform.transform.position = _droppableRectTransform.transform.position;

            GameObject selectedIngredient = eventData.pointerDrag;
            Draggable draggedIngredient = selectedIngredient.GetComponent<Draggable>();
            draggedIngredient.SetDraggableState(false);


            if (!draggedIngredient.IsDraggable)
            {
                _isZoneTaken = true;
            }

            if (OnIngredientDropped != null)
            {
                OnIngredientDropped(selectedIngredient);
            }
        }

        #endregion
    }
}
