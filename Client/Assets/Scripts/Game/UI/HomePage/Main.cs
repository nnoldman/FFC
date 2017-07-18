/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace HomePage
{
	public partial class Main : GComponent
	{
		public GTextInput user;
		public GTextInput psw;
		public GButton login;
		public GButton exit;

		public const string URL = "ui://3aca1ugukr711";

		public static Main CreateInstance()
		{
			return (Main)UIPackage.CreateObject("HomePage","Main");
		}

		public Main()
		{
		}

		public override void ConstructFromXML(XML xml)
		{
			base.ConstructFromXML(xml);

			user = (GTextInput)this.GetChildAt(3);
			psw = (GTextInput)this.GetChildAt(4);
			login = (GButton)this.GetChildAt(5);
			exit = (GButton)this.GetChildAt(6);
		}
	}
}