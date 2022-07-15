using System.Collections.Generic;
using Quinbay.Catalog;
using Quinbay.Selection;
using UnityEngine;
using UnityEngine.Events;

namespace Quinbay.DebugUI
{
    public class ItemSelectionUI : ItemSelector
    {
        public override CatalogItem SelectedItem { get; protected set; }
        public override UnityAction<CatalogItem> OnSelectionChanged { get; set; }

        [SerializeField] private CatalogObject catalogObject = null;

        private bool isUIVisible = false;

        private void Start()
        {
            DrawDebugUI();
            SetUI(false);
        }

        private void Update()
        {
            if (OVRInput.GetDown(OVRInput.Button.Two))
            {
                ToggleUI();
            }
        }

        private void DrawDebugUI()
        {
             Dictionary<CategoryType, List<CatalogItem>> groupedCatalog = catalogObject.GroupedCatalog;

             foreach (CatalogItem item in groupedCatalog[CategoryType.Beds])
             {
                 DebugUIBuilder.instance.AddRadio(item.Name, "itemSelection", (t) =>
                 {
                     SelectItem(item, t.isOn);
                     SetUI(false);
                 }, DebugUIBuilder.DEBUG_PANE_LEFT);
             }
             foreach (CatalogItem item in groupedCatalog[CategoryType.Storage])
             {
                 DebugUIBuilder.instance.AddRadio(item.Name, "itemSelection", (t) =>
                 {
                     SelectItem(item, t.isOn);
                     SetUI(false);
                 }, DebugUIBuilder.DEBUG_PANE_CENTER);
             }
             foreach (CatalogItem item in groupedCatalog[CategoryType.Sofas])
             {
                 DebugUIBuilder.instance.AddRadio(item.Name, "itemSelection", (t) =>
                 {
                     SelectItem(item, t.isOn);
                     SetUI(false);
                 }, DebugUIBuilder.DEBUG_PANE_RIGHT);
             }
        }

        private void SelectItem(CatalogItem item, bool isSelected)
        {
            if (!isSelected) return;
            SelectedItem = item;
            OnSelectionChanged?.Invoke(SelectedItem);
        }

        private void SetUI(bool toSet)
        {
            isUIVisible = toSet;
            if (isUIVisible)
            {
                DebugUIBuilder.instance.Show();
            }
            else
            {
                DebugUIBuilder.instance.Hide();
            }
        }

        private void ToggleUI()
        {
            SetUI(!isUIVisible);
        }

#if UNITY_EDITOR
        private int debugIndex = 0;
        
        [ContextMenu(nameof(Debug_SelectAnItem))]
        private void Debug_SelectAnItem()
        {
            SelectItem(catalogObject.Catalog[debugIndex++ % catalogObject.Catalog.Count], true);
        }
#endif
    }
}
