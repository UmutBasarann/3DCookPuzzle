using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace CP.Scripts.Manager.Pool
{
    public class PoolManager : MonoBehaviour
    {
        #region Awake | Start | Update

        private void Awake()
        {
            DontDestroyOnLoad(this);
        }

        #endregion
        
        #region Pool
        
        public void Pool(GameObject objectToPool, RectTransform parent, int size)
        {
            for (int i = 0; i < size; i++)
            {
                Instantiate(objectToPool, parent);
            }
        }
        
        public void Pool(GameObject objectToPool, RectTransform parent, int size, out List<GameObject> pooledObjects)
        {
            pooledObjects = new List<GameObject>();
            
            for (int i = 0; i <= size; i++)
            {
                GameObject instance = Instantiate(objectToPool, parent);
                pooledObjects.Add(instance);
            }
        }

        #endregion
    }
}

