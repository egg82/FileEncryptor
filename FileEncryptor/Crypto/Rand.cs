using Org.BouncyCastle.Crypto.Prng;
using System;
using System.Threading;

namespace Crypto {
	class Rand {
		//vars
		private ThreadedSeedGenerator seed = new ThreadedSeedGenerator();
		private VmpcRandomGenerator generator = new VmpcRandomGenerator();
		private Random rand = new Random();

		//constructor
		public Rand() {
			int length = (int) (rand.NextDouble() * 2.0d + 1.0d);

			for (int i = 0; i < length; i++) {
				generator.AddSeedMaterial(seed.GenerateSeed(128, false));
			}
		}

		//public
		public void addSeed() {
			new Thread(delegate() {
				generator.AddSeedMaterial(seed.GenerateSeed((int) (rand.NextDouble() * 128.0d + 128.0d), false));
			}).Start();
		}
		public void addSeed(byte[] entropy) {
			new Thread(delegate() {
				generator.AddSeedMaterial(entropy);
			}).Start();
		}

		public byte[] getNextBytes(int length) {
			byte[] output = new byte[length];
			generator.NextBytes(output);
			return output;
		}
		public double getNextDouble() {
			double d = BitConverter.ToDouble(getNextBytes(8), 0);

			if (d < 0) {
				d *= -1;
			}
			while (d > 1.0d) {
				d /= 10.0d;
			}

			return d;
		}

		//private

	}
}
