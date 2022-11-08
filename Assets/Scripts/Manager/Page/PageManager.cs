using System.Collections;
using System.Collections.Generic;
using CP.Scripts.Interface.Page;
using UnityEngine;

namespace CP.Scripts.Manager.Page
{
    public class PageManager
    {
        #region Fields

        private GameObject _activePage;
        public GameObject ActivePage => _activePage;

        #endregion

        #region DeclareActivePage

        public void DeclareActivePage(GameObject activePage)
        {
            _activePage = activePage;
        }

        #endregion

        #region GetActivePage

        public GameObject GetActivePage()
        {
            return _activePage;
        }

        #endregion
    }
}

