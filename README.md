# MageDefence Unity Project

MageDefence is a Unity-based test project. The concept is simple: a mage defends against monsters. The project emphasizes good programming practices and reliable code, focusing on extensibility and maintainability.
![sleekshot](https://github.com/user-attachments/assets/cd475c06-23b3-4785-91b1-2a70ec319ef2)



---

## Features

- **Frameworks and Tools**:
  - Zenject
  - UniRx
  - Unity Input System
  - Character Controller for movement

- **ScriptableObject Configurability**:
  - **Enemies**: Easily add or modify enemies through ScriptableObjects.
  - **Spells**: Simple steps to add new spells.
  - **Player Stats**: Adjust via ScriptableObjects, runtime models, or debug controllers.

- **Controls**:
  - **Movement/Rotation**: WASD / Arrow keys
  - **Cast Spell**: `X` / Left Click
  - **Change Spell**: `Q` / `E`

---

## Getting Started

### Creating New Enemies
1. Create an `EnemyBase` ScriptableObject and configure its values.
2. Create a prefab variant of `BaseEnemy` and update the model if necessary.
3. Assign the created prefab to the `Prefab` field in your ScriptableObject.
4. Add the ScriptableObject to the `EnemySpawnerConfig`.

Now your new enemy will spawn and chase the mage! 😄

### Creating New Spells
1. Create a new `Spell` ScriptableObject in `Resources/Spells/Basic` and configure its values.
2. Create a prefab variant of `BaseProjectile`.
3. Assign the prefab variant to the `ProjectilePrefab` field in your Spell ScriptableObject.

Your new spell is ready to cast! 🎉

### Adjusting Player Stats
- **Constraints**: Use the `PlayerStats` ScriptableObject.
- **Runtime**: Modify the `PlayerStatsModel` instantiated by Zenject.
- **Inspector**: Use the `PlayerStatsDebugController`.

### Configuring Enemy Spawning
Modify the `EnemySpawnerConfig` parameters to adjust enemy spawn rates and variety.

---

## Scene Setup
To create a new scene:
1. Add the `Mage` prefab.
2. Include a walkable surface (e.g., a plane) with a NavMesh baked for `Base Enemy` Agent Type.
3. Add the `SceneContextDefault` prefab to install Zenject dependencies.
4. Include the `SpawnSystem` prefab to manage enemy spawning.

---

## Future Improvements

### Enhancements
- **Object Pooling**: For spells and enemies to improve performance.
- **ScriptableObject Validation**: Ensure data consistency for player and enemy stats.
- **Review Collision Matrix**: proper collision matrix
- **Fix NavMesh Navigation Layers**: navigation settings for agents 
- **Optimization**: Resolve boxing/unboxing issues (e.g., in `PlayerStatsUI.Start()`).
- **Logic Refinement**: Combine `Health` and `PlayerHealth` scripts.
- **Addressables**: Implement addressables for spells and enemies to simplify updates and additions.

### New Features
- Advanced spell mechanics (e.g., aim, spread, multiple projectiles).
- Dynamic enemy spawns (e.g., spawn behind the camera view, inspired by *Deep Rock Galactic: Survivor*).

---

## Minimal Requirements
- Unity version: `2022.x.x` (or later)
- **Assets**: Project uses minimal art assets, with most functionality driven programmatically.

---

## How to Play
- **Movement/Rotation**: WASD / Arrow keys
- **Cast Spell**: `X` / Left Click
- **Change Spell**: `Q` / `E`

---

**Note:** This project is a prototype and is intended as a demonstration of coding practices and principles.
