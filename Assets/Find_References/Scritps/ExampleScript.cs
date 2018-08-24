using UnityEngine;

public class ExampleScript : MonoBehaviour
{
	public Component reference_1;
	[SerializeField]
	protected Component reference_2;
	[SerializeField]
	private Component reference_3;
	[HideInInspector]
	public Component reference_4;
	protected Component reference_5;
	private Component reference_6;

	[SerializeField]
	private string[] gameObjectsNames = new string[6];

	private void Start()
	{ 
		reference_1 = gameObjectsNames[0].Length > 0 ? GameObject.Find(gameObjectsNames[0]).transform : reference_1;
		reference_2 = gameObjectsNames[0].Length > 0 ? GameObject.Find(gameObjectsNames[1]).transform : reference_2;
		reference_3 = gameObjectsNames[0].Length > 0 ? GameObject.Find(gameObjectsNames[2]).transform : reference_3;
		reference_4 = reference_1;
		reference_5 = reference_1;
		reference_6 = reference_1;
	}
}