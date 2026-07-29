extends CharacterBody2D


@onready var animationplayer: AnimationPlayer = $Sprite2D/AnimationPlayer

func _ready() -> void:
	animationplayer.play("idle")
	
func _on_animation_player_animation_finished(anim_name: StringName) -> void:
	match anim_name:
		"idle":
			pass
		"attack":
			pass
		"cast":
			pass
		"hit":
			pass
		"die":
			pass
