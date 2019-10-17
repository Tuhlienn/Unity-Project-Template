using UnityEditor;
using UnityEngine;
using System.Collections.Generic;
using System.Reflection;
using System;
using System.Linq;

[InitializeOnLoad]
class HierarchyIcons
{
    static Dictionary<int, Dictionary<Type, Texture2D>> markedTypeObjects = new Dictionary<int, Dictionary<Type, Texture2D>>();
    static Dictionary<int, Dictionary<string, Texture2D>> markedTagObjects = new Dictionary<int, Dictionary<string, Texture2D>>();

    //static Dictionary<int, DateTime> NotMarkedObjects = new Dictionary<int, DateTime>();

    static Dictionary<int, DateTime> lastTimeObjectCheck = new Dictionary<int, DateTime>();

    static TimeSpan outtime = new TimeSpan(0, 0, 0, 0, 300);

    static Dictionary<string, string> ClassesIconPath = new Dictionary<string, string>()
    {
        //{ "ModelBuilder", "Assets/CustomHierarchy/WindowIcons/Hammer.png"},
        //{ "FlexibleCylinderBuilder", "Assets/CustomHierarchy/WindowIcons/Hammer.png"},
        //{ "ModelBuilderSocket", "Assets/CustomHierarchy/WindowIcons/Prefab.png"},
        //{ "JointRotationHandler", "Assets/CustomHierarchy/WindowIcons/Joint.png"  },
        //{ "PrefabInstance", "Assets/CustomHierarchy/WindowIcons/Prefab.png"  }
    };

    static Dictionary<string, string> TagsIconPath = new Dictionary<string, string>()
    {
        { "PrefabAnchor", "Assets/CustomHierarchy/WindowIcons/Anchor.png"},
        { "Joint", "Assets/CustomHierarchy/WindowIcons/Joint.png"},
        { "ModelBuilderPrefab", "Assets/CustomHierarchy/WindowIcons/Prefab.png"}
    };


    static Dictionary<Type, Texture2D> ClassesIcons = new Dictionary<Type, Texture2D>();

    static Dictionary<string, Texture2D> TagsIcons = new Dictionary<string, Texture2D>();


    static Texture2D normalChildSprite;
    static Texture2D lastChildSprite;
    static Texture2D parentConnection;

    static Texture2D normalChildSpriteHighlighted;
    static Texture2D lastChildSpriteHighlighted;
    static Texture2D parentConnectionHighlighted;

    static HierarchyIcons()
    {
        // Init
        for (int index = 0; index < ClassesIconPath.Count; index++)
        {
            var item = ClassesIconPath.ElementAt(index);
            var itemKey = item.Key;
            var itemValue = item.Value;

            if (ClassesIcons.ContainsKey(Type.GetType(itemKey)))
            {
               ClassesIcons.Remove(Type.GetType(itemKey));
            } 
            ClassesIcons.Add(Type.GetType(itemKey), AssetDatabase.LoadAssetAtPath(ClassesIconPath[itemKey], typeof(Texture2D)) as Texture2D);
        }

        for (int index = 0; index < TagsIconPath.Count; index++)
        {
            var item = TagsIconPath.ElementAt(index);
            var itemKey = item.Key;
            var itemValue = item.Value;

            if (TagsIcons.ContainsKey(itemKey))
            {
                TagsIcons.Remove(itemKey);
            }
            TagsIcons.Add(itemKey, AssetDatabase.LoadAssetAtPath(TagsIconPath[itemKey], typeof(Texture2D)) as Texture2D);
        }

        normalChildSprite = AssetDatabase.LoadAssetAtPath("Assets/CustomHierarchy/WindowIcons/HierarchyIcons/Child_Normal.png", typeof(Texture2D)) as Texture2D;
        lastChildSprite = AssetDatabase.LoadAssetAtPath("Assets/CustomHierarchy/WindowIcons/HierarchyIcons/LastChild_Normal.png", typeof(Texture2D)) as Texture2D;
        parentConnection = AssetDatabase.LoadAssetAtPath("Assets/CustomHierarchy/WindowIcons/HierarchyIcons/ParentConnection_Normal.png", typeof(Texture2D)) as Texture2D;

        normalChildSpriteHighlighted = AssetDatabase.LoadAssetAtPath("Assets/CustomHierarchy/WindowIcons/HierarchyIcons/Child_Highlight_Dark.png", typeof(Texture2D)) as Texture2D;
        lastChildSpriteHighlighted = AssetDatabase.LoadAssetAtPath("Assets/CustomHierarchy/WindowIcons/HierarchyIcons/LastChild_Highlight_Dark.png", typeof(Texture2D)) as Texture2D;
        parentConnectionHighlighted = AssetDatabase.LoadAssetAtPath("Assets/CustomHierarchy/WindowIcons/HierarchyIcons/ParentConnection_Highlight_Dark.png", typeof(Texture2D)) as Texture2D;

        EditorApplication.hierarchyWindowItemOnGUI += HierarchyItemCB;
    }
        
    private static void DrawHierarchyIcon(Texture2D sprite, int currentParentIteration, Rect refRect)
    {
        // is normal child
        var tempRect = new Rect(refRect);
        tempRect.x = ((tempRect.x - 32) - (currentParentIteration * 14)); // + tempRect.width) - ( 20);
        tempRect.width = 20; 
         tempRect.height = 20;
        // Debug.Log("Height: " + tempRect.height);

            GUI.Label(tempRect, sprite);
    }

