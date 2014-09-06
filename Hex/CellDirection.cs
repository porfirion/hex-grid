using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hex {
	class CellDirection {
		private static Random rnd = new Random();

		public static readonly Dictionary<string, CellDirection> names2Directions = new Dictionary<string, CellDirection>() {
			{ "up",        new CellDirection("Up",        0) },
			{ "upright",   new CellDirection("UpRight",   1) },
			{ "downright", new CellDirection("DownRight", 2) },
			{ "down",      new CellDirection("Down",      3) },
			{ "downleft",  new CellDirection("DownLeft",  4) },
			{ "upleft",    new CellDirection("UpLeft",    5) },
		};

		private static readonly Dictionary<int, CellDirection> values2Directions = new Dictionary<int, CellDirection>() {
			{0, names2Directions["up"]       },
			{1, names2Directions["upright"]  },
			{2, names2Directions["downright"]},
			{3, names2Directions["down"]     },
			{4, names2Directions["downleft"] },
			{5, names2Directions["upleft"]   },
		};

		public static CellDirection Up        { get { return names2Directions["up"];        } }
		public static CellDirection UpRight   { get { return names2Directions["upright"];   } }
		public static CellDirection DownRight { get { return names2Directions["downright"]; } }
		public static CellDirection Down      { get { return names2Directions["down"];      } }
		public static CellDirection DownLeft  { get { return names2Directions["downleft"];  } }
		public static CellDirection UpLeft    { get { return names2Directions["upleft"];    } }

		public readonly string name;
		public readonly int value;

		public static explicit operator int(CellDirection direction) {
			return direction.value;
		}

		public static explicit operator CellDirection(int value) {
			if (values2Directions.ContainsKey(value)) {
				return values2Directions[value];
			}
			else {
				throw new ArgumentOutOfRangeException("CellDirection.value", value, String.Format("there is no direction with value {0}", value));
			}
		}

		public CellDirection(string name, int value) {
			this.name = name;
			this.value = value;
		}

		public static CellDirection getRandom() {
			return values2Directions[rnd.Next(6)];
		}

		public static CellDirection getRandom(int[] except) {
			List<CellDirection> availableDirections = new List<CellDirection>();
			foreach (KeyValuePair<int, CellDirection> pair in values2Directions) {
				if (!except.Contains(pair.Key)) {
					availableDirections.Add(pair.Value);
				}
			}
			return availableDirections[rnd.Next(availableDirections.Count)];
		}

		public static CellDirection getRandom(List<CellDirection> except) {
			int[] intValues = new int[except.Count];
			for (int i = 0; i < except.Count; i++) {
				intValues[i] = except[i].value;
			}
			return getRandom(intValues);
		}
	}
}
