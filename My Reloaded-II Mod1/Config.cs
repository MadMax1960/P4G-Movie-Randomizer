using My_Reloaded_II_Mod1.Template.Configuration;
using Reloaded.Mod.Interfaces.Structs;
using System.ComponentModel;

namespace My_Reloaded_II_Mod1.Configuration
{
	public class Config : Configurable<Config>
	{
		/*
			User Properties:
				- Please put all of your configurable properties here.

			By default, configuration saves as "Config.json" in mod user config folder.    
			Need more config files/classes? See Configuration.cs

			Available Attributes:
			- Category
			- DisplayName
			- Description
			- DefaultValue

			// Technically Supported but not Useful
			- Browsable
			- Localizable

			The `DefaultValue` attribute is used as part of the `Reset` button in Reloaded-Launcher.
		*/

		[DisplayName("Next Chance to Move On")]
		[Description("Enable to play Peak.")]
		[DefaultValue(false)]
		public bool NextChanceToMoveOn { get; set; } = false;

		[DisplayName("Shadow World")]
		[Description("Enable to play Shadow World from Persona 4 Golden Animation.")]
		[DefaultValue(false)]
		public bool ShadowWorld { get; set; } = false;

		[DisplayName("Skys The Limit")]
		[Description("Enable to play Peak 2.")]
		[DefaultValue(false)]
		public bool SkysTheLimit { get; set; } = false;

		[DisplayName("Key Plus Words")]
		[Description("Enable to play Peak Key Plus Words.")]
		[DefaultValue(false)]
		public bool KeyPlusWords { get; set; } = false;

		[DisplayName("Key Plus Words Alt Subs")]
		[Description("Enable to play Key Plus Words with Alt Subs.")]
		[DefaultValue(false)]
		public bool KeyPlusWordsAltSubtitles { get; set; } = false;

		[DisplayName("Vanilla Shadow World")]
		[Description("Enable to play Good Song :).")]
		[DefaultValue(false)]
		public bool ShadowWorldVanilla { get; set; } = false;

		[DisplayName("Pursuing My True Self")]
		[Description("Enable to play Pursuing My True Self.")]
		[DefaultValue(false)]
		public bool P4Intro { get; set; } = false;

		[DisplayName("Dance!")]
		[Description("Enable to play P4D Intro, Dance!")]
		[DefaultValue(false)]
		public bool Dance { get; set; } = false;

		[DisplayName("P4AU")]
		[Description("Enable to play P4AU Intro.")]
		[DefaultValue(false)]
		public bool P4AU { get; set; } = false;

		[DisplayName("P4A")]
		[Description("Enable to play P4A Intro.")]
		[DefaultValue(false)]
		public bool P4A { get; set; } = false;

		[DisplayName("PQ")]
		[Description("Enable to play PQ Intro.")]
		[DefaultValue(false)]
		public bool PQ { get; set; } = false;

		[DisplayName("PQ2")]
		[Description("Enable to play PQ2 Intro.")]
		[DefaultValue(false)]
		public bool PQ2 { get; set; } = false;

		[DisplayName("Enum")]
		[Description("This is an enumerable.")]
		[DefaultValue(SampleEnum.Normal)]
		public SampleEnum Reloaded { get; set; } = SampleEnum.Normal;

		public enum SampleEnum
		{
			Normal,
			Random,
		}
	}

	/// <summary>
	/// Allows you to override certain aspects of the configuration creation process (e.g. create multiple configurations).
	/// Override elements in <see cref="ConfiguratorMixinBase"/> for finer control.
	/// </summary>
	public class ConfiguratorMixin : ConfiguratorMixinBase
	{
		// 
	}
}