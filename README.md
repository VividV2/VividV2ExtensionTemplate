# VividV2 Extension Template

![License](https://img.shields.io/badge/license-MIT-blue.svg)
![.NET](https://img.shields.io/badge/.NET-8.0-purple.svg)
![Status](https://img.shields.io/badge/status-template-green.svg)

A template for creating extensions, modules, and player modules for **VividV2**.

---

## Table of Contents

- Overview
- Modules
  - Example Module
  - Constructor
  - Variables
    - Adding Variables
    - Getting Variables
  - Variable Types
  - Keybind Variables
  - Adding Variables (Registration)
  - Module Lifecycle
  - Useful Methods
- Player Modules
- Categories
- Menu Animations
- Extension Manifest

---

## Overview

This project demonstrates how to create:

- Modules
- Player Modules
- Categories
- Extension Manifests
- Variable systems (Float, Int, Bool, String, Color, Keybind)

---

# Modules

## Example Module

```csharp
internal class ExampleMod : Module
```

---

## Constructor

```csharp
// to initialize the module do this
// the first string will be the name shown in the menu
// the second is the category, that is where the mod will be located
// the third bool is if it is toggleable, set to true to be toggleable or false to not be toggleable
// if it is toggleable OnEnable will be called each time it is pressed
// if it is toggleable OnDisable will never be called
// Update will will always be called no matter if it is or isnt toggleable

public ExampleMod() : base("Example", Categories.Example, true)
```

---

## Variables

### Adding Variables

```csharp
// to add variables first initialize the variable
// and the add it to the module by using AddVariable

FloatVariable exampleVariable = new FloatVariable("Example Variable", 1f, 0f, 10f);
AddVariable(exampleVariable);
```

---

### Getting Variables

```csharp
// WARNING: the name is case sensitive
GetVariable<FloatVariable>("Example Variable");
```

---

## Variable Types

### Bool Variable

```csharp
// Bool Variable
// First parameter is the name.
// Second parameter is the default value.

BoolVariable boolVariable = new BoolVariable("Bool Variable", true);
```

---

### Int Variable

```csharp
// Int Variable
// First parameter is the name.
// Second parameter is the default value.
// Third parameter is the minimum value.
// Fourth parameter is the maximum value.

IntVariable intVariable = new IntVariable("Int Variable", 5, 0, 10);
```

---

### Float Variable

```csharp
// Float Variable
// First parameter is the name.
// Second parameter is the default value.
// Third parameter is the minimum value.
// Fourth parameter is the maximum value.

FloatVariable floatVariable = new FloatVariable("Float Variable", 1.0f, 0.0f, 10.0f);
```

---

### String Variable

```csharp
// String Variable
// First parameter is the name.
// Second parameter is an array of options for the variable.
// The default value will be the first option in the array.

StringVariable stringVariable = new StringVariable("String Variable", new string[] { "Option 1", "Option 2", "Option 3" });
```

---

### Color Variable

```csharp
// Color Variable
// First parameter is the name.
// Second parameter is the default value using UnityEngine.Color.

ColorVariable colorVariable = new ColorVariable("Color Variable", new UnityEngine.Color(1f, 0f, 0f));
```

---

## Keybind Variables

### Overview

```csharp
// Keybind Variable types:
// KeybindType.Joystick
// KeybindType.BothHands
// KeybindType.SingleHand
```

---

### Both Hands

```csharp
KeybindVariable keybindVariable = new KeybindVariable("Keybind Variable", KeybindType.BothHands);
```

```csharp
// Lets the user select a button type only.
// The selected button will work on BOTH hands.
//
// Example:
// - Primary
// - Secondary
// - Grip
// - Trigger
//
// Pressed will return true if the selected button
// is pressed on either the left OR right hand.
//
// Example:
// If Button = Trigger:
// - Left Trigger pressed  -> true
// - Right Trigger pressed -> true
```

---

### Single Hand

```csharp
KeybindVariable keybindVariable2 = new KeybindVariable("Keybind Variable 2", KeybindType.SingleHand);
```

```csharp
// Lets the user select BOTH a hand and a button.
//
// Example values:
// - Left Trigger
// - Right Grip
// - Left Primary
//
// Pressed will only return true if the selected
// hand AND button are pressed.
//
// Example:
// If Value = Right Grip:
// - Right Grip pressed -> true
// - Left Grip pressed  -> false
```

---

### Joystick

```csharp
KeybindVariable joystickVariable = new KeybindVariable("Joystick Variable", KeybindType.Joystick, HandType.Right);
```

```csharp
// Lets the user select either the left or right joystick.
//
// The button parameter is ignored for this type.
//
// Use JoystickValue to get the Vector2 input.
//
// Example:
// JoystickValue.x = horizontal movement
// JoystickValue.y = vertical movement
```

---

## Adding Variables (Registration)

```csharp
AddVariable(boolVariable);
AddVariable(intVariable);
AddVariable(floatVariable);
AddVariable(stringVariable);
AddVariable(colorVariable);
AddVariable(keybindVariable);
AddVariable(keybindVariable2);
AddVariable(joystickVariable);
```

---

## Module Lifecycle

```csharp
public override void Update()
{
    if (Enabled)
    {
        // runs every frame
    }
}

public override void LateUpdate()
{
    if (Enabled)
    {
        // runs every LateUpdate frame
    }
}

public override void OnDisable()
{
}

public override void OnEnable()
{
}
```

---

## Useful Methods

```csharp
// SetEnabled -> enable/disable module
// Logger.Log / Logger.LogError -> logging system
// IMPORTANT: use VividV2.Core.Logger not BepInEx logger
```

---

# Player Modules

## TeleportToPlayer

```csharp
internal class TeleportToPlayer : PlayerModule
```

```csharp
// Player modules are per-player modules
public TeleportToPlayer() : base("Teleport To", false)
```

---

## OnEnable

```csharp
public override void OnEnable()
{
    GorillaLocomotion.GTPlayer.Instance.TeleportTo(targetRig.transform);
}
```

---

# Categories

```csharp
internal class Categories
```

```csharp
public static readonly Category Example = Category.Register("Example Category");
public static readonly Category Visual = Category.Register("Visual");
```

---

# Menu Animations

VividV2 supports custom menu animations for open and close transitions.

---

## Close Animation Example

```csharp
public class ExampleCloseAnimation : MenuAnimation
{
    public ExampleCloseAnimation()
        : base("Shrink", MenuAnimationType.MenuClose)
    {
    }

    public override MenuAnimator Animate(float AnimationPercentage, MenuAnimator target)
    {
        target.Scale = target.Scale - (target.Scale * (AnimationPercentage));
        return target;
    }
}
```

---

## Open Animation Example

```csharp
public class ExampleOpenAnimation : MenuAnimation
{
    public ExampleOpenAnimation()
        : base("ExampleOpenAnimation", MenuAnimationType.MenuOpen)
    {
    }

    public override MenuAnimator Animate(float AnimationPercentage, MenuAnimator target)
    {
        target.Scale = target.Scale - (target.Scale * (1 - AnimationPercentage));
        return target;
    }
}
```

---

### Animation Notes

- AnimationPercentage goes from 0 to 1
- target represents the UI transform state
- Modify scale, rotation, or position

---

# Extension Manifest

```csharp
internal class Manifest : ExtensionManifest
```

```csharp
public override string Name { get; set; } = "VividExtension";
public override string Version { get; set; } = "1.0.0";
```

