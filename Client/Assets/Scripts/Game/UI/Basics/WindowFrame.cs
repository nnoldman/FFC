/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace Basics
{
	public partial class WindowFrame : GLabel
	{
		public GButton closeButton;
		public GGraph dragArea;
		public GGraph contentArea;

		public const string URL = "ui://9leh0eyfrt103l";

		public static WindowFrame CreateInstance()
		{
			return (WindowFrame)UIPackage.CreateObject("Basics","WindowFrame");
		}

		public WindowFrame()
		{
		}

		public override void ConstructFromXML(XML xml)
		{
			base.ConstructFromXML(xml);

			closeButton = (GButton)this.GetChildAt(1);
			dragArea = (GGraph)this.GetChildAt(2);
			contentArea = (GGraph)this.GetChildAt(4);
		}
	}
}