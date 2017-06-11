using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEditor;

public class AutoAddScript : MonoBehaviour
{

    public List<string> m_PrefabList;
    public List<GameObject> m_PrefabGameobjectList;
    private string m_Path;
    private DirectoryInfo m_dir;
    private FileInfo[] m_info;


    public VRTK.VRTK_InteractControllerAppearance Script1;
    public VRTK.VRTK_InteractableObject Script2;

    // Use this for initialization
    void Start()
    {
        m_PrefabList = new List<string>();
        m_PrefabGameobjectList = new List<GameObject>();

        m_Path = "Assets/PrefabTest/";
        m_dir = new DirectoryInfo(m_Path);

        m_info = m_dir.GetFiles("*.*");

        foreach (FileInfo f in m_info)
        {
            if (f.Extension == ".prefab")
            {
                m_PrefabList.Add(f.DirectoryName);
                string m_strippedName = f.Name.Replace(f.Extension, "");

                m_PrefabGameobjectList.Add(GameObject.Find(m_strippedName));

                GameObject m_PrefabGameobject;

                m_PrefabGameobject = Resources.Load(f.Extension) as GameObject;
                print(m_PrefabGameobject);
                m_PrefabGameobject.AddComponent<Rigidbody>();

                //EditorUtility.ReplacePrefab(m_PrefabGameobject, m_PrefabGameobject);

                PrefabUtility.ReplacePrefab(m_PrefabGameobject, Resources.Load(f.Extension), ReplacePrefabOptions.ReplaceNameBased);


            }
        }

        //GameObject prefab = GameObject.Find("Cube1");
        //Object GameObject2 = PrefabUtility.GetPrefabParent(prefab);
        //string prefabPath = AssetDatabase.GetAssetPath(GameObject2);
        //Debug.Log("Path: " + prefabPath);


        //Setup(f.Name);

    }

    void Setup(string _name)
    {
        for (int i = 0; i < m_PrefabGameobjectList.Count; i++)
        {
            if (m_PrefabGameobjectList[i].GetComponent<Rigidbody>() == null)
            {
                GameObject m_prefabOb = m_PrefabGameobjectList[i];
                m_prefabOb.AddComponent<Rigidbody>();

                //  m_PrefabGameobject[i].AddComponent<Rigidbody>();

                print(PrefabUtility.GetPrefabType(GameObject.Find(_name)));

                PrefabUtility.ReplacePrefab (m_prefabOb, GameObject.Find(_name)); //, ReplacePrefabOptions.Default);
                //PrefabUtility.MergeAllPrefabInstances(m_PrefabGameobject[i]);
                

            }
        }
    }



}
