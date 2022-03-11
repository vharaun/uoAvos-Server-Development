using Server.Items;
using Server.Mobiles;

namespace Server.Commands
{
	public static partial class Decorate
	{
		public static partial class Ilshenar
		{
			public static DecorationList[] Lakeshire { get; } = Register(DecorationTarget.Ilshenar, "Lakeshire", new DecorationList[]
			{
				#region Entries
				
				new("Wooden Gate", typeof(DarkWoodGate), 2150, "Facing=WestCW", new DecorationEntry[]
				{
					new(1219, 1158, -26, ""),
					new(1221, 1158, -26, ""),
					new(1223, 1158, -26, ""),
				}),
				new("Wooden Gate", typeof(DarkWoodGate), 2154, "Facing=WestCCW", new DecorationEntry[]
				{
					new(1219, 1161, -26, ""),
					new(1222, 1161, -26, ""),
				}),
				new("Bed", typeof(Static), 2665, "", new DecorationEntry[]
				{
					new(1199, 1179, -25, ""),
					new(1224, 1136, -5, ""),
				}),
				new("Bed", typeof(Static), 2667, "Hue=0x541", new DecorationEntry[]
				{
					new(1200, 1179, -25, ""),
				}),
				new("Bed", typeof(Static), 2667, "Hue=0x59B", new DecorationEntry[]
				{
					new(1225, 1136, -5, ""),
				}),
				new("Table", typeof(Static), 2933, "", new DecorationEntry[]
				{
					new(1222, 1130, -25, ""),
					new(1222, 1134, -25, ""),
					new(1226, 1130, -25, ""),
					new(1226, 1134, -25, ""),
				}),
				new("Table", typeof(Static), 2934, "", new DecorationEntry[]
				{
					new(1222, 1129, -25, ""),
					new(1222, 1133, -25, ""),
					new(1226, 1129, -25, ""),
					new(1226, 1133, -25, ""),
				}),
				new("Broken Chair", typeof(Static), 3088, "", new DecorationEntry[]
				{
					new(1220, 1123, -25, ""),
					new(1223, 1130, -25, ""),
				}),
				new("Broken Chair", typeof(Static), 3089, "", new DecorationEntry[]
				{
					new(1203, 1174, -25, ""),
				}),
				new("Broken Armoire", typeof(Static), 3090, "", new DecorationEntry[]
				{
					new(1167, 1166, -25, ""),
					new(1218, 1150, -25, ""),
				}),
				new("Broken Armoire", typeof(Static), 3091, "", new DecorationEntry[]
				{
					new(1224, 1123, -25, ""),
					new(1228, 1123, -5, ""),
					new(1230, 1133, -5, ""),
				}),
				new("Ruined Bookcase", typeof(Static), 3092, "", new DecorationEntry[]
				{
					new(1222, 1123, -25, ""),
					new(1228, 1123, -25, ""),
				}),
				new("Ruined Bookcase", typeof(Static), 3093, "", new DecorationEntry[]
				{
					new(1167, 1162, -25, ""),
					new(1167, 1164, -25, ""),
					new(1199, 1176, -25, ""),
					new(1218, 1154, -25, ""),
					new(1224, 1134, -5, ""),
				}),
				new("Damaged Books", typeof(Static), 3094, "", new DecorationEntry[]
				{
					new(1167, 1163, -25, ""),
					new(1221, 1178, -25, ""),
					new(1223, 1124, -25, ""),
					new(1225, 1134, -5, ""),
				}),
				new("Covered Chair", typeof(Static), 3095, "", new DecorationEntry[]
				{
					new(1205, 1173, -25, ""),
				}),
				new("Broken Chair", typeof(Static), 3097, "", new DecorationEntry[]
				{
					new(1167, 1160, -25, ""),
					new(1218, 1153, -25, ""),
				}),
				new("Broken Chair", typeof(Static), 3098, "", new DecorationEntry[]
				{
					new(1226, 1131, -25, ""),
				}),
				new("Broken Chair", typeof(Static), 3099, "", new DecorationEntry[]
				{
					new(1199, 1173, -25, ""),
				}),
				new("Broken Chair", typeof(Static), 3100, "", new DecorationEntry[]
				{
					new(1221, 1175, -25, ""),
				}),
				new("Broken Clock", typeof(Static), 3103, "", new DecorationEntry[]
				{
					new(1199, 1177, -25, ""),
				}),
				new("Broken Dresser", typeof(Static), 3104, "", new DecorationEntry[]
				{
					new(1224, 1127, -5, ""),
				}),
				new("Broken Dresser", typeof(Static), 3105, "", new DecorationEntry[]
				{
					new(1224, 1126, -5, ""),
				}),
				new("Broken Dresser", typeof(Static), 3106, "", new DecorationEntry[]
				{
					new(1203, 1173, -25, ""),
				}),
				new("Broken Dresser", typeof(Static), 3107, "", new DecorationEntry[]
				{
					new(1202, 1173, -25, ""),
				}),
				new("Broken Furniture", typeof(Static), 3108, "", new DecorationEntry[]
				{
					new(1201, 1173, -25, ""),
					new(1229, 1123, -5, ""),
				}),
				new("Broken Furniture", typeof(Static), 3109, "", new DecorationEntry[]
				{
					new(1218, 1174, -25, ""),
				}),
				new("Ruined Bed", typeof(Static), 3113, "", new DecorationEntry[]
				{
					new(1226, 1123, -5, ""),
				}),
				new("Ruined Bed", typeof(Static), 3114, "", new DecorationEntry[]
				{
					new(1225, 1124, -5, ""),
				}),
				new("Ruined Bed", typeof(Static), 3115, "", new DecorationEntry[]
				{
					new(1224, 1125, -5, ""),
				}),
				new("Debris", typeof(Static), 3118, "", new DecorationEntry[]
				{
					new(1179, 1156, -25, ""),
					new(1221, 1182, -22, ""),
					new(1226, 1123, -25, ""),
					new(1226, 1133, -5, ""),
				}),
				new("Debris", typeof(Static), 3119, "", new DecorationEntry[]
				{
					new(1177, 1151, -25, ""),
					new(1177, 1163, -25, ""),
					new(1181, 1156, -25, ""),
					new(1205, 1175, -25, ""),
					new(1207, 1177, -25, ""),
					new(1226, 1126, -5, ""),
					new(1229, 1136, -5, ""),
				}),
				new("Debris", typeof(Static), 3120, "", new DecorationEntry[]
				{
					new(1167, 1167, -25, ""),
					new(1199, 1178, -25, ""),
					new(1232, 1129, -25, ""),
				}),
				new("Sheets", typeof(Static), 3123, "", new DecorationEntry[]
				{
					new(1223, 1176, -25, ""),
				}),
				new("Sheets", typeof(Static), 3124, "", new DecorationEntry[]
				{
					new(1222, 1176, -25, ""),
				}),
				new("Sheets", typeof(Static), 3125, "", new DecorationEntry[]
				{
					new(1223, 1174, -25, ""),
					new(1223, 1175, -25, ""),
				}),
				new("Sheets", typeof(Static), 3126, "", new DecorationEntry[]
				{
					new(1222, 1174, -25, ""),
					new(1222, 1175, -25, ""),
				}),
				new("Grasses", typeof(Static), 3244, "", new DecorationEntry[]
				{
					new(1208, 1159, -25, ""),
				}),
				new("Grasses", typeof(Static), 3245, "", new DecorationEntry[]
				{
					new(1196, 1163, -25, ""),
				}),
				new("Grasses", typeof(Static), 3247, "", new DecorationEntry[]
				{
					new(1208, 1174, -25, ""),
				}),
				new("Grasses", typeof(Static), 3248, "", new DecorationEntry[]
				{
					new(1204, 1164, -25, ""),
					new(1228, 1157, -25, ""),
				}),
				new("Grasses", typeof(Static), 3249, "", new DecorationEntry[]
				{
					new(1218, 1182, -25, ""),
					new(1220, 1139, -25, ""),
					new(1225, 1182, -25, ""),
					new(1226, 1139, -25, ""),
				}),
				new("Grasses", typeof(Static), 3251, "", new DecorationEntry[]
				{
					new(1230, 1150, -25, ""),
				}),
				new("Grasses", typeof(Static), 3253, "", new DecorationEntry[]
				{
					new(1214, 1185, -25, ""),
					new(1229, 1139, -25, ""),
				}),
				new("Grasses", typeof(Static), 3254, "", new DecorationEntry[]
				{
					new(1212, 1169, -25, ""),
					new(1219, 1135, -25, ""),
					new(1227, 1183, -25, ""),
				}),
				new("Vines", typeof(Static), 3307, "", new DecorationEntry[]
				{
					new(1223, 1182, -25, ""),
				}),
				new("Vines", typeof(Static), 3308, "", new DecorationEntry[]
				{
					new(1220, 1182, -25, ""),
					new(1221, 1182, -25, ""),
					new(1226, 1182, -25, ""),
				}),
				new("Vines", typeof(Static), 3309, "", new DecorationEntry[]
				{
					new(1218, 1182, -25, ""),
					new(1221, 1173, -25, ""),
					new(1224, 1182, -25, ""),
				}),
				new("Vines", typeof(Static), 3311, "", new DecorationEntry[]
				{
					new(1227, 1175, -25, ""),
				}),
				new("Vines", typeof(Static), 3312, "", new DecorationEntry[]
				{
					new(1227, 1176, -25, ""),
				}),
				new("Vines", typeof(Static), 3313, "", new DecorationEntry[]
				{
					new(1227, 1177, -25, ""),
				}),
				new("Apple Tree", typeof(Static), 3476, "", new DecorationEntry[]
				{
					new(1175, 1173, -25, ""),
					new(1180, 1177, -25, ""),
					new(1182, 1186, -25, ""),
				}),
				new("Apple Tree", typeof(Static), 3478, "", new DecorationEntry[]
				{
					new(1175, 1173, -25, ""),
					new(1180, 1177, -25, ""),
					new(1182, 1186, -25, ""),
				}),
				new("Apple Tree", typeof(Static), 3480, "", new DecorationEntry[]
				{
					new(1172, 1179, -25, ""),
					new(1175, 1187, -25, ""),
					new(1185, 1182, -25, ""),
				}),
				new("Apple Tree", typeof(Static), 3482, "", new DecorationEntry[]
				{
					new(1172, 1179, -25, ""),
					new(1175, 1187, -25, ""),
					new(1185, 1182, -25, ""),
				}),
				new("Peach Tree", typeof(Static), 3484, "", new DecorationEntry[]
				{
					new(1174, 1200, -25, ""),
					new(1175, 1192, -25, ""),
				}),
				new("Peach Tree", typeof(Static), 3486, "", new DecorationEntry[]
				{
					new(1174, 1200, -25, ""),
					new(1175, 1192, -25, ""),
				}),
				new("Pear Tree", typeof(Static), 3492, "", new DecorationEntry[]
				{
					new(1184, 1195, -25, ""),
					new(1186, 1197, -25, ""),
					new(1194, 1185, -25, ""),
					new(1194, 1198, -25, ""),
				}),
				new("Pear Tree", typeof(Static), 3494, "", new DecorationEntry[]
				{
					new(1184, 1195, -25, ""),
					new(1186, 1197, -25, ""),
					new(1194, 1185, -25, ""),
					new(1194, 1198, -25, ""),
				}),
				new("Pear Tree", typeof(Static), 3496, "", new DecorationEntry[]
				{
					new(1188, 1189, -25, ""),
					new(1194, 1189, -25, ""),
				}),
				new("Pear Tree", typeof(Static), 3498, "", new DecorationEntry[]
				{
					new(1188, 1189, -25, ""),
					new(1194, 1189, -25, ""),
				}),
				new("Spiderweb", typeof(Static), 3812, "", new DecorationEntry[]
				{
					new(1218, 1157, -25, ""),
				}),
				new("Spiderweb", typeof(Static), 3814, "", new DecorationEntry[]
				{
					new(1224, 1133, -5, ""),
				}),
				new("Hay", typeof(Static), 3892, "", new DecorationEntry[]
				{
					new(1219, 1160, -25, ""),
					new(1225, 1160, -25, ""),
				}),
				new("Garbage", typeof(Static), 4334, "", new DecorationEntry[]
				{
					new(1202, 1179, -25, ""),
					new(1220, 1133, -25, ""),
					new(1221, 1140, -25, ""),
					new(1221, 1177, -25, ""),
					new(1222, 1151, -25, ""),
					new(1222, 1160, -25, ""),
					new(1228, 1125, -25, ""),
					new(1229, 1152, -25, ""),
				}),
				new("Garbage", typeof(Static), 4335, "", new DecorationEntry[]
				{
					new(1201, 1174, -25, ""),
					new(1220, 1154, -25, ""),
					new(1227, 1145, -25, ""),
					new(1228, 1135, -25, ""),
				}),
				new("Garbage", typeof(Static), 4336, "", new DecorationEntry[]
				{
					new(1223, 1153, -25, ""),
					new(1224, 1179, -25, ""),
					new(1229, 1160, -25, ""),
				}),
				new("Garbage", typeof(Static), 4337, "", new DecorationEntry[]
				{
					new(1220, 1178, -25, ""),
					new(1221, 1174, -25, ""),
				}),
				new("Bellows", typeof(Static), 6534, "", new DecorationEntry[]
				{
					new(1228, 1097, -25, ""),
					new(1228, 1106, -25, ""),
				}),
				new("Forge", typeof(Static), 6538, "", new DecorationEntry[]
				{
					new(1228, 1098, -25, ""),
					new(1228, 1107, -25, ""),
				}),
				new("Forge", typeof(Static), 6542, "", new DecorationEntry[]
				{
					new(1228, 1099, -25, ""),
					new(1228, 1108, -25, ""),
				}),
				new("Bellows", typeof(Static), 6546, "", new DecorationEntry[]
				{
					new(1229, 1099, -25, ""),
					new(1229, 1108, -25, ""),
				}),
				new("Forge", typeof(Static), 6550, "", new DecorationEntry[]
				{
					new(1229, 1098, -25, ""),
					new(1229, 1107, -25, ""),
				}),
				new("Forge", typeof(Static), 6554, "", new DecorationEntry[]
				{
					new(1229, 1097, -25, ""),
					new(1229, 1106, -25, ""),
				}),
				new("Leaves", typeof(Static), 6943, "", new DecorationEntry[]
				{
					new(1222, 1125, -25, ""),
					new(1228, 1132, -25, ""),
				}),
				new("Leaves", typeof(Static), 6947, "", new DecorationEntry[]
				{
					new(1218, 1175, -25, ""),
					new(1232, 1124, -25, ""),
				}),
				new("Leaves", typeof(Static), 6948, "", new DecorationEntry[]
				{
					new(1218, 1173, -25, ""),
					new(1232, 1123, -25, ""),
				}),
				new("Wall Cracks", typeof(Static), 7020, "", new DecorationEntry[]
				{
					new(1195, 1160, -25, ""),
					new(1227, 1179, -25, ""),
				}),
				new("Wall Cracks", typeof(Static), 7021, "", new DecorationEntry[]
				{
					new(1195, 1163, -25, ""),
				}),
				new("Wall Cracks", typeof(Static), 7022, "", new DecorationEntry[]
				{
					new(1205, 1163, -25, ""),
				}),
				new("Wall Cracks", typeof(Static), 7023, "", new DecorationEntry[]
				{
					new(1202, 1149, -25, ""),
					new(1204, 1163, -25, ""),
					new(1208, 1151, -25, ""),
					new(1218, 1176, -25, ""),
				}),
				new("Refuse", typeof(Static), 7088, "", new DecorationEntry[]
				{
					new(1196, 1149, -25, ""),
				}),
				new("Refuse", typeof(Static), 7089, "", new DecorationEntry[]
				{
					new(1196, 1150, -25, ""),
				}),
				new("Refuse", typeof(Static), 7093, "", new DecorationEntry[]
				{
					new(1195, 1150, -25, ""),
				}),
				new("Refuse", typeof(Static), 7094, "", new DecorationEntry[]
				{
					new(1195, 1149, -25, ""),
				}),
				new("Broken Barrel", typeof(Static), 7603, "", new DecorationEntry[]
				{
					new(1196, 1154, -25, ""),
				}),
				new("Broken Barrel", typeof(Static), 7604, "", new DecorationEntry[]
				{
					new(1196, 1153, -25, ""),
				}),
				new("Broken Barrel", typeof(Static), 7605, "", new DecorationEntry[]
				{
					new(1195, 1153, -25, ""),
				}),
				new("Broken Barrel", typeof(Static), 7606, "", new DecorationEntry[]
				{
					new(1195, 1154, -25, ""),
				}),
				new("Mud", typeof(Static), 7681, "", new DecorationEntry[]
				{
					new(1197, 1157, -25, ""),
					new(1207, 1155, -25, ""),
				}),
				new("Mud", typeof(Static), 7682, "", new DecorationEntry[]
				{
					new(1200, 1162, -25, ""),
					new(1201, 1149, -25, ""),
					new(1204, 1179, -25, ""),
					new(1205, 1159, -25, ""),
					new(1220, 1150, -25, ""),
					new(1228, 1127, -25, ""),
				}),
				new("Book", typeof(Static), 7712, "", new DecorationEntry[]
				{
					new(1168, 1165, -25, ""),
					new(1200, 1177, -25, ""),
				}),
				new("Books", typeof(Static), 7713, "", new DecorationEntry[]
				{
					new(1168, 1162, -25, ""),
					new(1202, 1176, -25, ""),
				}),
				new("Barrel Staves", typeof(Static), 7858, "", new DecorationEntry[]
				{
					new(1195, 1154, -25, ""),
				}),
				new("Unfinished Barrel", typeof(Static), 7861, "", new DecorationEntry[]
				{
					new(1195, 1152, -24, ""),
					new(1225, 1157, -25, ""),
				}),
				
				#endregion
			});
		}
	}
}
