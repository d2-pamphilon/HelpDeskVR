#pragma strict

class ContainerDisplay7Seg extends MonoBehaviour
{
	var text : String = "";
	var onColor : Color = Color.red;
	var offColor : Color = Color.black;
	
	private var displayArray : Array = new Array();

	function Start ()
	{
	
		for(var index:int = 0; index < transform.childCount; ++index)
		{			
			if(transform.GetChild(index).gameObject.name == "Display7Seg") displayArray.push(transform.GetChild(index).gameObject as GameObject);			
		}
	}

	function Update()
	{
		UpdateDisplays();
	}

	function UpdateDisplays ()
	{
		var pointCounter : int = 0;
		
		for(var index:int = 0; index < text.length; ++index)
		{
			if(index - pointCounter < displayArray.Count)
			{
				var go = displayArray[index-pointCounter] as GameObject;
				var d7seg : Display7Seg = go.GetComponent(Display7Seg);
				d7seg.onColor = onColor;
				d7seg.offColor = offColor;

				var ch : char = text[index];
				var pointState : boolean = false;				
				
				if(index+1 < text.length)
				{
					if(text[index+1] == '.')
					{
						pointState = true;
						++pointCounter;
						++index;
					}
					else pointState = false;
				}
				else pointState = false;

				d7seg.setChar(ch, pointState);
			}
		}
		

	}

}