#pragma strict

class Main extends MonoBehaviour
{

	private var home : int = 13;
	private var togo : int = 5;
	private var guest : int = 7;
	
	function Update()
	{
		var orbitScript = GameObject.Find("Main Camera").GetComponent(MouseOrbit);
	 	orbitScript.enabled = Input.GetMouseButton(0);
	}
	
	function OnGUI()
	{
		
	
		if(GUILayout.Button("INC HOME"))
		{	
			++home;
			if(home > 99) home = 0;
			updateHome();
		}	
		if(GUILayout.Button("DEC HOME"))
		{
			--home;
			if(home < 0) home = 99;
			updateHome();
		}
		
		if(GUILayout.Button("INC TOGO"))
		{
			++togo;
			if(togo > 99) togo = 0;
			updateToGo();
		}		
		if(GUILayout.Button("DEC TOGO"))
		{
			--togo;
			if(togo < 0) togo = 99;
			updateToGo();
		}
		
		if(GUILayout.Button("INC GUEST"))
		{
			++guest;
			if(guest > 99) guest = 0;
			updateGuest();
		}
		if(GUILayout.Button("DEC GUEST"))
		{
			--guest;
			if(guest < 0) guest = 99;
			updateGuest();
		}
		
	}
	
	function updateHome()
	{	
		GameObject.Find("Score Board").transform.FindChild("HomeDisplay").GetComponent(ContainerDisplay7Seg).text = String.Format("{0,2}", home);
	}
	
	function updateToGo()
	{
		GameObject.Find("Score Board").transform.FindChild("ToGoDisplay").GetComponent(ContainerDisplay7Seg).text = String.Format("{0,2}", togo);
	}
	
	function updateGuest()
	{
		GameObject.Find("Score Board").transform.FindChild("GuestDisplay").GetComponent(ContainerDisplay7Seg).text = String.Format("{0,2}", guest);
	}

}
