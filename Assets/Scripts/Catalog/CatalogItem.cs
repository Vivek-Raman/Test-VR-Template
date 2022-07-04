using System;
using UnityEngine;

namespace Quinbay.Catalog
{
    [Serializable]
    public class CatalogItem
    {
        [SerializeField] private string name;
        [SerializeField] private string description;
        [SerializeField] private CategoryType category;
        [SerializeField] private GameObject prefab;
        
        public string Name => name;
        public string Description => description;
        public CategoryType Category => category;
        public GameObject Prefab => prefab;
    }
}
