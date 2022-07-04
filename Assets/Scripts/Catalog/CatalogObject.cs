using System.Collections.Generic;
using UnityEngine;

namespace Quinbay.Catalog
{
    [CreateAssetMenu]
    public class CatalogObject : ScriptableObject
    {
        [SerializeField] private List<CatalogItem> catalog;

        public List<CatalogItem> Catalog => catalog;
    }
}