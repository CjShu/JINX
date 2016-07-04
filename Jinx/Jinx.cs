namespace Jinx
{
    #region

    using LeagueSharp;
    using LeagueSharp.Common;
    using System;

    #endregion

    internal class Jinx
    {
        public static string ChampionName => "Jinx";
        public static void Init()
        {
            CustomEvents.Game.OnGameLoad += Game_OnGameLoad;
        }

        private static void Game_OnGameLoad(EventArgs args)
        {
            if (ObjectManager.Player.CharData.BaseSkinName != ChampionName)
            {
                return;
            }

            Champion.PlayerSpells.Init();
            Modes.ModeConfig.Init();
            Common.CommonItems.Init();

            Game.PrintChat("<font color='#DDDDFF'><b> Taiwan By: CjShu :) </b></font>");
            Game.PrintChat("<font color='#FF8EFF'><b> If you like.</font><font color='#96FED1'><b>Thank you my friend xQx. And NightMoon. Aid!</b></font>");
            Game.PrintChat(
                "<font color='#ff3232'>Successfully Loaded: </font><font color='#d4d4d4'><font color='#FFFFFF'>" +
                ChampionName + "</font>");

            Console.Clear();
        }
    }
}