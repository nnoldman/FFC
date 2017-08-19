/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace Login
{
	public partial class SexGroup : GComponent
	{
		public Controller SexGroupController;

		public const string URL = "ui://3aca1ugubdlag";

		public static SexGroup CreateInstance()
		{
			return (SexGroup)UIPackage.CreateObject("Login","SexGroup");
		}

		public SexGroup()
		{
		}

		public override void ConstructFromXML(XML xml)
		{
			base.ConstructFromXML(xml);

			SexGroupController = this.GetController("SexGroupController");
		}
	}
}