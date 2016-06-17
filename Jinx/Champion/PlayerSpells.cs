using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LeagueSharp;
using LeagueSharp.Common;
using Jinx.Common;
using SharpDX;

namespace Jinx.Champion
{
    internal static class PlayerSpells
    {
        public static List<Spell> SpellList = new List<Spell>();

        public static Spell Q, W, E, R;

        public static void Init()
        {
            Q = new Spell(SpellSlot.Q);

            W = new Spell(SpellSlot.W, 1500f);
            W.SetSkillshot(0.6f, 60f, 3300f, true, SkillshotType.SkillshotLine);
            

            E = new Spell(SpellSlot.E, 900f);
            E.SetSkillshot(0.7f, 120f, 1750f, false, SkillshotType.SkillshotCircle);

            R = new Spell(SpellSlot.R, 25000f);
            R.SetSkillshot(0.6f, 140f, 1700f, false, SkillshotType.SkillshotLine);

            SpellList.AddRange(new[] { Q, W, E, R });
        }


        public static void CastQObjects(Obj_AI_Base t)
        {
            if (!Q.CanCast(t))
            {
                return;
            }

                Q.CastOnUnit(t);
        }

        public static void CastQCombo(Obj_AI_Base t)
        {
            //if (!Common.CommonHelper.ShouldCastSpell(TargetSelector.GetTarget(Orbwalking.GetRealAutoAttackRange(null) + 65)))
            //{
            //    Game.PrintChat("Shen Active!");
            //    return;
            //}

            if (!Q.CanCast(t))
            {
                return;
            }
        }

        //internal static void ELogic(Orbwalking.OrbwalkingMode currentMode)
        //{
        //    var eEnabled = menu.Item(string.Format("dz191." + MenuName + ".{0}.usee", currentMode).ToLowerInvariant()).GetValue<bool>();
        //    var eMana = menu.Item(string.Format("dz191." + MenuName + ".{0}.mm.e", currentMode).ToLowerInvariant()).GetValue<Slider>().Value;
        //    if (!Spells[SpellSlot.E].IsReady() || !eEnabled || ObjectManager.Player.ManaPercent < eMana)
        //    {
        //        return;
        //    }

        //    var eTarget = orbwalker.GetTarget().IsValid<Obj_AI_Hero>() ? orbwalker.GetTarget() as Obj_AI_Hero : TargetSelector.GetTarget(Spells[SpellSlot.E].Range, TargetSelector.DamageType.Physical);
        //    if (!eTarget.IsValidTarget() || eTarget == null)
        //    {
        //        return;
        //    }

        //    var onlyESlowed = menu.Item("dz191." + MenuName + ".settings.e.onlyslow").GetValue<bool>();
        //    var onlyEStunned = menu.Item("dz191." + MenuName + ".settings.e.onlyimm").GetValue<bool>();
        //    var eHitchance = GetHitchanceFromMenu("dz191." + MenuName + ".settings.e.hitchance");

        //    var isTargetSlowed = IsLightlyImpaired(eTarget);
        //    var isTargetImmobile = IsHeavilyImpaired(eTarget);
        //    if ((isTargetSlowed && onlyESlowed) || (isTargetImmobile && onlyEStunned))
        //    {
        //        if (isTargetSlowed && eTarget.Path.Count() > 1)
        //        {
        //            var slowEndTime = GetSlowEndTime(eTarget);
        //            if (slowEndTime >= Spells[SpellSlot.E].Delay + 0.5f + Game.Ping / 2f)
        //            {
        //                Spells[SpellSlot.E].CastIfHitchanceEquals(eTarget, eHitchance);
        //            }
        //        }

        //        if (isTargetImmobile)
        //        {
        //            var immobileEndTime = GetImpairedEndTime(eTarget);
        //            if (immobileEndTime >= Spells[SpellSlot.E].Delay + 0.5f + Game.Ping / 2f)
        //            {
        //                Spells[SpellSlot.E].CastIfHitchanceEquals(eTarget, eHitchance);
        //            }
        //        }
        //    }
        //}

        //internal static void RLogic(Orbwalking.OrbwalkingMode currentMode)
        //{
        //    var rEnabled = menu.Item("dz191." + MenuName + ".combo.user").GetValue<bool>();
        //    if (!Spells[SpellSlot.R].IsReady() || !rEnabled)
        //    {
        //        return;
        //    }

        //    var rMana = menu.Item("dz191." + MenuName + ".combo.mm.r").GetValue<Slider>().Value;
        //    var rTarget = TargetSelector.GetTarget(Spells[SpellSlot.R].Range, TargetSelector.DamageType.Physical);

        //    if (!rTarget.IsValidTarget(Spells[SpellSlot.R].Range) || !Spells[SpellSlot.R].CanCast(rTarget) || ObjectManager.Player.ManaPercent < rMana)
        //    {
        //        return;
        //    }

        //    var aaBuffer = menu.Item("dz191." + MenuName + ".settings.r.aa").GetValue<Slider>().Value;
        //    var wDamageBuffer = 0f;
        //    var aaDamageBuffer = 0f;
        //    var minRange = menu.Item("dz191." + MenuName + ".settings.r.minrange").GetValue<Slider>().Value;
        //    var wEnabled = menu.Item(string.Format("dz191." + MenuName + ".{0}.usew", currentMode).ToLowerInvariant()).GetValue<bool>();
        //    var qEnabled = menu.Item(string.Format("dz191." + MenuName + ".{0}.useq", currentMode).ToLowerInvariant()).GetValue<bool>();
        //    var currentDistance = rTarget.Distance(ObjectManager.Player.ServerPosition);
        //    if (currentDistance >= minRange)
        //    {
        //        if (currentDistance <= Spells[SpellSlot.W].Range && Spells[SpellSlot.W].CanCast(rTarget) && wEnabled && menu.Item("dz191." + MenuName + ".settings.r.preventoverkill").GetValue<bool>())
        //        {
        //            var wHitchance = GetHitchanceFromMenu("dz191." + MenuName + ".settings.w.hitchance");
        //            var wPrediction = Spells[SpellSlot.W].GetPrediction(rTarget);
        //            if (wPrediction.Hitchance >= wHitchance)
        //            {
        //                wDamageBuffer = Spells[SpellSlot.W].GetDamage(rTarget);
        //            }
        //        }

        //        if (currentDistance < GetMinigunRange(rTarget) + GetFishboneRange() && Spells[SpellSlot.Q].IsReady() &&
        //            !ObjectManager.Player.Spellbook.IsAutoAttacking && ObjectManager.Player.CanAttack && qEnabled && menu.Item("dz191." + MenuName + ".settings.r.preventoverkill").GetValue<bool>())
        //        {
        //            aaDamageBuffer = (float)(ObjectManager.Player.GetAutoAttackDamage(rTarget) * aaBuffer);
        //        }

        //        var targetPredictedHealth = rTarget.Health + 20;
        //        if (targetPredictedHealth > wDamageBuffer + aaDamageBuffer &&
        //            targetPredictedHealth <= Spells[SpellSlot.R].GetDamage(rTarget))
        //        {
        //            var rHitchance = GetHitchanceFromMenu("dz191." + MenuName + ".settings.r.hitchance");
        //            Spells[SpellSlot.R].CastIfHitchanceEquals(rTarget, rHitchance);
        //        }
        //    }
        //}
    }
}
