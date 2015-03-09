﻿using System;
using System.Collections.Generic;
using System.Linq;
using LeagueSharp;
using LeagueSharp.Common;
using SharpDX;
using Color = System.Drawing.Color;

namespace TurboGnar
{
    class Program
    {
        public const string ChampName = "Gnar";
        public static Menu Config;
        public static Orbwalking.Orbwalker Orbwalker;
        public static Spell Q, W, E, R;
        public static Spell Q1, W1, E1, R1;
        private static readonly Obj_AI_Hero player = ObjectManager.Player;

        static void Main(string[] args)
        {
            CustomEvents.Game.OnGameLoad += OnLoad;
        }

        private static void OnLoad(EventArgs args)
        {
            if (player.ChampionName != ChampName)
                return;
            Notifications.AddNotification("TurboGnar - [V1.1.1.1]", 10000);

            Q = new Spell(SpellSlot.Q, 1100);
            W = new Spell(SpellSlot.W);
            E = new Spell(SpellSlot.E, 475);
            R = new Spell(SpellSlot.R);
            
            Q1 = new Spell(SpellSlot.Q, 1100);
            W1 = new Spell(SpellSlot.W, 525);
            E1 = new Spell(SpellSlot.E, 475);
            R1 = new Spell(SpellSlot.R, 420);

            Q.SetSkillshot(0.25f, 60, 1200, true, SkillshotType.SkillshotLine);
            E.SetSkillshot(0.5f, 150, float.MaxValue, false, SkillshotType.SkillshotCircle);

            
            Q1.SetSkillshot(0.25f, 80, 1200, true, SkillshotType.SkillshotLine);
            W1.SetSkillshot(0.25f, 80, float.MaxValue, false, SkillshotType.SkillshotLine);
            E1.SetSkillshot(0.5f, 150, float.MaxValue, false, SkillshotType.SkillshotCircle);
            R1.Delay = 0.25f;

            Config = new Menu("TurboGnar", "TG", true);
            Orbwalker = new Orbwalking.Orbwalker(Config.AddSubMenu(new Menu("[TA]: Orbwalker", "Orbwalker")));
            TargetSelector.AddToMenu(Config.AddSubMenu(new Menu("[TA]: Target Selector", "Target Selector")));

            var combo = Config.AddSubMenu(new Menu("[TG]: Combo Settings", "Combo Settings"));
            var harass = Config.AddSubMenu(new Menu("[TG]: Harass Settings", "Harass Settings"));
            var killsteal = Config.AddSubMenu(new Menu("[TG]: Killsteal Settings", "Killsteal Settings"));
            var laneclear = Config.AddSubMenu(new Menu("[TG]: Laneclear Settings", "Laneclear Settings"));
            var jungleclear = Config.AddSubMenu(new Menu("[TG]: Jungle Settings", "Jungle Settings"));
            var misc = Config.AddSubMenu(new Menu("[TG]: Misc Settings", "Misc Settings"));
            var drawing = Config.AddSubMenu(new Menu("[TG]: Draw Settings", "Draw Settings"));
            var debug = Config.AddSubMenu(new Menu("[TG]: Debug Settings", "debug"));
        }
    }
}