    static void HierarchyItemCB(int instanceID, Rect selectionRect)
    {
        // place the icon to the right of the list:
        Rect r = new Rect(selectionRect);
        r.x = r.width ;
        r.width = 20;

        GameObject go = EditorUtility.InstanceIDToObject(instanceID) as GameObject;

        /// Draw ChildIcons
        if (go != null)
        {
            // Draw first order hierarchy
            if (go.transform.parent != null)
            {
                if (go.transform.GetSiblingIndex() < go.transform.parent.childCount - 1)
                {
                    if (Selection.activeTransform != null && go.transform.parent.IsChildOf(Selection.activeTransform))
                    {
                        DrawHierarchyIcon(normalChildSpriteHighlighted, 0, selectionRect);
                    }
                    else
                    {
                        DrawHierarchyIcon(normalChildSprite, 0, selectionRect);
                    }
                }
                else
                {
                    if (Selection.activeTransform != null && go.transform.parent.IsChildOf(Selection.activeTransform))
                    {
                        DrawHierarchyIcon(lastChildSpriteHighlighted, 0, selectionRect);
                    }
                    else
                    {
                        DrawHierarchyIcon(lastChildSprite, 0, selectionRect);
                    }
                }

                var referenceTransform = go.transform.parent;
                var parentIteration = 1;

                // Draw all other order hierarchy
                while (referenceTransform.parent != null)
                {


                    if (referenceTransform.GetSiblingIndex() < referenceTransform.parent.childCount - 1)
                    {
                        if (Selection.activeTransform != null && referenceTransform.parent.IsChildOf(Selection.activeTransform))
                        {
                            DrawHierarchyIcon(parentConnectionHighlighted, parentIteration, selectionRect);
                        }
                        else
                        {
                            DrawHierarchyIcon(parentConnection, parentIteration, selectionRect);
                        }
                    }

                    referenceTransform = referenceTransform.parent;
                    parentIteration++;
                }
            }
        }

        var counter = 0;

        // Draw Type Icons
        if (markedTypeObjects.ContainsKey(instanceID))
        {
            for (int index = 0; index < markedTypeObjects[instanceID].Count; index++)
            {
                var item = markedTypeObjects[instanceID].ElementAt(index);
                var itemKey = item.Key;
                var itemValue = item.Value;
            

                var tempRect = new Rect(selectionRect);
                tempRect.x = ((tempRect.x - 30) + tempRect.width) - (counter * 20);
                tempRect.width = 20;
                
                GUI.Label(tempRect, itemValue);
                counter++;
            }
        }

        // Draw Tag Icons
        if (markedTagObjects.ContainsKey(instanceID))
        {
            for (int index = 0; index < markedTagObjects[instanceID].Count; index++)
            {
                var item = markedTagObjects[instanceID].ElementAt(index);
                var itemKey = item.Key;
                var itemValue = item.Value;
              
                var tempRect = new Rect(selectionRect);
                tempRect.x = ((tempRect.x - 30) + tempRect.width) - (counter * 20);
                tempRect.width = 20;
                GUI.Label(tempRect, itemValue);
                counter++;
            }

        }

        if (!lastTimeObjectCheck.ContainsKey(instanceID))
        {
            lastTimeObjectCheck.Add(instanceID, DateTime.Now - outtime);
        }
        if (DateTime.Now - lastTimeObjectCheck[instanceID] > outtime)
        {
            lastTimeObjectCheck[instanceID] = DateTime.Now;
            if (go != null)
            {
                var atLeastOnePositve = false;

                for (int index = 0; index < ClassesIcons.Count; index++)
                {
                    var item = ClassesIcons.ElementAt(index);
                    var itemKey = item.Key;
                    var itemValue = item.Value;

                    if (go.GetComponent(itemKey))
                    {
                        if (!markedTypeObjects.ContainsKey(instanceID))
                        {
                            markedTypeObjects.Add(instanceID, new Dictionary<Type, Texture2D>() { { itemKey, itemValue } } );
                        }
                        else
                        {
                            if (!markedTypeObjects[instanceID].ContainsKey(itemKey))
                            {
                                markedTypeObjects[instanceID].Add(itemKey, itemValue);
                            }  
                        }
                        atLeastOnePositve = true;
                    }
                    else
                    {
                        if (markedTypeObjects.ContainsKey(instanceID))
                        {
                            if (markedTypeObjects[instanceID].ContainsKey(itemKey))
                            {
                                markedTypeObjects[instanceID].Remove(itemKey);
                            }
                        }
                    }
                }

                if (!atLeastOnePositve)
                {
                    if (markedTypeObjects.ContainsKey(instanceID))
                    {
                        markedTypeObjects.Remove(instanceID);
                    }
                }

                atLeastOnePositve = false;

                for (int index = 0; index < TagsIcons.Count; index++)
                {
                    var item = TagsIcons.ElementAt(index);
                    var itemKey = item.Key;
                    var itemValue = item.Value;  

                    if (go.tag == itemKey)
                    {   
                        if (!markedTagObjects.ContainsKey(instanceID))
                        {
                            markedTagObjects.Add(instanceID, new Dictionary<string, Texture2D>() { { itemKey, itemValue } });
                        }
                        else
                        {
                            if (!markedTagObjects[instanceID].ContainsKey(itemKey))
                            {
                                markedTagObjects[instanceID].Add(itemKey, itemValue);
                            }
                        }
                        atLeastOnePositve = true;
                    }
                    else
                    {
                        if (markedTagObjects.ContainsKey(instanceID))
                        {
                            if (markedTagObjects[instanceID].ContainsKey(itemKey))
                            {
                                markedTagObjects[instanceID].Remove(itemKey);
                            }
                        }
                    }
                }

                if (!atLeastOnePositve)
                {
                    if (markedTagObjects.ContainsKey(instanceID))
                    {
                        markedTagObjects.Remove(instanceID);
                    }
                }
            }
        }  
    }
}