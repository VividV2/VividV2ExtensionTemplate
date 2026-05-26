using System;
using System.Collections.Generic;
using System.Text;
using VividV2.Classes;

namespace VividV2ExtensionTemplate.Mods.Animations.Open
{
    public class ExampleOpenAnimation : MenuAnimation
    {
        public ExampleOpenAnimation() : base("ExampleOpenAnimation", VividV2.Classes.Enums.MenuAnimationType.MenuOpen)
        {
        }

        public override MenuAnimator Animate(float AnimationPercentage, MenuAnimator target)
        {
            target.Scale = target.Scale - (target.Scale * (1 - AnimationPercentage));

            return target;
        }
    }
}
