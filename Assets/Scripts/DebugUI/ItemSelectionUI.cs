using System;
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
            if (OVRInput.GetDown(OVRInput.Button.PrimaryIndexTrigger) || 
                OVRInput.GetDown(OVRInput.Button.SecondaryIndexTrigger) ||
                OVRInput.GetUp(OVRInput.Button.PrimaryIndexTrigger) ||
                OVRInput.GetUp(OVRInput.Button.SecondaryIndexTrigger))
            {
                ToggleUI();
            }
        }

        private void DrawDebugUI()
        {
            List<CatalogItem> catalog = catalogObject.Catalog;
            foreach (CatalogItem item in catalog)
            {
                DebugUIBuilder.instance.AddRadio(item.Name, "itemSelection", (t) =>
                {
                    SelectItem(item, t.isOn);
                    SetUI(false);
                });
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
    }
}
