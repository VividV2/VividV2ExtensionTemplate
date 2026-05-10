using System;
using System.Collections.Generic;
using System.Text;
using VividV2.Classes.Buttons;

namespace VividV2ExtensionTemplate.Mods.Modules.Players
{
    internal class TeleportToPlayer : PlayerModule
    {
        // Player modules are the same as modules but are per player
        public TeleportToPlayer() : base("Teleport To", false) // the constructor is the same as normal modules but with only 2 parameters, the name and if it is toggleable
        {
            // you can add variables just like in normal modules
        }

        public override void OnEnable()
        {
            // target rig is the rig of the player you are using the mod on
            GorillaLocomotion.GTPlayer.Instance.TeleportTo(targetRig.transform);
        }
    }
}
