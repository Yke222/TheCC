using UnityEngine;

public class ArenaSetter : MonoBehaviour
{

	public GameObject Lava;
	public GameObject Water;
	public GameObject Ice;

	// Use this for initialization
	
	void Start () {
		switch (ArenaPicker.ArenaNumber)
		{
			case 1:
				Lava.SetActive(true);
				break;
			
			case 2:
				Water.SetActive(true);
				break;
			
			case 3:
				Ice.SetActive(true); 
				break;
		}
	}
}
