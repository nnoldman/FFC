/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace Basics
{
	public partial class GridItem : GButton
	{
		public GTextField t0;
		public GTextField t1;
		public GTextField t2;
		public GProgressBar star;

		public const string URL = "ui://9leh0eyfa7vt7n";

		public static GridItem CreateInstance()
		{
			return (GridItem)UIPackage.CreateObject("Basics","GridItem");
		}

		public GridItem()
		{
		}

		public override void ConstructFromXML(XML xml)
		{
			base.ConstructFromXML(xml);

			t0 = (GTextField)this.GetChildAt(2);
			t1 = (GTextField)this.GetChildAt(4);
			t2 = (GTextField)this.GetChildAt(5);
			star = (GProgressBar)this.GetChildAt(6);
		}
	}
}