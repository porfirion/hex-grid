using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hex {
	class Randomizer {
		private static Random rnd = new Random();
		
		public static int getRandomValue() {
			return rnd.Next();
		}

		public static int getRandomValue(int max) {
			return rnd.Next(max);
		}

		public static int getWithPercent(Dictionary<int, float> percents) {
			float sum = 0;
			foreach(KeyValuePair<int, float> percentPair in percents) {
				sum += percentPair.Value;
			}
			float randomSum = sum * (float)rnd.NextDouble();
			foreach (KeyValuePair<int, float> percentPair in percents) {
				if (randomSum <= percentPair.Value) {
					return percentPair.Key;
				}
				else {
					randomSum -= percentPair.Value;
				}
			}
			return percents.Last().Key;
		}
	}
}
