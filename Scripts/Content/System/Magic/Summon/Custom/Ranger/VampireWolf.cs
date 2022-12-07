using Server.Items;

using System;

namespace Server.Mobiles
{
	[CorpseName("a vampire wolf corpse")]
	public class VampireWolfFamiliar : BaseFamiliar
	{
		private DateTime m_NextFlare;

		public override bool AutoDispel => true;

		public override Poison HitPoison => Poison.Greater;

		public VampireWolfFamiliar()
		{
			Name = "a vampire wolf";
			Body = 98;
			Hue = 137;
			BaseSoundID = 229;

			SetStr(110, 115);
			SetDex(100);
			SetInt(60);

			SetHits(80, 105);
			SetStam(70);
			SetMana(0);

			SetDamage(15, 30);

			SetDamageType(ResistanceType.Fire, 100);

			SetResistance(ResistanceType.Physical, 70);
			SetResistance(ResistanceType.Fire, 70);
			SetResistance(ResistanceType.Cold, 70);
			SetResistance(ResistanceType.Poison, 70);
			SetResistance(ResistanceType.Energy, 70);

			SetSkill(SkillName.Wrestling, 70.0);
			SetSkill(SkillName.Tactics, 70.0);

			ControlSlots = 1;

			AddItem(new LightSource());
		}

		public VampireWolfFamiliar(Serial serial)
			: base(serial)
		{
		}

		public override void OnThink()
		{
			base.OnThink();

			if (DateTime.Now < m_NextFlare)
			{
				return;
			}

			m_NextFlare = DateTime.UtcNow.AddSeconds(5.0 + (25.0 * Utility.RandomDouble()));

			FixedEffect(0x37C4, 1, 12, 1109, 6);
			PlaySound(230);

			_ = Timer.DelayCall(TimeSpan.FromSeconds(0.5), Flare);
		}

		private void Flare()
		{
			var caster = GetMaster();

			if (caster == null)
			{
				return;
			}

			var eable = GetMobilesInRange(5);

			foreach (var m in eable)
			{
				if (m.Player && m.Alive && !m.IsDeadBondedPet && m.Karma <= 0)
				{
					var friendly = true;

					for (var j = 0; friendly && j < caster.Aggressors.Count; ++j)
					{
						friendly = caster.Aggressors[j].Attacker != m;
					}

					for (var j = 0; friendly && j < caster.Aggressed.Count; ++j)
					{
						friendly = caster.Aggressed[j].Defender != m;
					}

					if (friendly)
					{
						m.FixedEffect(0x37C4, 1, 12, 1109, 3); // At player
						m.Mana += 1 - (m.Karma / 1000);
					}
				}
			}

			eable.Free();
		}

		public override void Serialize(GenericWriter writer)
		{
			base.Serialize(writer);

			writer.Write(0);
		}

		public override void Deserialize(GenericReader reader)
		{
			base.Deserialize(reader);

			_ = reader.ReadInt();
		}
	}
}
