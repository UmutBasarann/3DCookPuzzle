using System.Collections;
using System.Collections.Generic;
using CP.Scripts.Interface.Page;
using CP.Scripts.Manager.Page;
using UnityEngine;
using UnityEngine.UI;

namespace CP.Scripts.Page.Settings
{
    public class SettingsPage : MonoBehaviour, IPage
    {
        #region SerializeFields

        [SerializeField] private Toggle soundToggle = null;
        [SerializeField] private Toggle hapticToggle = null;

        #endregion
        
        #region CreatePage

        public GameObject CreatePage(GameObject page, Transform parent)
        {
            GameObject instance = Instantiate(page, parent);
            instance.transform.SetAsLastSibling();
            return instance;
        }

        #endregion
    }
}

