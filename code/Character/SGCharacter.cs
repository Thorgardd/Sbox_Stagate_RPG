namespace Sandbox.Character;

public partial class SGCharacter : Player
{
	// PROPRIETES
	// --
	
	[Net] public float Armor { get; set; }
	[Net] public string Description { get; set; }
	[Net] public int Level { get; set; }
	[Net] public double Xperience { get; set; }

	
	// CONSTRUCTORS
	// --
	public SGCharacter()
	{
		
	}

	public SGCharacter(string name, string description)
	{
		Name = name;
		Description = description;
		Health = 100;
		Armor = 100;
		Level = 1;
		Xperience = 0;
	}
	
	// EVENTS 
	// -- 
	
	public override void Spawn()
	{
		base.Spawn();
		
		SetModel( "models/citizen/citizen.vmdl" );

		EnableDrawing = true;
		EnableAllCollisions = true;
		EnableHideInFirstPerson = true;
		EnableShadowInFirstPerson = true;

		MoveType = MoveType.Physics;
		CollisionGroup = CollisionGroup.Player;

		Controller = new WalkController();
		CameraMode = new FirstPersonCamera();
		Animator = new StandardPlayerAnimator();
	}
}
