/// <summary>
/// Stores the types of fighters there can exist
/// </summary>
public enum FighterType
{
	Human,
	AI
}

/// <summary>
/// Stores all the different states that a fighter can be in
/// </summary>
public enum FighterState 
{
	WALK_FORWARD,
	JUMP_FORWARD,
	WALK_BACK,
	JUMP_BACK,
	JUMP,
	CROUCH,
	IDLE,
    KNOCKDOWN,
	DEAD,
	DEFEND,
	DEFEND_HIT,
	TAKE_HIT,
	HIGH_KICK,
	LEFT_SIDEKICK,
	LEFT_HOOK,
	STRIAIGHT_LEFT,
	STRAIGHT_RIGHT,
	SPECIAL,
	CELEBRATE,
	NONE
}

