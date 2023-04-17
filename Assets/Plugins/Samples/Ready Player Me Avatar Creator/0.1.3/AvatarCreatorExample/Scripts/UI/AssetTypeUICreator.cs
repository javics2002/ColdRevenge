using System;
using System.Collections.Generic;
using System.Linq;
using ReadyPlayerMe.AvatarCreator;
using ReadyPlayerMe.AvatarLoader;
using UnityEngine;
using UnityEngine.UI;

namespace ReadyPlayerMe
{
    public class AssetTypeUICreator : MonoBehaviour
    {
        [Serializable]
        private class AssetTypeIcon
        {
            public AssetType assetType;
            public Sprite icon;
        }

        [Serializable]
        private class AssetTypeUI
        {
            public GameObject buttonPrefab;
            public Transform buttonParent;
            public GameObject panelPrefab;
            public Transform panelParent;
        }

        [SerializeField] private AssetTypeUI assetTypeUI;
        [SerializeField] private AssetTypeButton faceAssetTypeButton;
        [SerializeField] private GameObject faceAssetTypePanel;
        [SerializeField] private GameObject faceAssetPanelPrefab;
        [SerializeField] private GameObject leftSidePanelPrefab;
        [SerializeField] private CameraZoom cameraZoom;
        [SerializeField] private List<AssetTypeIcon> assetTypeIcons;

        private Dictionary<AssetType, AssetTypeButton> assetTypeButtonsMap;
        private AssetTypeButton selectedAssetTypeButton;

        public void CreateUI(BodyType bodyType, IEnumerable<AssetType> assetTypes)
        {
            cameraZoom.DefaultZoom(bodyType);

            assetTypeButtonsMap = new Dictionary<AssetType, AssetTypeButton>();
            PanelSwitcher.FaceTypePanel = faceAssetTypePanel;

            foreach (var assetType in assetTypes)
            {
                if (assetType == AssetType.EyeColor)
                {
                    CreateAssetTypePanel(assetType, leftSidePanelPrefab, assetTypeUI.panelParent);
                }
                else if (AssetTypeHelper.IsFaceAsset(assetType))
                {
                    CreateAssetTypePanel(assetType, faceAssetPanelPrefab, assetTypeUI.panelParent);
                    CreateAssetTypeButton(assetType, faceAssetTypePanel.GetComponent<ScrollRect>().content.transform, () =>
                        PanelSwitcher.Switch(assetType));
                }
                else
                {
                    CreateAssetTypePanel(assetType, assetTypeUI.panelPrefab, assetTypeUI.panelParent);
                    CreateAssetTypeButton(assetType, assetTypeUI.buttonParent, () =>
                        PanelSwitcher.Switch(assetType));
                }
            }

            DefaultSelection();
            faceAssetTypeButton.AddListener(() =>
            {
                if (selectedAssetTypeButton != null)
                {
                    selectedAssetTypeButton.SetSelect(false);
                }

                DefaultSelection();
            });
        }

        public void ResetUI()
        {
            PanelSwitcher.Clear();

            foreach (var assetTypeButton in assetTypeButtonsMap)
            {
                Destroy(assetTypeButton.Value.gameObject);
            }

            faceAssetTypeButton.RemoveListener();
            assetTypeButtonsMap.Clear();
        }

        private void CreateAssetTypePanel(AssetType assetType, GameObject panelPrefab, Transform parent)
        {
            var assetTypePanel = Instantiate(panelPrefab, parent);
            assetTypePanel.name = assetType + "Panel";
            assetTypePanel.SetActive(false);

            PanelSwitcher.AddPanel(assetType, assetTypePanel);
        }

        private void CreateAssetTypeButton(AssetType assetType, Transform parent, Action onClick)
        {
            var assetTypeButtonGameObject = Instantiate(assetTypeUI.buttonPrefab, parent);
            var assetTypeButton = assetTypeButtonGameObject.GetComponent<AssetTypeButton>();
            assetTypeButton.name = assetType + "Button";
            var assetTypeIcon = assetTypeIcons.FirstOrDefault(x => x.assetType == assetType);
            if (assetTypeIcon != null)
            {
                assetTypeButton.SetIcon(assetTypeIcon.icon);
            }

            assetTypeButton.AddListener(() =>
            {
                cameraZoom.SwitchZoomByAssetType(assetType);
                assetTypeButton.SetSelect(true);
                selectedAssetTypeButton.SetSelect(false);
                faceAssetTypeButton.SetSelect(AssetTypeHelper.IsFaceAsset(assetType));
                selectedAssetTypeButton = assetTypeButton;
                onClick?.Invoke();
            });
            assetTypeButtonsMap.Add(assetType, assetTypeButton);
        }

        private void DefaultSelection()
        {
            faceAssetTypeButton.SetSelect(true);
            assetTypeButtonsMap[AssetType.FaceShape].SetSelect(true);
            PanelSwitcher.Switch(AssetType.FaceShape);
            selectedAssetTypeButton = assetTypeButtonsMap[AssetType.FaceShape];
        }
    }
}
