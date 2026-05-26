# VividV2 Extension Template

![License](https://img.shields.io/badge/license-MIT-blue.svg)
![.NET](https://img.shields.io/badge/.NET-8.0-purple.svg)
![Status](https://img.shields.io/badge/status-template-green.svg)

A template for creating extensions, modules, and player modules for **VividV2**.

---

## Table of Contents

- Overview
- Modules
- Player Modules
- Categories
- Menu Animations
- Extension Manifest

---

## Overview

<details>
<summary>Expand Overview</summary>

This project demonstrates how to create:

- Modules
- Player Modules
- Categories
- Extension Manifests
- Variable systems (Float, Int, Bool, String, Color, Keybind)

</details>

---

# Modules

## Example Module

<details>
<summary>Expand Example Module</summary>

```csharp
internal class ExampleMod : Module
```

</details>

---

## Constructor

<details>
<summary>Expand Constructor</summary>

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

</details>

---

## Variables

<details>
<summary>Expand Variables</summary>

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
// Make sure to use the correct type when getting the variable, otherwise it will return null
GetVariable<FloatVariable>("Example Variable");
```

---

## Variable Types

### Bool Variable

```csharp
BoolVariable boolVariable = new BoolVariable("Bool Variable", true);
```

---

### Int Variable

```csharp
IntVariable intVariable = new IntVariable("Int Variable", 5, 0, 10);
```

---

### Float Variable

```csharp
FloatVariable floatVariable = new FloatVariable("Float Variable", 1.0f, 0.0f, 10.0f);
```

---

### String Variable

```csharp
StringVariable stringVariable = new StringVariable("String Variable", new string[] { "Option 1", "Option 2", "Option 3" });
```

---

### Color Variable

```csharp
ColorVariable colorVariable = new ColorVariable("Color Variable", new UnityEngine.Color(1f, 0f, 0f));
```

</details>

---

## Keybind Variables

<details>
<summary>Expand Keybind Variables</summary>

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
```

---

### Single Hand

```csharp
KeybindVariable keybindVariable2 = new KeybindVariable("Keybind Variable 2", KeybindType.SingleHand);
```

```csharp
// Requires specific hand + button match
```

---

### Joystick

```csharp
KeybindVariable joystickVariable = new KeybindVariable("Joystick Variable", KeybindType.Joystick, HandType.Right);
```

```csharp
// JoystickValue.x = horizontal movement
// JoystickValue.y = vertical movement
```

</details>

---

## Module Lifecycle

<details>
<summary>Expand Module Lifecycle</summary>

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

</details>

---

## Useful Methods

<details>
<summary>Expand Useful Methods</summary>

```csharp
// SetEnabled -> enable/disable module
// Logger.Log / Logger.LogError -> logging system
// IMPORTANT: use VividV2.Core.Logger not BepInEx logger
```

</details>

---

# Player Modules

<details>
<summary>Expand Player Modules</summary>

## TeleportToPlayer

```csharp
internal class TeleportToPlayer : PlayerModule
```

```csharp
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

</details>

---

# Categories

<details>
<summary>Expand Categories</summary>

```csharp
internal class Categories
```

```csharp
public static readonly Category Example = Category.Register("Example Category");
public static readonly Category Visual = Category.Register("Visual");
```

</details>

---

# Menu Animations

<details>
<summary>Expand Menu Animations</summary>

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

</details>

---

# Extension Manifest

<details>
<summary>Expand Extension Manifest</summary>

```csharp
internal class Manifest : ExtensionManifest
```

```csharp
public override string Name { get; set; } = "VividExtension";
public override string Version { get; set; } = "1.0.0";
```

</details>

