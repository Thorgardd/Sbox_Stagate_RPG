using Sandbox.Hud.CharacterHud;
using Sandbox.UI;

namespace Sandbox.Hud;

public class BaseHud : HudEntity<RootPanel>
{
	public static BaseHud Current { get; private set; }

	public BaseHud()
	{
		if ( !IsClient )
			return;

		Current = this;
		
		RootPanel.StyleSheet.Load( "/Hud/BaseHud.scss" );

		RootPanel.AddChild<ChatBox>();

		RootPanel.AddChild<CharHud>();
	}
}
