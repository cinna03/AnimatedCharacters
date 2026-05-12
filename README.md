# Mood Board — Interactive Character Experience

## Project Description

Mood Board is a Unity-based interactive character experience where users can control the emotional states of three animated characters through UI buttons and keyboard input. Each character responds to mood triggers with unique animations and corresponding audio feedback. The project features a clean three-screen UI flow, a centralized manager architecture, and a fully integrated audio system.

-----

## Project Theme

**Emotional / Mood-Based Character System**

Users select one of three characters and trigger emotional states (Happy, Sad, Angry) through button interactions and keyboard shortcuts. The UI dynamically updates to reflect the current character and mood state.

-----

## Controls & Interactions

### Keyboard Input

|Key|Action                 |
|---|-----------------------|
|`H`|Trigger Happy animation|
|`S`|Trigger Sad animation  |
|`A`|Trigger Angry animation|
|`1`|Switch to Character 1  |
|`2`|Switch to Character 2  |
|`3`|Switch to Character 3  |

### UI Input

|Element                    |Action                                     |
|---------------------------|-------------------------------------------|
|Start Button               |Navigate to Character Select screen        |
|Character 1 / 2 / 3 Buttons|Select and activate a character            |
|😊 Happy Button             |Trigger Happy animation on active character|
|😢 Sad Button               |Trigger Sad animation on active character  |
|😠 Angry Button             |Trigger Angry animation on active character|
|Volume Slider              |Adjust overall audio volume                |
|Mute Button                |Toggle all audio on/off                    |
|← Back Button              |Return to Character Select screen          |

-----

## UI Screens

|Screen                     |Description                                                         |
|---------------------------|--------------------------------------------------------------------|
|**Home Screen**            |Title screen with a Start button to begin the experience            |
|**Character Select Screen**|Choose one of three characters to control                           |
|**Interaction Screen**     |Trigger moods, control audio, and view live character and mood state|

Screens use animated slide transitions when navigating between them.

-----

## System Architecture

### GameManager.cs

The central brain of the project. Tracks which character is currently active, routes mood trigger calls to the correct character, and coordinates communication between the UI and Audio systems. Implements a Singleton pattern to allow global access across all scripts.

### UIManager.cs

Handles all UI screen transitions and dynamic text updates. Controls which screen is visible at any given time, fires the SlideIn animation trigger on transitions, and updates the Character Name and Mood text fields in real time based on system state.

### AudioManager.cs

Manages all audio in the project. Maintains two separate Audio Sources — one for background/ambient music and one for SFX. Plays character-specific theme music when a character is selected and mood-specific sound effects when an animation is triggered. Exposes volume and mute controls to the UI.

### CharacterController.cs

Attached to each individual character. Handles all direct Animator communication — resetting and firing trigger parameters when a mood is activated. Each character uses either the base Animator Controller or an Animator Override Controller with its own unique animation clips.

-----

## Character Animation Setup

Each character has the following animation states in their Animator Controller:

|State|Trigger Parameter                |
|-----|---------------------------------|
|Idle |Default state (no trigger needed)|
|Happy|`Happy` (Trigger)                |
|Sad  |`Sad` (Trigger)                  |
|Angry|`Angry` (Trigger)                |

**Parameter types used:** Trigger, Bool (`IsActive`)

Transitions from Idle to mood states fire on trigger with no exit time. Return transitions to Idle use exit time (0.9) with no conditions, so the animation completes naturally before returning.

Characters 2 and 3 use **Animator Override Controllers** based on the base controller, allowing each character to have unique animation clips while sharing the same transition logic.

-----

## Folder Structure

```
Assets/
  _Scenes/
  Animations/
  Animators/
  Audio/
  Materials/
  Prefabs/
  Scripts/
    Managers/
      GameManager.cs
      AudioManager.cs
      UIManager.cs
      CharacterController.cs
  Textures/
  UI/
```

-----

## How to Run

1. Open the project in **Unity 2022.3 or later**
1. Open the scene in `Assets/_Scenes/`
1. Press **Play** in the Unity Editor
1. Use the Start button or keyboard controls to begin interacting
