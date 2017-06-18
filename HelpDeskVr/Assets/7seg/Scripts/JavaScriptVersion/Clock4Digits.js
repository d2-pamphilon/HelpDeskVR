#pragma strict

class Clock4Digits extends MonoBehaviour
{
	var text : String = "12:34";
	var onColor : Color = Color.red;
	var offColor : Color = Color.black;
	
	private var displays : GameObject = null;
	private var points : GameObject = null;
	
	function Start ()
	{
		displays = transform.FindChild("DisplayContainer").gameObject;
		points = transform.FindChild("Display2Points").gameObject;
	}

	function Update ()
	{
		if(text.length != 5) text = "12:34";
		
		displays.GetComponent(ContainerDisplay7Seg).onColor = onColor;
		displays.GetComponent(ContainerDisplay7Seg).offColor = offColor;
		displays.GetComponent(ContainerDisplay7Seg).text = text.Substring(0,2) + text.Substring(3,2);
		
		points.GetComponent(Display2Point).onColor = onColor;
		points.GetComponent(Display2Point).offColor = offColor;
		points.GetComponent(Display2Point).on = text[2] == ":" ? true : false; 
	}
}
