using UnityEngine;
using UnityEngine.EventSystems;

namespace CP.Scripts.Gameplay.DragDrop
{
    public class Droppable : MonoBehaviour, IDropHandler
    {
        #region Fields

        private RectTransform _draggableRectTransform;
        private RectTransform _droppableRectTransform;

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

            _draggableRectTransform = eventData.pointerDrag.GetComponent<RectTransform>();
            _draggableRectTransform.anchoredPosition = _droppableRectTransform.anchoredPosition;
        }

        #endregion
    }
}
