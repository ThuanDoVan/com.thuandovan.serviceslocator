using System;
using System.Collections.Generic;
using UnityEngine;

namespace ThuanDoVan.ServicesLocator
{
    public static class ServicesLocator
    {
        private static readonly Dictionary<Type, object> _servicesCache;
 
        static ServicesLocator()
        {
            _servicesCache = new Dictionary<Type, object> ();
        }

        public static void Register<T>(T service)
        {
            var key = typeof(T);
            if (!_servicesCache.ContainsKey(key))
            {
                _servicesCache.Add(key, service);
            }
            else  // overwrite the existing instance.
            {
                _servicesCache[key] = service;
            }
        }
 
        public static T GetService<T>()
        {
            var key = typeof(T);
            if (!_servicesCache.ContainsKey(key))
            {
                Debug.LogWarning($"GetService for {key} was failed. return default instead");
                return default;
            }
 
            return (T)_servicesCache[key];
        }
    }

}
