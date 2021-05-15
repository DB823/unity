// =====================================================
// DO NOT EDIT - this file is automatically regenerated.
// =====================================================

using System;
using Improbable.Gdk.BuildSystem;
using Improbable.Gdk.BuildSystem.Configuration;
using Improbable.Gdk.Tools;
using UnityEditor;
using UnityEngine;

namespace Improbable
{
    internal static class BuildWorkerMenu
    {
        private const string LocalMenu = "Build for local";
        private const string CloudMenu = "Build for cloud";

        private static readonly string[] AllWorkers = new string[]
        {
            "MobileClient",
            "UnityClient",
            "UnityGameLogic"
        };

        [MenuItem(EditorConfig.ParentMenu + "/" + LocalMenu + "/MobileClient", false, EditorConfig.MenuOffset + 0)]
        public static void BuildLocalMobileClient()
        {
            MenuBuild(BuildContextSettings.Local("MobileClient"));
        }

        [MenuItem(EditorConfig.ParentMenu + "/" + CloudMenu + "/MobileClient", false, EditorConfig.MenuOffset + 0)]
        public static void BuildCloudMobileClient()
        {
            MenuBuild(BuildContextSettings.Cloud("MobileClient"));
        }

        [MenuItem(EditorConfig.ParentMenu + "/" + LocalMenu + "/UnityClient", false, EditorConfig.MenuOffset + 1)]
        public static void BuildLocalUnityClient()
        {
            MenuBuild(BuildContextSettings.Local("UnityClient"));
        }

        [MenuItem(EditorConfig.ParentMenu + "/" + CloudMenu + "/UnityClient", false, EditorConfig.MenuOffset + 1)]
        public static void BuildCloudUnityClient()
        {
            MenuBuild(BuildContextSettings.Cloud("UnityClient"));
        }

        [MenuItem(EditorConfig.ParentMenu + "/" + LocalMenu + "/UnityGameLogic", false, EditorConfig.MenuOffset + 2)]
        public static void BuildLocalUnityGameLogic()
        {
            MenuBuild(BuildContextSettings.Local("UnityGameLogic"));
        }

        [MenuItem(EditorConfig.ParentMenu + "/" + CloudMenu + "/UnityGameLogic", false, EditorConfig.MenuOffset + 2)]
        public static void BuildCloudUnityGameLogic()
        {
            MenuBuild(BuildContextSettings.Cloud("UnityGameLogic"));
        }

        [MenuItem(EditorConfig.ParentMenu + "/" + LocalMenu + "/All workers", true, EditorConfig.MenuOffset + 3)]
        [MenuItem(EditorConfig.ParentMenu + "/" + CloudMenu + "/All workers", true, EditorConfig.MenuOffset + 3)]
        [MenuItem(EditorConfig.ParentMenu + "/" + LocalMenu + "/MobileClient", true, EditorConfig.MenuOffset + 0)]
        [MenuItem(EditorConfig.ParentMenu + "/" + CloudMenu + "/MobileClient", true, EditorConfig.MenuOffset + 0)]
        [MenuItem(EditorConfig.ParentMenu + "/" + LocalMenu + "/UnityClient", true, EditorConfig.MenuOffset + 1)]
        [MenuItem(EditorConfig.ParentMenu + "/" + CloudMenu + "/UnityClient", true, EditorConfig.MenuOffset + 1)]
        [MenuItem(EditorConfig.ParentMenu + "/" + LocalMenu + "/UnityGameLogic", true, EditorConfig.MenuOffset + 2)]
        [MenuItem(EditorConfig.ParentMenu + "/" + CloudMenu + "/UnityGameLogic", true, EditorConfig.MenuOffset + 2)]
        public static bool ValidateEditorCompile()
        {
            return !EditorUtility.scriptCompilationFailed;
        }

        [MenuItem(EditorConfig.ParentMenu + "/" + LocalMenu + "/All workers", false, EditorConfig.MenuOffset + 3)]
        public static void BuildLocalAll()
        {
            MenuBuild(BuildContextSettings.Local(AllWorkers));
        }

        [MenuItem(EditorConfig.ParentMenu + "/" + CloudMenu + "/All workers", false, EditorConfig.MenuOffset + 3)]
        public static void BuildCloudAll()
        {
            MenuBuild(BuildContextSettings.Cloud(AllWorkers));
        }

        [MenuItem(EditorConfig.ParentMenu + "/Clean all workers", false, EditorConfig.MenuOffset + 3)]
        public static void Clean()
        {
            MenuCleanAll();
        }

        private static void MenuBuild(BuildContextSettings buildContextSettings)
        {
            WorkerBuilder.MenuBuild(buildContextSettings);
        }

        private static void MenuCleanAll()
        {
            WorkerBuilder.Clean();
            Debug.Log("Clean completed");
        }
    }
}
