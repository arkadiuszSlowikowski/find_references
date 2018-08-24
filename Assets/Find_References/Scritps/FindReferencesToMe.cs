using System;
using System.Collections.Generic;
using System.Reflection;
using UnityEngine;

public class FindReferencesToMe : MonoBehaviour
{
	[SerializeField]
	private Component wantedComponent;
	[SerializeField]
	private bool searchByTheGameObject;
	[Space(25)]
	[SerializeField]
	private List<Reference_Info> referencesInfos = new List<Reference_Info>();

	private MonoBehaviour[] objects;

	public void FindScriptsInScene()
	{
		objects = FindObjectsOfType<MonoBehaviour>();
	}

	public void FindReferences()
	{
		referencesInfos.Clear();

		BindingFlags bindFlags = BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Static;

		foreach (MonoBehaviour monobehaviour in objects)
		{
			if (monobehaviour == this) continue;
			Type myType = monobehaviour.GetType();

			List<FieldInfo> fields = new List<FieldInfo>(myType.GetFields(bindFlags));

			foreach (FieldInfo field in fields)
			{
				try
				{
					object value = field.GetValue(monobehaviour);

					if (value == null) continue;

					if (searchByTheGameObject)
					{
						if (((Component)value).gameObject == wantedComponent.gameObject)
						{
							Reference_Info ri = new Reference_Info(monobehaviour, field);
							referencesInfos.Add(ri);
						}
					}
					else
					{
						if (value == (object)wantedComponent)
						{
							Reference_Info ri = new Reference_Info(monobehaviour, field);
							referencesInfos.Add(ri);
						}
					}
				}
				catch (Exception ex)
				{
					//Debug.Log(ex);
				}
			}
		}
	}
}

[Serializable]
public class Reference_Info
{
	[SerializeField]
	private string fieldName;
	[SerializeField]
	private MonoBehaviour scriptedObject;
	private FieldInfo fieldInfo;

	public Reference_Info(MonoBehaviour mb, FieldInfo fi)
	{
		fieldName = fi.Name;
		scriptedObject = mb;
		fieldInfo = fi;
	}

	public override string ToString()
	{
		return String.Format("{0}, {1}", scriptedObject.name, fieldInfo.GetValue(scriptedObject));
	}
}