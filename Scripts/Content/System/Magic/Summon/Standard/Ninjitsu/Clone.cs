using Server.Items;
using Server.Spells;
using Server.Spells.Ninjitsu;

using System;

namespace Server.Mobiles
{
	public class Clone : BaseCreature
	{
		private static Item CloneItem(Item item)
		{
			return new Item(item.ItemID)
			{
				Movable = false,
				Name = item.Name,
				Hue = item.Hue,
				Layer = item.Layer
			};
		}

		private Mobile m_Caster;

		private BaseAI m_CloneAI;

		protected override BaseAI ForcedAI => m_CloneAI ??= new InternalAI(this);

		public override bool DeleteCorpseOnDeath => true;

		public override bool IsDispellable => false;
		public override bool Commandable => false;

		public Clone(Serial serial)
			: base(serial)
		{
		}

		public Clone(Mobile caster)
			: base(AIType.AI_Melee, FightMode.None, 10, 1, 0.2, 0.4)
		{
			m_Caster = caster;

			Body = caster.Body;

			Hue = caster.Hue;
			Female = caster.Female;

			Name = caster.Name;
			NameHue = caster.NameHue;

			Title = caster.Title;
			Kills = caster.Kills;

			HairItemID = caster.HairItemID;
			HairHue = caster.HairHue;

			FacialHairItemID = caster.FacialHairItemID;
			FacialHairHue = caster.FacialHairHue;

			for (var i = 0; i < caster.Skills.Length; ++i)
			{
				Skills[i].Base = caster.Skills[i].Base;
				Skills[i].Cap = caster.Skills[i].Cap;
			}

			for (var i = 0; i < caster.Items.Count; i++)
			{
				AddItem(CloneItem(caster.Items[i]));
			}

			Warmode = true;

			Summoned = true;
			SummonMaster = caster;

			ControlOrder = OrderType.Follow;
			ControlTarget = caster;

			var duration = TimeSpan.FromSeconds(30 + caster.Skills.Ninjitsu.Fixed / 40);

			SummonEnd = DateTime.UtcNow + duration;

			var t = new UnsummonTimer(this, duration);

			t.Start();

			MirrorImageSpell.AddClone(m_Caster);
		}

		public override bool IsHumanInTown()
		{
			return false;
		}

		public override void OnDamage(int amount, Mobile from, bool willKill)
		{
			Delete();
		}

		public override void OnDelete()
		{
			Effects.SendLocationParticles(EffectItem.Create(Location, Map, EffectItem.DefaultDuration), 0x3728, 10, 15, 5042);

			base.OnDelete();
		}

		public override void OnAfterDelete()
		{
			MirrorImageSpell.RemoveClone(m_Caster);

			base.OnAfterDelete();
		}

		public override void Serialize(GenericWriter writer)
		{
			base.Serialize(writer);

			writer.WriteEncodedInt(0); // version

			writer.Write(m_Caster);
		}

		public override void Deserialize(GenericReader reader)
		{
			base.Deserialize(reader);

			_ = reader.ReadEncodedInt();

			m_Caster = reader.ReadMobile();

			MirrorImageSpell.AddClone(m_Caster);
		}

		private class InternalAI : BaseAI
		{
			public override bool CanDetectHidden => false;

			public InternalAI(Clone m)
				: base(m)
			{
				m.CurrentSpeed = m.ActiveSpeed;
			}

			public override bool Think()
			{
				// Clones only follow their owners
				var master = m_Mobile.SummonMaster;

				if (master != null && master.Map == m_Mobile.Map && master.InRange(m_Mobile, m_Mobile.RangePerception))
				{
					var iCurrDist = (int)m_Mobile.GetDistanceToSqrt(master);
					var bRun = (iCurrDist > 5);

					WalkMobileRange(master, 2, bRun, 0, 1);
				}
				else
				{
					WalkRandom(2, 2, 1);
				}

				return true;
			}
		}
	}
}
