using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Threading.Tasks;

namespace Hex {
	class CellType {
		private static Random rnd = new Random();

		public readonly int id;
		public readonly string name;
		public readonly string translation;
		public readonly float percent;
		public readonly Color color;
		public readonly int energy;

		public static readonly Dictionary<string, CellType> types = new Dictionary<string, CellType>() {
			{"entrance",  new CellType(1,  "entrance",  "вход",      0,     Color.Lime,        0)},
			{"exit",      new CellType(2,  "exit",      "выход",     0,     Color.Red,         0)},
			{"invisible", new CellType(3,  "invisible", "невидимая", 0,     Color.White,       0)},
			{"water",     new CellType(11, "water",     "вода",      0.05f, Color.DodgerBlue,  5)},
			{"rock",      new CellType(12, "rock",      "камень",    0.1f,  Color.Silver,      4)},
			{"tree",      new CellType(13, "tree",      "дерево",    0.2f,  Color.DarkGreen,   3)},
			{"grass",     new CellType(14, "grass",     "трава",     0.3f,  Color.YellowGreen, 2)},
			{"road",      new CellType(15, "road",      "тропинка",  0.4f,  Color.SaddleBrown, 1)},
		};

		public static CellType Entrance  { get { return types["entrance"];  } }
		public static CellType Exit      { get { return types["exit"];      } }
		public static CellType Invisible { get { return types["invisible"]; } }
		public static CellType Water     { get { return types["water"];     } }
		public static CellType Rock      { get { return types["rock"];      } }
		public static CellType Tree      { get { return types["tree"];      } }
		public static CellType Grass     { get { return types["grass"];     } }
		public static CellType Road      { get { return types["road"];      } }

		private CellType(int id, string name, string translation, float percent, Color color, int energy) {
			this.id = id;
			this.name = name;
			this.translation = translation;
			this.percent = percent;
			this.color = color;
			this.energy = energy;
		}

		public static CellType getRandom() {
			return types.Values.ToArray()[rnd.Next(types.Count)];
		}

		public Brush getBrush() {
			return getBrush(150);
		}

		public Brush getBrush(int alpha) {
			//HatchStyle style = HatchStyle.SolidDiamond;
			//Color color1 = this.color;
			//Color color2 = Color.White;
			//switch (this.name) {
			//	case "entrance": style = HatchStyle.Percent50;     color1 = this.color; break;
			//	case "exit":     style = HatchStyle.Percent50;     color1 = this.color; break;
			//	case "water":    style = HatchStyle.Wave;          color1 = this.color; break;
			//	case "rock":     style = HatchStyle.ZigZag;        color1 = this.color; break;
			//	case "tree":     style = HatchStyle.SolidDiamond;  color1 = this.color; break;
			//	case "grass":    style = HatchStyle.LargeConfetti; color1 = this.color; break;
			//	case "road": style = HatchStyle.DiagonalBrick;     color1 = this.color; break;
			//	default:
			//		throw new Exception("Unknown cell type or invisible cell");
			//		break;
			//}
			//return new HatchBrush(style, this.color, Color.White);
			return new SolidBrush(Color.FromArgb(alpha, this.color));
		}
	}
}
