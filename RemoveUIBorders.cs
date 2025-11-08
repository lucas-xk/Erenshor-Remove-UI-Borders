using BepInEx;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace remove_ui_borders
{
    [BepInPlugin("lucasxk.erenshor.removeuiborders", "Remove UI Borders", "1.0.0")]
    public class RemoveUIBorders : BaseUnityPlugin
    {
        private void Awake()
        {
            SceneManager.sceneLoaded += OnSceneLoaded;
        }

        private void OnDestroy()
        {
            SceneManager.sceneLoaded -= OnSceneLoaded;
        }

        private string sceneName;

        private bool alreadyDestroyed = false;

        private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
        {
            sceneName = scene.name;

            if (sceneName == "Menu" || sceneName == "LoadScene")
                return;

            var borderObj = GameObject.Find("UI/UIElements/Canvas/HotbarPar/Image (1)");
            if (borderObj != null)
            {
                GameObject.Destroy(borderObj);
            }

            borderObj = GameObject.Find("UI/UIElements/NewGroupPar/Image (4)");
            if (borderObj != null)
            {
                GameObject.Destroy(borderObj);
            }

            borderObj = GameObject.Find("UI/UIElements/PlayerLifePar/Image (3)");
            if (borderObj != null)
            {
                GameObject.Destroy(borderObj);
            }

            borderObj = GameObject.Find($"UI/UIElements/CharmedPar/CharmedNPC");
            var borderComp = borderObj.GetComponent("UnityEngine.UI.Image");
            Object.Destroy(borderComp);
                        
            borderObj = GameObject.Find("UI/UIElements/TargCanv/NewTargetWindow/Image (1)");
            if (borderObj != null)
            {
                GameObject.Destroy(borderObj);
            }

            borderObj = GameObject.Find("UI/UIElements/TargCanv/NewTargetWindow/LifeNumBG (1)");
            if (borderObj != null)
            {
                GameObject.Destroy(borderObj);
            }

            if (alreadyDestroyed)
            {
                return;
            }
            borderObj = GameObject.Find("UI/UIElements/TargCanv/NewTargetWindow/Image");
            if (borderObj != null)
            {
                GameObject.Destroy(borderObj);
                alreadyDestroyed = true;
            }
        }
    }
}