using Sandbox;
using Sandbox.UI.Construct;
using System;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Sandbox.Character;
using Sandbox.Hud;

namespace Sandbox;

public partial class SGame : Sandbox.Game
{
	public static SGame Current { get; private set; }
	
	public SGame()
	{
		Current = this;
		
		if ( IsServer )
		{
			_ = new BaseHud();
		}
	}
	
	public override void ClientJoined( Client client )
	{
		base.ClientJoined( client );
		
		var pawn = new SGCharacter("Jack O'Neill", "Général de l'U.S Air Force");
		client.Pawn = pawn;
		
		var spawnpoints = Entity.All.OfType<SpawnPoint>();
		
		var randomSpawnPoint = spawnpoints.MinBy(x => Guid.NewGuid());
		
		if ( randomSpawnPoint != null )
		{
			var tx = randomSpawnPoint.Transform;
			tx.Position = tx.Position + Vector3.Up * 50.0f; // raise it up
			pawn.Transform = tx;
		}
	}
}
