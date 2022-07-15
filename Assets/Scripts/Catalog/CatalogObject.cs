using System.Collections.Generic;
using UnityEngine;

namespace Quinbay.Catalog
{
    [CreateAssetMenu]
    public class CatalogObject : ScriptableObject
    {
        [SerializeField] private List<CatalogItem> catalog;

        public List<CatalogItem> Catalog => catalog;
        public Dictionary<CategoryType, List<CatalogItem>> GroupedCatalog { 
            get {
                if (groupedCatalog == null)
                {
                    groupedCatalog = new Dictionary<CategoryType, List<CatalogItem>>();
                    foreach (CatalogItem item in catalog)
                    {

                        List<CatalogItem> list = groupedCatalog.ContainsKey(item.Category)
                            ? groupedCatalog[item.Category]
                            : new List<CatalogItem>();
                        list.Add(item);
                        groupedCatalog[item.Category] = list;
                    }
                    Debug.Log(groupedCatalog);
                }
                return groupedCatalog;
            }
        }

        private Dictionary<CategoryType, List<CatalogItem>> groupedCatalog = null;
        
        
    }
}