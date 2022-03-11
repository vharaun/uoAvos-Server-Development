using Server.Items;

namespace Server.Commands
{
	public static partial class Decorate
	{
		public static partial class Britannia
		{
			public static DecorationList[] Covetous { get; } = Register(DecorationTarget.Britannia, "Covetous", new DecorationList[]
			{
				#region Entries
				
				new("Switch", typeof(Static), 4239, "", new DecorationEntry[]
				{
					new(5552, 1864, 11, ""),
					new(5399, 1875, 17, ""),
					new(5435, 1875, 12, ""),
				}),
				new("Stone Stairs", typeof(Static), 1956, "", new DecorationEntry[]
				{
					new(5553, 1807, 0, ""),
					new(5558, 1826, -12, ""),
					new(5558, 1825, -5, ""),
					new(5551, 1807, 0, ""),
					new(5552, 1807, 0, ""),
					new(5556, 1826, -12, ""),
					new(5552, 1804, 15, ""),
					new(5556, 1825, -5, ""),
					new(5557, 1825, -5, ""),
					new(5557, 1826, -12, ""),
					new(5557, 1828, -22, ""),
				}),
				new("Cot", typeof(Static), 4605, "", new DecorationEntry[]
				{
					new(5554, 1889, 0, ""),
					new(5554, 1891, 0, ""),
					new(5554, 1895, 0, ""),
					new(5554, 1897, 0, ""),
					new(5554, 1899, 0, ""),
					new(5554, 1903, 0, ""),
					new(5602, 1889, 0, ""),
					new(5602, 1907, 0, ""),
					new(5554, 1907, 0, ""),
					new(5602, 1911, 0, ""),
					new(5602, 1915, 0, ""),
					new(5554, 1905, 0, ""),
					new(5554, 1911, 0, ""),
					new(5554, 1913, 0, ""),
					new(5554, 1915, 0, ""),
					new(5602, 1891, 0, ""),
					new(5602, 1895, 0, ""),
					new(5602, 1897, 0, ""),
					new(5602, 1899, 0, ""),
					new(5602, 1903, 0, ""),
					new(5602, 1905, 0, ""),
					new(5602, 1913, 0, ""),
				}),
				new("Metal Door", typeof(MetalDoor2), 1743, "Facing=NorthCCW", new DecorationEntry[]
				{
					new(5567, 1829, 0, ""),
					new(5581, 1877, 0, ""),
					new(5567, 1863, 0, ""),
					new(5563, 1877, 0, ""),
					new(5577, 1877, 0, ""),
				}),
				new("Metal Door", typeof(MetalDoor2), 1741, "Facing=SouthCW", new DecorationEntry[]
				{
					new(5567, 1830, 0, ""),
					new(5563, 1841, 0, ""),
					new(5619, 1859, 0, ""),
					new(5559, 1843, 0, ""),
					new(5581, 1878, 0, ""),
					new(5551, 1881, 0, ""),
					new(5511, 1809, 0, ""),
					new(5577, 1878, 0, ""),
					new(5567, 1864, 0, ""),
					new(5559, 1912, 0, ""),
					new(5559, 1905, 0, ""),
					new(5559, 1890, 0, ""),
					new(5559, 1876, 0, ""),
					new(5559, 1867, 0, ""),
					new(5559, 1859, 0, ""),
					new(5559, 1851, 0, ""),
					new(5563, 1903, 0, ""),
					new(5563, 1878, 0, ""),
					new(5543, 1881, 0, ""),
					new(5559, 1897, 0, ""),
				}),
				new("Floor Spikes", typeof(SpikeTrap), 4512, "", new DecorationEntry[]
				{
					new(5410, 1875, 0, ""),
					new(5483, 1913, 0, ""),
					new(5409, 1877, 0, ""),
					new(5485, 1911, 0, ""),
					new(5492, 2030, 0, ""),
				}),
				new("Barrel", typeof(Barrel), 3703, "", new DecorationEntry[]
				{
					new(5608, 1832, 10, ""),
					new(5610, 1835, 5, ""),
					new(5459, 1968, 0, ""),
					new(5610, 1834, 10, ""),
					new(5464, 1809, 0, ""),
					new(5610, 1834, 0, ""),
					new(5611, 1835, 0, ""),
					new(5609, 1832, 5, ""),
					new(5621, 1844, 5, ""),
					new(5464, 1809, 5, ""),
					new(5620, 1846, 15, ""),
					new(5620, 1844, 10, ""),
					new(5620, 1845, 5, ""),
					new(5621, 1846, 0, ""),
					new(5608, 1833, 5, ""),
					new(5608, 1838, 10, ""),
					new(5608, 1838, 5, ""),
					new(5620, 1844, 5, ""),
					new(5620, 1846, 10, ""),
					new(5608, 1832, 5, ""),
					new(5608, 1833, 0, ""),
					new(5610, 1834, 5, ""),
					new(5611, 1834, 5, ""),
					new(5464, 1810, 0, ""),
					new(5622, 1845, 0, ""),
					new(5622, 1845, 5, ""),
					new(5621, 1845, 0, ""),
					new(5620, 1845, 0, ""),
					new(5464, 1810, 10, ""),
					new(5621, 1845, 5, ""),
					new(5611, 1834, 0, ""),
					new(5620, 1846, 0, ""),
					new(5620, 1846, 5, ""),
					new(5464, 1809, 10, ""),
					new(5465, 1809, 0, ""),
					new(5465, 1809, 5, ""),
					new(5465, 1810, 0, ""),
					new(5608, 1840, 5, ""),
					new(5609, 1838, 0, ""),
					new(5465, 1810, 5, ""),
					new(5456, 2003, 0, ""),
					new(5620, 1844, 0, ""),
					new(5621, 1844, 0, ""),
					new(5609, 1838, 5, ""),
					new(5621, 1844, 10, ""),
					new(5464, 1810, 5, ""),
					new(5608, 1832, 0, ""),
					new(5608, 1838, 0, ""),
					new(5608, 1839, 0, ""),
					new(5608, 1839, 10, ""),
					new(5608, 1839, 5, ""),
					new(5608, 1840, 0, ""),
					new(5609, 1832, 0, ""),
					new(5609, 1839, 0, ""),
					new(5610, 1835, 0, ""),
					new(5621, 1846, 5, ""),
				}),
				new("Crate", typeof(LargeCrate), 3644, "", new DecorationEntry[]
				{
					new(5418, 1863, 6, ""),
					new(5489, 2009, 0, ""),
					new(5489, 2008, 0, ""),
					new(5417, 1868, 0, ""),
					new(5384, 1912, 0, " // spawning"),
					new(5489, 2008, 3, ""),
					new(5418, 1863, 3, ""),
					new(5416, 1866, 0, ""),
					new(5417, 1864, 0, ""),
					new(5418, 1863, 0, ""),
					new(5418, 1864, 0, ""),
					new(5574, 2000, 0, "// spawning"),
					new(5417, 1864, 3, ""),
				}),
				new("Metal Door", typeof(MetalDoor2), 1733, "Facing=WestCW", new DecorationEntry[]
				{
					new(5589, 1851, 0, ""),
					new(5579, 1871, 0, ""),
					new(5569, 1835, 0, ""),
					new(5617, 1871, 0, ""),
					new(5617, 1847, 0, ""),
					new(5579, 1887, 0, ""),
					new(5603, 1867, 0, ""),
					new(5603, 1871, 0, ""),
					new(2545, 853, 0, ""),
				}),
				new("Metal Door", typeof(MetalDoor2), 1735, "Facing=EastCCW", new DecorationEntry[]
				{
					new(5580, 1871, 0, ""),
					new(5590, 1851, 0, ""),
					new(5618, 1871, 0, ""),
					new(5618, 1847, 0, ""),
					new(5580, 1887, 0, ""),
					new(2546, 853, 0, ""),
				}),
				new("Scimitar", typeof(Static), 5045, "Hue=0x4F4", new DecorationEntry[]
				{
					new(5570, 1906, 0, ""),
				}),
				new("Bookcase", typeof(FullBookcase), 2715, "", new DecorationEntry[]
				{
					new(5576, 1824, 0, ""),
					new(5584, 1824, 0, ""),
				}),
				new("Flowstone", typeof(Static), 2275, "", new DecorationEntry[]
				{
					new(5445, 1824, -5, ""),
					new(5444, 1817, -5, ""),
					new(5438, 1798, -5, ""),
					new(5441, 1803, -5, ""),
					new(5442, 1802, -5, ""),
				}),
				new("Mushroom", typeof(Static), 3350, "", new DecorationEntry[]
				{
					new(5581, 2011, 0, ""),
					new(5493, 2009, 0, ""),
					new(5595, 2009, 0, ""),
					new(5494, 2030, 0, ""),
					new(5501, 2025, 0, ""),
					new(5508, 2028, 0, ""),
					new(5512, 1998, 0, ""),
					new(5509, 2009, 0, ""),
					new(5466, 1879, 0, ""),
					new(5604, 2001, 0, ""),
					new(5403, 1902, 0, ""),
					new(5405, 1911, 0, ""),
					new(5411, 1901, 0, ""),
					new(5507, 1991, 0, ""),
					new(5494, 2003, 0, ""),
					new(5500, 2005, 0, ""),
					new(5549, 2029, 0, ""),
					new(5571, 2028, 0, ""),
					new(5581, 2026, 0, ""),
					new(5595, 2016, 0, ""),
					new(5471, 1928, 0, ""),
					new(5472, 1927, 0, ""),
					new(5472, 1927, 5, ""),
					new(5473, 1927, 4, ""),
					new(5543, 2036, 0, ""),
					new(5585, 2015, 0, ""),
					new(5589, 2011, 0, ""),
				}),
				new("Metal Door", typeof(MetalDoor2), 1747, "Facing=NorthCW", new DecorationEntry[]
				{
					new(5611, 1877, 0, ""),
					new(5615, 1877, 0, ""),
					new(5595, 1877, 0, ""),
					new(5591, 1903, 0, ""),
					new(5563, 1863, 0, ""),
				}),
				new("Wooden Chest", typeof(WoodenChest), 3650, "", new DecorationEntry[]
				{
					new(5489, 2011, 0, "// spawning"),
					new(5461, 1968, 0, "// spawning"),
					new(5456, 1810, 0, "// spawning"),
					new(5453, 2024, 0, "// spawning"),
					new(5456, 1978, 0, "// spawning"),
					new(5507, 1991, 0, "// spawning"),
					new(5501, 2004, 0, "// spawning"),
					new(5403, 1863, 0, "// spawning"),
				}),
				new("Crate", typeof(MediumCrate), 3647, "", new DecorationEntry[]
				{
					new(5613, 1840, 0, ""),
					new(5613, 1840, 6, ""),
					new(5613, 1839, 0, ""),
					new(5613, 1839, 3, ""),
					new(5613, 1840, 3, ""),
					new(5455, 1891, 0, "// spawning"),
					new(5613, 1840, 9, ""),
					new(5613, 1839, 6, ""),
				}),
				new("Tray", typeof(Static), 2450, "", new DecorationEntry[]
				{
					new(5620, 1881, 6, ""),
				}),
				new("Crate", typeof(LargeCrate), 3645, "", new DecorationEntry[]
				{
					new(5618, 1832, 3, ""),
					new(5619, 1840, 3, ""),
					new(5618, 1840, 9, ""),
					new(5618, 1839, 9, ""),
					new(5616, 1832, 0, ""),
					new(5618, 1832, 0, ""),
					new(5618, 1839, 3, ""),
					new(5617, 1833, 3, ""),
					new(5617, 1834, 0, ""),
					new(5618, 1840, 3, ""),
					new(5576, 2003, 0, "// spawning"),
					new(5618, 1840, 6, ""),
					new(5415, 2004, 0, "// spawning"),
					new(5615, 1832, 0, ""),
					new(5617, 1832, 6, ""),
					new(5616, 1832, 3, ""),
					new(5616, 1832, 6, ""),
					new(5616, 1832, 9, ""),
					new(5616, 1833, 0, ""),
					new(5618, 1839, 0, ""),
					new(5617, 1832, 0, ""),
					new(5617, 1832, 3, ""),
					new(5617, 1832, 9, ""),
					new(5619, 1839, 3, ""),
					new(5384, 1908, 0, "// spawning"),
					new(5618, 1839, 6, ""),
					new(5616, 1834, 0, ""),
					new(5616, 1833, 3, ""),
					new(5617, 1833, 0, ""),
					new(5619, 1839, 0, ""),
					new(5618, 1840, 0, ""),
					new(5619, 1839, 6, ""),
					new(5619, 1840, 0, ""),
				}),
				new("Candlabra", typeof(CandelabraStand), 2601, "", new DecorationEntry[]
				{
					new(5576, 1848, 0, ""),
					new(5582, 1848, 0, ""),
					new(5586, 1856, 0, ""),
					new(5568, 1852, 0, ""),
					new(5577, 1855, 0, ""),
				}),
				new("Long Pants", typeof(Static), 5433, "Hue=0xE8", new DecorationEntry[]
				{
					new(5592, 2010, 0, ""),
				}),
				new("Rack", typeof(Static), 4699, "", new DecorationEntry[]
				{
					new(5506, 1811, 0, ""),
				}),
				new("Rack", typeof(Static), 4696, "", new DecorationEntry[]
				{
					new(5506, 1812, 0, ""),
				}),
				new("Metal Door", typeof(MetalDoor2), 1745, "Facing=SouthCCW", new DecorationEntry[]
				{
					new(5591, 1904, 0, ""),
					new(5599, 1905, 0, ""),
					new(5599, 1897, 0, ""),
					new(5599, 1890, 0, ""),
					new(5543, 1809, 0, ""),
					new(5611, 1878, 0, ""),
					new(5599, 1913, 0, ""),
					new(5595, 1878, 0, ""),
					new(5563, 1864, 0, ""),
					new(5615, 1878, 0, ""),
				}),
				new("Cauldron", typeof(Static), 2420, "", new DecorationEntry[]
				{
					new(5407, 1934, 0, ""),
					new(5433, 1976, 0, ""),
					new(5501, 1998, 0, ""),
				}),
				new("Candle", typeof(CandleLarge), 2598, "", new DecorationEntry[]
				{
					new(5454, 1921, 20, ""),
				}),
				new("Oven", typeof(StoneOvenSouthAddon), 2352, "", new DecorationEntry[]
				{
					new(5621, 1872, 0, ""),
				}),
				new("Flowstone", typeof(Static), 2280, "", new DecorationEntry[]
				{
					new(5440, 1813, -5, ""),
					new(5439, 1823, -5, ""),
					new(5440, 1797, -5, ""),
					new(5440, 1804, -5, ""),
					new(5440, 1806, -5, ""),
					new(5440, 1807, -5, ""),
					new(5440, 1808, -5, ""),
					new(5440, 1814, -5, ""),
					new(5440, 1821, -5, ""),
					new(5440, 1824, -5, ""),
					new(5440, 1825, -5, ""),
					new(5440, 1827, -5, ""),
					new(5440, 1828, -5, ""),
					new(5440, 1812, -5, ""),
					new(5440, 1817, -5, ""),
					new(5439, 1828, -5, ""),
					new(5440, 1799, -5, ""),
					new(5440, 1800, -5, ""),
					new(5440, 1801, -5, ""),
					new(5440, 1802, -5, ""),
					new(5440, 1803, -5, ""),
					new(5440, 1805, -5, ""),
					new(5440, 1809, -5, ""),
					new(5440, 1810, -5, ""),
					new(5440, 1811, -5, ""),
					new(5440, 1815, -5, ""),
					new(5440, 1816, -5, ""),
					new(5440, 1819, -5, ""),
					new(5440, 1820, -5, ""),
					new(5440, 1823, -5, ""),
					new(5440, 1826, -5, ""),
					new(5443, 1808, -5, ""),
					new(5443, 1821, -5, ""),
					new(5440, 1822, -5, ""),
					new(5440, 1798, -5, ""),
					new(5440, 1818, -5, ""),
				}),
				new("Bookcase", typeof(FullBookcase), 2713, "", new DecorationEntry[]
				{
					new(5568, 1833, 0, ""),
				}),
				new("Bookcase", typeof(FullBookcase), 2711, "", new DecorationEntry[]
				{
					new(5571, 1824, 0, ""),
					new(5587, 1824, 0, ""),
				}),
				new("Floor Spikes", typeof(SpikeTrap), 4506, "", new DecorationEntry[]
				{
					new(5408, 1878, 0, ""),
				}),
				new("Shackles", typeof(Static), 4707, "", new DecorationEntry[]
				{
					new(5507, 1804, 16, ""),
				}),
				new("Flowstone", typeof(Static), 2278, "", new DecorationEntry[]
				{
					new(5443, 1807, -5, ""),
					new(5442, 1803, -5, ""),
					new(5445, 1817, -5, ""),
					new(5445, 1825, -5, ""),
				}),
				new("Floor Saw", typeof(SawTrap), 4524, "", new DecorationEntry[]
				{
					new(5466, 2011, 0, ""),
					new(5407, 1873, 0, ""),
				}),
				new("Switch", typeof(Static), 4242, "", new DecorationEntry[]
				{
					new(5428, 1875, 13, ""),
					new(5407, 1873, 19, ""),
					new(5425, 1875, 13, ""),
					new(5426, 1875, 13, ""),
					new(5427, 1875, 13, ""),
					new(5429, 1875, 13, ""),
				}),
				new("Gas Trap", typeof(GasTrap), 4412, "", new DecorationEntry[]
				{
					new(5491, 2029, 0, ""),
					new(5468, 2007, 0, ""),
					new(5493, 2027, 0, ""),
				}),
				new("Open Sack Of Flour", typeof(Static), 4154, "", new DecorationEntry[]
				{
					new(5625, 1859, 0, ""),
					new(5623, 1861, 0, ""),
				}),
				new("Water Barrel", typeof(Static), 5453, "", new DecorationEntry[]
				{
					new(5464, 1810, 0, ""),
					new(5465, 1809, 0, ""),
					new(5465, 1810, 0, ""),
				}),
				new("Metal Chest", typeof(MetalGoldenChest), 3648, "", new DecorationEntry[]
				{
					new(5415, 1931, 0, "// spawning"),
					new(5495, 2012, 0, "// spawning"),
					new(5615, 1834, 0, "// spawning"),
				}),
				new("Cot", typeof(Static), 4606, "", new DecorationEntry[]
				{
					new(5603, 1895, 0, ""),
					new(5555, 1903, 0, ""),
					new(5603, 1905, 0, ""),
					new(5603, 1915, 0, ""),
					new(5555, 1913, 0, ""),
					new(5555, 1915, 0, ""),
					new(5603, 1889, 0, ""),
					new(5603, 1891, 0, ""),
					new(5603, 1899, 0, ""),
					new(5603, 1907, 0, ""),
					new(5603, 1911, 0, ""),
					new(5555, 1889, 0, ""),
					new(5555, 1891, 0, ""),
					new(5555, 1895, 0, ""),
					new(5555, 1897, 0, ""),
					new(5555, 1899, 0, ""),
					new(5555, 1905, 0, ""),
					new(5555, 1907, 0, ""),
					new(5555, 1911, 0, ""),
					new(5603, 1897, 0, ""),
					new(5603, 1903, 0, ""),
					new(5603, 1913, 0, ""),
				}),
				new("Metal Chest", typeof(MetalChest), 3708, "", new DecorationEntry[]
				{
					new(5457, 1810, 0, "// spawning"),
					new(5400, 1862, 0, "// spawning"),
					new(5610, 1832, 0, "// spawning"),
					new(5569, 2001, 0, "// spawning"),
					new(5403, 1928, 0, "// spawning"),
					new(5450, 1893, 0, ""),
					new(5450, 1894, 0, ""),
				}),
				new("Stalagmites", typeof(Static), 2277, "", new DecorationEntry[]
				{
					new(5439, 1798, -5, ""),
					new(5447, 1819, -5, ""),
				}),
				new("Candle", typeof(CandleLarge), 2842, "", new DecorationEntry[]
				{
					new(5536, 1879, 6, ""),
					new(5536, 1882, 6, ""),
				}),
				new("Dungeon Wall", typeof(Static), 767, "", new DecorationEntry[]
				{
					new(5558, 1825, 0, ""),
				}),
				new("Candelabra", typeof(CandelabraStand), 2854, "", new DecorationEntry[]
				{
					new(5568, 1866, 0, ""),
					new(5590, 1866, 0, ""),
				}),
				new("Fireplace", typeof(Static), 2267, "", new DecorationEntry[]
				{
					new(5616, 1880, 0, ""),
				}),
				new("Stalagmites", typeof(Static), 2282, "", new DecorationEntry[]
				{
					new(5441, 1802, -5, ""),
					new(5446, 1809, -5, ""),
					new(5444, 1816, -5, ""),
					new(5447, 1812, -5, ""),
				}),
				new("Ruined Painting", typeof(HintItem), 3116, "Range=2;WarningNumber=500715;HintNumber=500716", new DecorationEntry[]
				{
					new(5570, 1876, 0, ""),
				}),
				new("Rack", typeof(Static), 4700, "", new DecorationEntry[]
				{
					new(5506, 1810, 0, ""),
				}),
				new("Stalagmites", typeof(Static), 2276, "", new DecorationEntry[]
				{
					new(5443, 1813, -5, ""),
					new(5443, 1808, 11, ""),
				}),
				new("Rack", typeof(Static), 4694, "", new DecorationEntry[]
				{
					new(5507, 1813, 0, ""),
				}),
				new("Sack Of Flour", typeof(Static), 4153, "", new DecorationEntry[]
				{
					new(5624, 1861, 0, ""),
					new(5621, 1861, 0, ""),
					new(5623, 1860, 0, ""),
					new(5624, 1860, 0, ""),
				}),
				new("Block", typeof(Static), 4726, "", new DecorationEntry[]
				{
					new(5501, 1811, 0, ""),
				}),
				new("Barrel", typeof(Barrel), 4014, "", new DecorationEntry[]
				{
					new(5452, 1807, 0, ""),
					new(5452, 1806, 0, ""),
					new(5451, 1807, 0, ""),
				}),
				new("Block", typeof(Static), 4731, "", new DecorationEntry[]
				{
					new(5502, 1809, 0, ""),
				}),
				new("Switch", typeof(Static), 4240, "", new DecorationEntry[]
				{
					new(5399, 1875, 17, ""),
					new(5552, 1864, 11, ""),
				}),
				new("Barred Metal Door", typeof(BarredMetalDoor), 1669, "Facing=WestCW", new DecorationEntry[]
				{
					new(5539, 1811, 0, ""),
					new(5515, 1811, 0, ""),
					new(5523, 1811, 0, ""),
					new(5531, 1811, 0, ""),
				}),
				new("Rack", typeof(Static), 4695, "", new DecorationEntry[]
				{
					new(5506, 1813, 0, ""),
				}),
				new("Wooden Chest", typeof(WoodenChest), 3651, "", new DecorationEntry[]
				{
					new(5573, 2000, 0, "// spawning"),
					new(5452, 1796, 0, "// spawning"),
					new(5496, 1993, 0, "// spawning"),
				}),
				new("Wooden Box", typeof(WoodenBox), 2474, "", new DecorationEntry[]
				{
					new(5574, 2000, 3, "// spawning"),
				}),
				new("Stone Stairs", typeof(Static), 1957, "", new DecorationEntry[]
				{
					new(5465, 1805, 15, ""),
					new(5468, 1805, 0, ""),
					new(5468, 1806, 0, ""),
					new(5593, 1841, -5, ""),
					new(5593, 1842, -5, ""),
					new(5468, 1804, 0, ""),
					new(5593, 1840, -5, ""),
					new(5594, 1840, -11, ""),
					new(5594, 1841, -11, ""),
					new(5594, 1842, -12, ""),
					new(5596, 1841, -22, ""),
				}),
				new("Crate", typeof(SmallCrate), 3710, "", new DecorationEntry[]
				{
					new(5549, 2019, 0, "// spawning"),
					new(5455, 1892, 0, "// spawning"),
				}),
				new("Crumbling Floor", typeof(FireColumnTrap), 4549, "", new DecorationEntry[]
				{
					new(5467, 1852, 0, ""),
					new(5474, 1852, 0, ""),
					new(5474, 1857, 0, ""),
					new(5438, 1917, 0, ""),
					new(5440, 1917, 0, ""),
					new(5441, 1908, 0, ""),
					new(5441, 1912, 0, ""),
					new(5443, 1912, 0, ""),
					new(5562, 2028, 0, ""),
					new(5568, 2027, 0, ""),
					new(5451, 1919, 0, ""),
					new(5451, 1923, 0, ""),
					new(5459, 1856, 0, ""),
					new(5463, 1852, 0, ""),
					new(5463, 1855, 0, ""),
					new(5471, 1854, 0, ""),
					new(5471, 1857, 0, ""),
					new(5477, 1854, 0, ""),
					new(5479, 1856, 0, ""),
					new(5556, 2023, 0, ""),
					new(5561, 2022, 0, ""),
					new(5537, 2001, 0, ""),
					new(5541, 2002, 0, ""),
					new(5541, 2007, 0, ""),
					new(5542, 2012, 0, ""),
					new(5545, 2008, 0, ""),
				}),
				new("Head", typeof(Static), 7393, "", new DecorationEntry[]
				{
					new(5417, 1865, 0, ""),
				}),
				new("Wooden Shield", typeof(Static), 7034, "", new DecorationEntry[]
				{
					new(5417, 1930, 0, ""),
				}),
				new("Cauldron", typeof(Static), 2421, "", new DecorationEntry[]
				{
					new(5473, 1876, 0, ""),
				}),
				new("Broken Chair", typeof(Static), 3098, "", new DecorationEntry[]
				{
					new(5613, 1843, 0, ""),
					new(5572, 1832, 0, ""),
					new(5583, 1826, 0, ""),
					new(5576, 1827, 0, ""),
					new(5580, 1832, 0, ""),
					new(5597, 1879, 0, ""),
					new(5604, 1862, 0, ""),
					new(5614, 1834, 0, ""),
				}),
				new("Bone Shards", typeof(Static), 6938, "", new DecorationEntry[]
				{
					new(5421, 1868, 0, ""),
				}),
				new("Bottles Of Liquor", typeof(Static), 2462, "", new DecorationEntry[]
				{
					new(5623, 1856, 6, ""),
					new(5621, 1856, 6, ""),
					new(5624, 1857, 0, ""),
				}),
				new("Dirty Frypan", typeof(Static), 2526, "", new DecorationEntry[]
				{
					new(5619, 1875, 6, ""),
				}),
				new("Broken Chair", typeof(Static), 3097, "", new DecorationEntry[]
				{
					new(5571, 1825, 0, ""),
					new(5581, 1827, 0, ""),
					new(5621, 1838, 0, ""),
					new(5577, 1831, 0, ""),
					new(5588, 1828, 0, ""),
					new(5609, 1836, 0, ""),
				}),
				new("Stalagmites", typeof(Static), 2279, "", new DecorationEntry[]
				{
					new(5443, 1822, -5, ""),
				}),
				new("Bookcase", typeof(FullBookcase), 2712, "", new DecorationEntry[]
				{
					new(5575, 1824, 0, ""),
				}),
				new("Metal Chest", typeof(MetalChest), 2475, "", new DecorationEntry[]
				{
					new(5507, 1808, 0, ""),
					new(5388, 1907, 0, ""),
					new(5411, 1925, 0, ""),
					new(5507, 1805, 0, ""),
				}),
				new("Metal Chest", typeof(MetalGoldenChest), 3649, "", new DecorationEntry[]
				{
					new(5502, 1807, 0, "// spawning"),
					new(5408, 1927, 0, "// spawning"),
					new(5454, 2031, 0, "// spawning"),
				}),
				new("Stalagmites", typeof(Static), 2273, "", new DecorationEntry[]
				{
					new(5439, 1799, -5, ""),
					new(5444, 1824, -5, ""),
				}),
				new("Wand", typeof(Static), 3571, "", new DecorationEntry[]
				{
					new(5404, 1937, 0, ""),
					new(5419, 1928, 0, ""),
				}),
				new("Switch", typeof(Static), 4241, "", new DecorationEntry[]
				{
					new(5407, 1873, 19, ""),
				}),
				new("Sign", typeof(LocalizedSign), 7976, "LabelNumber=1016094", new DecorationEntry[]
				{
					new(2495, 918, 8, ""),
				}),
				new("Shackles", typeof(Static), 4706, "", new DecorationEntry[]
				{
					new(5501, 1808, 20, ""),
					new(5501, 1806, 20, ""),
				}),
				new("Iron Maiden", typeof(Static), 4683, "", new DecorationEntry[]
				{
					new(5502, 1805, 0, ""),
				}),
				new("Block", typeof(Static), 4730, "", new DecorationEntry[]
				{
					new(5503, 1809, 0, ""),
				}),
				new("Guillotine", typeof(Static), 4677, "", new DecorationEntry[]
				{
					new(5505, 1805, 0, ""),
				}),
				new("Rack", typeof(Static), 4701, "", new DecorationEntry[]
				{
					new(5507, 1810, 0, ""),
				}),
				new("Rack", typeof(Static), 4698, "", new DecorationEntry[]
				{
					new(5507, 1811, 0, ""),
				}),
				new("Rack", typeof(Static), 4697, "", new DecorationEntry[]
				{
					new(5507, 1812, 0, ""),
				}),
				new("Broken Chair", typeof(Static), 3101, "", new DecorationEntry[]
				{
					new(5574, 1832, 0, ""),
				}),
				new("Statue", typeof(WarningItem), 4825, "Range=3;WarningNumber=1010056;ResetDelay=00:00:25", new DecorationEntry[]
				{
					new(5577, 1895, 0, ""),
					new(5581, 1895, 0, ""),
				}),
				new("Statue", typeof(WarningItem), 4825, "Range=3;WarningNumber=1010057;ResetDelay=00:00:25", new DecorationEntry[]
				{
					new(5577, 1911, 0, ""),
					new(5581, 1911, 0, ""),
				}),
				new("Flowstone", typeof(Static), 2274, "", new DecorationEntry[]
				{
					new(5473, 1802, 0, ""),
				}),
				new("Crate", typeof(MediumCrate), 3646, "", new DecorationEntry[]
				{
					new(5610, 1837, 0, "// spawning"),
					new(5402, 1863, 0, "// spawning"),
					new(5450, 1892, 0, "// spawning"),
				}),
				new("Wooden Bench", typeof(WoodenBench), 2860, "", new DecorationEntry[]
				{
					new(5539, 1877, 0, ""),
					new(5539, 1878, 0, ""),
					new(5539, 1879, 0, ""),
					new(5539, 1883, 0, ""),
					new(5539, 1884, 0, ""),
					new(5539, 1885, 0, ""),
					new(5541, 1877, 0, ""),
					new(5541, 1878, 0, ""),
					new(5541, 1879, 0, ""),
					new(5541, 1883, 0, ""),
					new(5541, 1884, 0, ""),
					new(5541, 1885, 0, ""),
				}),
				new("Barred Metal Door", typeof(BarredMetalDoor), 1673, "Facing=WestCCW", new DecorationEntry[]
				{
					new(5523, 1806, 0, ""),
					new(5515, 1806, 0, ""),
					new(5531, 1806, 0, ""),
					new(5539, 1806, 0, ""),
				}),
				new("Stone Stairs", typeof(Static), 1873, "", new DecorationEntry[]
				{
					new(5475, 1881, 0, ""),
					new(5474, 1881, 0, ""),
				}),
				new("Stone Stairs", typeof(Static), 1874, "", new DecorationEntry[]
				{
					new(5476, 1880, 0, ""),
					new(5476, 1879, 0, ""),
				}),
				new("Stone Stairs", typeof(Static), 1889, "Hue=0x83B", new DecorationEntry[]
				{
					new(5475, 1880, 0, ""),
				}),
				new("Stone Stairs", typeof(Static), 1892, "Hue=0x83B", new DecorationEntry[]
				{
					new(5475, 1879, 0, ""),
				}),
				new("Stone Stairs", typeof(Static), 1875, "", new DecorationEntry[]
				{
					new(5474, 1878, 0, ""),
					new(5475, 1878, 0, ""),
				}),
				new("Stone Stairs", typeof(Static), 1876, "", new DecorationEntry[]
				{
					new(5473, 1880, 0, ""),
					new(5473, 1879, 0, ""),
				}),
				new("Stone Stairs", typeof(Static), 1891, "Hue=0x83B", new DecorationEntry[]
				{
					new(5474, 1880, 0, ""),
				}),
				new("Stone Stairs", typeof(Static), 1890, "Hue=0x83B", new DecorationEntry[]
				{
					new(5474, 1879, 0, ""),
				}),
				new("Floor Saw", typeof(SawTrap), 4529, "", new DecorationEntry[]
				{
					new(5484, 2028, 0, ""),
				}),
				new("Broken Chair", typeof(Static), 3089, "", new DecorationEntry[]
				{
					new(5604, 1880, 0, ""),
					new(5600, 1872, 0, ""),
				}),
				new("Broken Chair", typeof(Static), 3088, "", new DecorationEntry[]
				{
					new(5606, 1874, 0, ""),
				}),
				new("Skinning Knife", typeof(Static), 3780, "", new DecorationEntry[]
				{
					new(5416, 1937, 0, ""),
				}),
				new("Necklace", typeof(Static), 4233, "", new DecorationEntry[]
				{
					new(5416, 1931, 0, ""),
				}),
				new("Wand", typeof(Static), 3572, "", new DecorationEntry[]
				{
					new(5416, 1929, 0, ""),
				}),
				new("Ring", typeof(Static), 4234, "", new DecorationEntry[]
				{
					new(5417, 1926, 0, ""),
				}),
				new("Bones", typeof(Static), 3794, "", new DecorationEntry[]
				{
					new(5423, 1867, 0, ""),
				}),
				new("Stone Chair", typeof(HintItem), 4632, "Range=2;WarningNumber=500717;HintNumber=500718", new DecorationEntry[]
				{
					new(5579, 1848, 5, ""),
				}),
				new("Block", typeof(Static), 4732, "", new DecorationEntry[]
				{
					new(5501, 1809, 0, ""),
				}),
				new("Block", typeof(Static), 4727, "", new DecorationEntry[]
				{
					new(5501, 1810, 0, ""),
				}),
				new("Broken Chair", typeof(Static), 3102, "", new DecorationEntry[]
				{
					new(5589, 1826, 0, ""),
					new(5600, 1879, 0, ""),
				}),
				new("Block", typeof(Static), 4728, "", new DecorationEntry[]
				{
					new(5502, 1810, 0, ""),
				}),
				new("Block", typeof(Static), 4725, "", new DecorationEntry[]
				{
					new(5502, 1811, 0, ""),
				}),
				new("Block", typeof(Static), 4729, "", new DecorationEntry[]
				{
					new(5503, 1810, 0, ""),
				}),
				new("Block", typeof(Static), 4724, "", new DecorationEntry[]
				{
					new(5503, 1811, 0, ""),
				}),
				new("Goblet", typeof(Static), 2458, "", new DecorationEntry[]
				{
					new(5599, 1876, 4, ""),
				}),
				new("Goblet", typeof(Static), 2495, "", new DecorationEntry[]
				{
					new(5599, 1877, 4, ""),
				}),
				new("Bed", typeof(Static), 2651, "", new DecorationEntry[]
				{
					new(5600, 1863, 0, ""),
				}),
				new("Chair", typeof(WoodenChairCushion), 2899, "", new DecorationEntry[]
				{
					new(5600, 1875, 0, ""),
				}),
				new("Goblet", typeof(Static), 2507, "", new DecorationEntry[]
				{
					new(5600, 1878, 4, ""),
					new(5606, 1878, 4, ""),
				}),
				new("Bed", typeof(Static), 2650, "", new DecorationEntry[]
				{
					new(5601, 1863, 0, ""),
				}),
				new("Chair", typeof(WoodenChair), 2903, "", new DecorationEntry[]
				{
					new(5602, 1875, 0, ""),
				}),
				new("Chair", typeof(WoodenChair), 2905, "", new DecorationEntry[]
				{
					new(5606, 1879, 0, ""),
				}),
				new("Kettle", typeof(Static), 2541, "", new DecorationEntry[]
				{
					new(5616, 1879, 0, ""),
				}),
				new("Fireplace", typeof(Static), 2266, "", new DecorationEntry[]
				{
					new(5616, 1881, 0, ""),
				}),
				new("Tray", typeof(Static), 2449, "", new DecorationEntry[]
				{
					new(5619, 1877, 6, ""),
				}),
				
				#endregion
			});
		}
	}
}
