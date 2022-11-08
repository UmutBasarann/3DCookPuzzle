using System;
using System.Collections;
using System.Collections.Generic;
using CP.Scripts.Interface.Page;
using UnityEngine;
using UnityEngine.UI;

namespace CP.Scripts.Page
{
    public class GameLostPage : MonoBehaviour, IPage
    {
        #region Event | Action

        public static event Action OnGameLostContinueButtonClicked;

        #endregion
        
        #region SerializeFields

        [SerializeField] private Button btnContinue = null;

        #endregion

        #region Awake | Start | Update



        #endregion

        #region OnEnable

        private void OnEnable()
        {
            AddEvents();
        }

        #endregion

        #region OnDisable

        private void OnDisable()
        {
            RemoveEvents();
        }

        #endregion
        
        #region CreatePage

        public GameObject CreatePage(GameObject page, Transform parent)
        {
            if (parent is null)
            {
                Debug.LogError("Please use 'Simulator' to get the best experience.");
            }
            
            GameObject instance = Instantiate(page, parent);
            instance.transform.SetAsLastSibling();
            return instance;
        }

        #endregion

        #region Event: OnBtnContinueClicked

        private void OnBtnContinueClicked()
        {
            if (OnGameLostContinueButtonClicked != null)
            {
                OnGameLostContinueButtonClicked();
            }
        }

        #endregion

        #region AddEvents

        private void AddEvents()
        {
            btnContinue.onClick.AddListener(OnBtnContinueClicked);
        }

        #endregion

        #region RemoveEvents

        private void RemoveEvents()
        {
            btnContinue.onClick.RemoveAllListeners();
        }

        #endregion
    }
}
