/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace Basics
{
	public partial class GridItem2 : GButton
	{
		public GTextField t3;
		public GTextField t1;
		public GButton cb;
		public GMovieClip mc;

		public const string URL = "ui://9leh0eyfatih7o";

		public static GridItem2 CreateInstance()
		{
			return (GridItem2)UIPackage.CreateObject("Basics","GridItem2");
		}

		public GridItem2()
		{
		}

		public override void ConstructFromXML(XML xml)
		{
			base.ConstructFromXML(xml);

			t3 = (GTextField)this.GetChildAt(2);
			t1 = (GTextField)this.GetChildAt(4);
			cb = (GButton)this.GetChildAt(5);
			mc = (GMovieClip)this.GetChildAt(6);
		}
	}
}