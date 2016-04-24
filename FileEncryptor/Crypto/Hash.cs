using Org.BouncyCastle.Crypto;
using Org.BouncyCastle.Crypto.Digests;

namespace Crypto {
	class Hash {
		//vars

		//constructor
		public Hash() {

		}

		//public
		public static byte[] md5(byte[] input) {
			return internalHash(new MD5Digest(), input);
		}
		public static byte[] ripemd256(byte[] input) {
			return internalHash(new RipeMD256Digest(), input);
		}
		public static byte[] sha256(byte[] input) {
			return internalHash(new Sha256Digest(), input);
		}
		public static byte[] sha512(byte[] input) {
			return internalHash(new Sha512Digest(), input);
		}
		public static byte[] whirlpool(byte[] input) {
			return internalHash(new WhirlpoolDigest(), input);
		}

		//private
		private static byte[] internalHash(IDigest d, byte[] input) {
			byte[] output;

			d.BlockUpdate(input, 0, input.Length);
			output = new byte[d.GetDigestSize()];
			d.DoFinal(output, 0);

			return output;
		}
	}
}
