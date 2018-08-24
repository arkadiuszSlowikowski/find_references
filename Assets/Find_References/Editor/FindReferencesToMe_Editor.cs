using UnityEditor;
using UnityEngine;

[CustomEditor(typeof(FindReferencesToMe))]
public class FindReferencesToMe_Editor : Editor
{
	public override void OnInspectorGUI()
	{
		base.DrawDefaultInspector();

		FindReferencesToMe frtm = (FindReferencesToMe)target;

		if (GUILayout.Button("Find references"))
		{
			frtm.FindScriptsInScene();
			frtm.FindReferences();
		}
	}
}