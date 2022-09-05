using Server.Commands;
using Server.Commands.Generic;
using Server.Factions;
using Server.Items;
using Server.Misc;
using Server.Network;

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Server.Mobiles
{
	public abstract class BaseGuildmaster : BaseVendor
	{
		private readonly List<SBInfo> m_SBInfos = new List<SBInfo>();
		protected override List<SBInfo> SBInfos => m_SBInfos;

		public override bool IsActiveVendor => false;

		public override bool ClickTitle => false;

		public virtual int JoinCost => 500;

		public virtual TimeSpan JoinAge => TimeSpan.FromDays(0.0);
		public virtual TimeSpan JoinGameAge => TimeSpan.FromDays(2.0);
		public virtual TimeSpan QuitAge => TimeSpan.FromDays(7.0);
		public virtual TimeSpan QuitGameAge => TimeSpan.FromDays(4.0);

		public override void InitSBInfo()
		{
		}

		public virtual bool CheckCustomReqs(PlayerMobile pm)
		{
			return true;
		}

		public virtual void SayGuildTo(Mobile m)
		{
			SayTo(m, 1008055 + (int)NpcGuild);
		}

		public virtual void SayWelcomeTo(Mobile m)
		{
			SayTo(m, 1008054); // Welcome to the guild! Thou shalt find that fellow members shall grant thee lower prices in shops.
		}

		public virtual void SayPriceTo(Mobile m)
		{
			m.Send(new MessageLocalizedAffix(Serial, Body, MessageType.Regular, SpeechHue, 3, 1008052, Name, AffixType.Append, JoinCost.ToString(), ""));
		}

		public virtual bool WasNamed(string speech)
		{
			var name = Name;

			return (name != null && Insensitive.StartsWith(speech, name));
		}

		public override bool HandlesOnSpeech(Mobile from)
		{
			if (from.InRange(Location, 2))
			{
				return true;
			}

			return base.HandlesOnSpeech(from);
		}

		public override void OnSpeech(SpeechEventArgs e)
		{
			var from = e.Mobile;

			if (!e.Handled && from is PlayerMobile && from.InRange(Location, 2) && WasNamed(e.Speech))
			{
				var pm = (PlayerMobile)from;

				if (e.HasKeyword(0x0004)) // *join* | *member*
				{
					if (pm.NpcGuild == NpcGuild)
					{
						SayTo(from, 501047); // Thou art already a member of our guild.
					}
					else if (pm.NpcGuild != NpcGuild.None)
					{
						SayTo(from, 501046); // Thou must resign from thy other guild first.
					}
					else if (pm.GameTime < JoinGameAge || (pm.CreationTime + JoinAge) > DateTime.UtcNow)
					{
						SayTo(from, 501048); // You are too young to join my guild...
					}
					else if (CheckCustomReqs(pm))
					{
						SayPriceTo(from);
					}

					e.Handled = true;
				}
				else if (e.HasKeyword(0x0005)) // *resign* | *quit*
				{
					if (pm.NpcGuild != NpcGuild)
					{
						SayTo(from, 501052); // Thou dost not belong to my guild!
					}
					else if ((pm.NpcGuildJoinTime + QuitAge) > DateTime.UtcNow || (pm.NpcGuildGameTime + QuitGameAge) > pm.GameTime)
					{
						SayTo(from, 501053); // You just joined my guild! You must wait a week to resign.
					}
					else
					{
						SayTo(from, 501054); // I accept thy resignation.
						pm.NpcGuild = NpcGuild.None;
					}

					e.Handled = true;
				}
			}

			base.OnSpeech(e);
		}

		public override bool OnGoldGiven(Mobile from, Gold dropped)
		{
			if (from is PlayerMobile && dropped.Amount == JoinCost)
			{
				var pm = (PlayerMobile)from;

				if (pm.NpcGuild == NpcGuild)
				{
					SayTo(from, 501047); // Thou art already a member of our guild.
				}
				else if (pm.NpcGuild != NpcGuild.None)
				{
					SayTo(from, 501046); // Thou must resign from thy other guild first.
				}
				else if (pm.GameTime < JoinGameAge || (pm.CreationTime + JoinAge) > DateTime.UtcNow)
				{
					SayTo(from, 501048); // You are too young to join my guild...
				}
				else if (CheckCustomReqs(pm))
				{
					SayWelcomeTo(from);

					pm.NpcGuild = NpcGuild;
					pm.NpcGuildJoinTime = DateTime.UtcNow;
					pm.NpcGuildGameTime = pm.GameTime;

					dropped.Delete();
					return true;
				}

				return false;
			}

			return base.OnGoldGiven(from, dropped);
		}

		public BaseGuildmaster(string title) : base(title)
		{
			Title = String.Format("the {0} {1}", title, Female ? "guildmistress" : "guildmaster");
		}

		public BaseGuildmaster(Serial serial) : base(serial)
		{
		}

		public override void Serialize(GenericWriter writer)
		{
			base.Serialize(writer);

			writer.Write(0); // version
		}

		public override void Deserialize(GenericReader reader)
		{
			base.Deserialize(reader);

			var version = reader.ReadInt();
		}
	}

	#region Npc Guilds

	public enum NpcGuild
	{
		None,
		MagesGuild,
		WarriorsGuild,
		ThievesGuild,
		RangersGuild,
		HealersGuild,
		MinersGuild,
		MerchantsGuild,
		TinkersGuild,
		TailorsGuild,
		FishermensGuild,
		BardsGuild,
		BlacksmithsGuild
	}

	[Parsable, PropertyObject]
	public sealed record NpcGuildInfo
	{
		private static readonly NpcGuild[] m_Values = Enum.GetValues<NpcGuild>();

		public static readonly string[] Names = new string[m_Values.Length];

		public static readonly NpcGuildInfo[] Guilds = new NpcGuildInfo[m_Values.Length];

		public static readonly NpcGuildInfo None = new(0);

		public static string FilePath => Path.Combine(Core.CurrentSavesDirectory, "NpcGuilds", "NpcGuildInfo.bin");

		static NpcGuildInfo()
		{
			Guilds[0] = None;
			Names[0] = None.Name;

			for (var i = 1; i < Guilds.Length; i++)
			{
				var info = new NpcGuildInfo(m_Values[i]);

				Guilds[i] = info;
				Names[i] = info.Name;
			}
		}

		[CallPriority(Int32.MinValue + 10)]
		public static void Configure()
		{
			CommandSystem.Register("NpcGuilds", AccessLevel.Administrator, e =>
			{
				var guilds = Guilds.Skip(1);

				e.Mobile.SendGump(new InterfaceGump(e.Mobile, guilds));
			});

			EventSink.WorldSave += OnSave;
			EventSink.WorldLoad += OnLoad;
		}

		public static bool TryParse(string input, out NpcGuildInfo value)
		{
			try
			{
				value = Parse(input);
				return true;
			}
			catch
			{
				value = None;
				return false;
			}
		}

		public static NpcGuildInfo Parse(string input)
		{
			return Guilds.Single(info => Insensitive.Equals(info.Name, input));
		}

		public static NpcGuildInfo Find(BaseVendor vendor)
		{
			if (vendor?.Deleted == false)
			{
				return Find(vendor.NpcGuild);
			}

			return None;
		}

		public static NpcGuildInfo Find(PlayerMobile player)
		{
			if (player?.Deleted == false)
			{
				return Find(player.NpcGuild);
			}

			return None;
		}

		public static NpcGuildInfo Find(NpcGuild guild)
		{
			if (Enum.IsDefined(guild))
			{
				return Find(Convert.ToInt32(guild));
			}

			return None;
		}

		public static NpcGuildInfo Find(int id)
		{
			if (id >= 0 && id < Guilds.Length)
			{
				return Guilds[id];
			}

			return None;
		}

		public static void WriteReference(GenericWriter writer, NpcGuildInfo guild)
		{
			writer.Write(guild?.Guild ?? NpcGuild.None);
		}

		public static NpcGuildInfo ReadReference(GenericReader reader)
		{
			return Find(reader.ReadEnum<NpcGuild>());
		}

		private static void OnSave(WorldSaveEventArgs e)
		{
			Persistence.Serialize(FilePath, OnSerialize);
		}

		private static void OnSerialize(GenericWriter writer)
		{
			writer.Write(0);

			writer.Write(Guilds.Length);

			for (var i = 0; i < Guilds.Length; i++)
			{
				if (i == 0)
				{
					continue;
				}

				var info = Guilds[i];

				info.Serialize(writer);
			}
		}

		private static void OnLoad()
		{
			Persistence.Deserialize(FilePath, OnDeserialize);
		}

		private static void OnDeserialize(GenericReader reader)
		{
			reader.ReadInt();

			var count = reader.ReadInt();

			for (var i = 0; i < count; i++)
			{
				if (i == 0)
				{
					continue;
				}

				var info = i < Guilds.Length ? Guilds[i] : new NpcGuildInfo(0);

				info.Deserialize(reader);
			}
		}

		[CommandProperty(AccessLevel.Counselor, true)]
		public NpcGuild Guild { get; init; }

		private string m_Name;

		[CommandProperty(AccessLevel.Counselor, true)]
		public string Name => m_Name ??= $"{Guild}".Replace("Guild", " Guild");

		private int m_VendorDiscount;

		[CommandProperty(AccessLevel.Counselor, AccessLevel.Administrator)]
		public int VendorDiscount { get => m_VendorDiscount; set => m_VendorDiscount = Math.Clamp(value, 0, 100); }

		public NpcGuildReputationDefinition Reputation { get; }

		private NpcGuildInfo(NpcGuild guild)
		{
			Guild = guild;

			if (Guild != NpcGuild.None)
			{
				m_VendorDiscount = 10;
			}

			Reputation = new(this, Name); 
		}

		public override string ToString()
		{
			return Name;
		}

		private void Serialize(GenericWriter writer)
		{
			writer.WriteEncodedInt(0);

			writer.WriteEncodedInt(m_VendorDiscount);
		}

		private void Deserialize(GenericReader reader)
		{
			reader.ReadEncodedInt();

			m_VendorDiscount = reader.ReadEncodedInt();
		}
	}

	public class NpcGuildReputationDefinition : ReputationDefinition<NpcGuildInfo>
	{
		public NpcGuildReputationDefinition(NpcGuildInfo owner, string name, params int[] levels)
			: base(owner, ReputationCategory.Vendors, name, levels)
		{ }
	}

	#endregion
}