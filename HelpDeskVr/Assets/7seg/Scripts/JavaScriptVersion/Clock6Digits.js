#pragma strict

class Clock6Digits extends MonoBehaviour
{
	var text : String = "12:34:56";
	var onColor : Color = Color.red;
	var offColor : Color = Color.black;
	
	private var displays : GameObject = null;
	private var points1 : GameObject = null;
	private var points2 : GameObject = null;
	
	function Start ()
	{
		displays = transform.FindChild("DisplayContainer").gameObject;
		points1 = transform.FindChild("Display2Points1").gameObject;
		points2 = transform.FindChild("Display2Points2").gameObject;
	}

	function Update ()
	{
		if(text.length != 8) text = "12:34:56";
		
		displays.GetComponent(ContainerDisplay7Seg).onColor = onColor;
		displays.GetComponent(ContainerDisplay7Seg).offColor = offColor;
		displays.GetComponent(ContainerDisplay7Seg).text = text.Substring(0,2) + text.Substring(3,2) + text.Substring(6,2);
		
		points1.GetComponent(Display2Point).onColor = onColor;
		points1.GetComponent(Display2Point).offColor = offColor;
		points1.GetComponent(Display2Point).on = text[2] == ":" ? true : false;
		
		points2.GetComponent(Display2Point).onColor = onColor;
		points2.GetComponent(Display2Point).offColor = offColor;
		points2.GetComponent(Display2Point).on = text[5] == ":" ? true : false;
	}
}
