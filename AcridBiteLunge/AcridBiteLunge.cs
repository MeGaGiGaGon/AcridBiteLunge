using System.Security.Permissions;
using BepInEx;
using UnityEngine;

[assembly: SecurityPermission(SecurityAction.RequestMinimum, SkipVerification = true)]

namespace AcridBiteLunge
{
    [BepInPlugin("GiGaGon.AcridBiteLunge", "AcridBiteLunge", "1.1.0")]
    public class AcridBiteLunge : BaseUnityPlugin
    {
        public void Awake()
        {
            On.EntityStates.Croco.Bite.OnEnter += (orig, self) =>
            {
                orig(self);
                Vector3 direction = self.GetAimRay().direction;
                self.characterBody.isSprinting = true;
                Vector3 a = direction.normalized * 3f * self.moveSpeedStat;
                Vector3 b = Vector3.up * 2f;
                Vector3 b2 = new Vector3(direction.x, 0f, direction.z).normalized * 3f;
                self.characterMotor.Motor.ForceUnground();
                self.characterMotor.velocity = a + b + b2;
            };
        }
    }
}
