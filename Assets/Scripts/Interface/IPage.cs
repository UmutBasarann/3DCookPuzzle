using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace CP.Scripts.Interface.Page
{
    public interface IPage
    {
        #region CreatePage

        public GameObject CreatePage(GameObject page, Transform parent);

        #endregion
    }
}

