using CriFs.V2.Hook;
using CriFs.V2.Hook.Interfaces;
using My_Reloaded_II_Mod1.Configuration;
using My_Reloaded_II_Mod1.Template;
using Reloaded.Hooks.ReloadedII.Interfaces;
using Reloaded.Mod.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;

namespace My_Reloaded_II_Mod1
{
	public class Mod : ModBase
	{
		private readonly IModLoader _modLoader;
		private readonly IReloadedHooks? _hooks;
		private readonly ILogger _logger;
		private readonly IMod _owner;
		private Config _configuration;
		private readonly IModConfig _modConfig;

		// Track the last played movie
		private static string _lastPlayedMovie;

		public Mod(ModContext context)
		{
			_modLoader = context.ModLoader;
			_hooks = context.Hooks;
			_logger = context.Logger;
			_owner = context.Owner;
			_configuration = context.Configuration;
			_modConfig = context.ModConfig;

			var criFsController = _modLoader.GetController<ICriFsRedirectorApi>();
			if (criFsController == null || !criFsController.TryGetTarget(out var criFsApi))
			{
				_logger.WriteLine($"Unable to get controller for CriFs Lib, things will not work :(", System.Drawing.Color.Red);
				return;
			}

			// Create a list to hold the enabled movie options
			List<string> enabledMovies = new List<string>();

			// Check each bool and add the corresponding movie option to the list if enabled
			if (_configuration.NextChanceToMoveOn && _lastPlayedMovie != "NextChanceToMoveOn")
			{
				enabledMovies.Add("NextChanceToMoveOn");
			}

			if (_configuration.ShadowWorld && _lastPlayedMovie != "ShadowWorld")
			{
				enabledMovies.Add("ShadowWorld");
			}

			if (_configuration.SkysTheLimit && _lastPlayedMovie != "SkysTheLimit")
			{
				enabledMovies.Add("SkysTheLimit");
			}

			if (_configuration.KeyPlusWords && _lastPlayedMovie != "KeyPlusWords")
			{
				enabledMovies.Add("KeyPlusWords");
			}

			if (_configuration.KeyPlusWordsAltSubtitles && _lastPlayedMovie != "KeyPlusWordsAltSubtitles")
			{
				enabledMovies.Add("KeyPlusWordsAltSubtitles");
			}

			if (_configuration.ShadowWorldVanilla && _lastPlayedMovie != "ShadowWorldVanilla")
			{
				enabledMovies.Add("ShadowWorldVanilla");
			}

			if (_configuration.P4Intro && _lastPlayedMovie != "P4Intro")
			{
				enabledMovies.Add("P4Intro");
			}

			if (_configuration.Dance && _lastPlayedMovie != "Dance")
			{
				enabledMovies.Add("Dance");
			}

			if (_configuration.P4AU && _lastPlayedMovie != "P4AU")
			{
				enabledMovies.Add("P4AU");
			}

			if (_configuration.P4A && _lastPlayedMovie != "P4A")
			{
				enabledMovies.Add("P4A");
			}

			if (_configuration.PQ && _lastPlayedMovie != "PQ")
			{
				enabledMovies.Add("PQ");
			}

			if (_configuration.PQ2 && _lastPlayedMovie != "PQ2")
			{
				enabledMovies.Add("PQ2");
			}

			// Randomly select a movie from the enabled options
			if (enabledMovies.Count > 0)
			{
				Random random = new Random();
				string selectedMovie = enabledMovies[random.Next(0, enabledMovies.Count)];
				_lastPlayedMovie = selectedMovie; // Update the last played movie
				criFsApi.AddProbingPath(selectedMovie);
			}
		}

		#region Standard Overrides
		public override void ConfigurationUpdated(Config configuration)
		{
			_configuration = configuration;
			_logger.WriteLine($"[{_modConfig.ModId}] Config Updated: Applying");
		}
		#endregion

		#region For Exports, Serialization etc.
		public Mod() { }
		#endregion
	}
}
