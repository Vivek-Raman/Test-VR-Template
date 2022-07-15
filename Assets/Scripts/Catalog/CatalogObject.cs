using System.Collections.Generic;
using UnityEngine;

namespace Quinbay.Catalog
{
    [CreateAssetMenu]
    public class CatalogObject : ScriptableObject
    {
        [SerializeField] private List<CatalogItem> catalog;

        public List<CatalogItem> Catalog => catalog;
        public Dictionary<CategoryType, List<CatalogItem>> GroupedCatalog => groupedCatalog;

        private Dictionary<CategoryType, List<CatalogItem>> groupedCatalog =
            new Dictionary<CategoryType, List<CatalogItem>>();

        private void Awake()
        {
            foreach (CatalogItem item in catalog)
            {
                List<CatalogItem> list = groupedCatalog[item.Category] ?? new List<CatalogItem>();
                list.Add(item);
                groupedCatalog[item.Category] = list;
            }
        }
    }
}