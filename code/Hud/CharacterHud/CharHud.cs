using System.ComponentModel;
using System.Globalization;
using System.Numerics;
using Sandbox.Character;
using Sandbox.UI;
using Sandbox.UI.Construct;

namespace Sandbox.Hud.CharacterHud;

public class CharHud : Panel
{
	public static CharHud Current { get; private set; }
	public Panel ImageContainer, BarContainer, HealthBar, ArmorBar;
	public Image FactionImage;
	public Label NameValue;
	
	public CharHud()
	{
		Current = this;

		ImageContainer = Add.Panel("ImageContainer");
		BarContainer = Add.Panel( "BarContainer" );

		ImageContainer.Add.Image("/images/sgcLogo.png", "Image");

		NameValue = BarContainer.Add.Label("", "NameValue");
		
		HealthBar = BarContainer.Add.Panel("HealthBar");
		ArmorBar = BarContainer.Add.Panel( "ArmorBar" );
	}

	public override void Tick()
	{
		base.Tick();

		var client = Local.Client;
		if (client == null) return;

		var character = client.Pawn as SGCharacter;
		if (character == null) return;
		
		NameValue.Text = character.Name;
		HealthBar.Style.Dirty();
		HealthBar.Style.Width = Length.Percent( character.Health );
		ArmorBar.Style.Dirty();
		ArmorBar.Style.Width = Length.Percent( character.Armor );
	}
}
