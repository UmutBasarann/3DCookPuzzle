using System;
using System.Collections;
using System.Collections.Generic;
using CP.Scripts.Core;
using CP.Scripts.Interface.Page;
using CP.Scripts.Manager.Page;
using UnityEngine;
using UnityEngine.UI;

namespace CP.Scripts.Page.Main
{
    public class SelectionPage : MonoBehaviour ,IPage
    {
        #region Event | Action

        public static event Action OnPlayButtonClicked;

        #endregion
        
        #region SerializeFields

        [SerializeField] private Button btnSelectionPlay = null;

        #endregion
        
        #region Fields


        #endregion

        #region Awake | Start | Update

        private void Start()
        {

        }

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

        #region Event: OnBtnPlayClicked

        private void OnBtnPlayClicked()
        {
            if (OnPlayButtonClicked != null)
            {
                OnPlayButtonClicked();
            }
        }

        #endregion

        #region AddEvents

        private void AddEvents()
        {
            btnSelectionPlay.onClick.AddListener(OnBtnPlayClicked);
        }

        #endregion

        #region RemoveEvents

        private void RemoveEvents()
        {
            btnSelectionPlay.onClick.RemoveAllListeners();
        }

        #endregion
    }
}

