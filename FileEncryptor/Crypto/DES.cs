using Org.BouncyCastle.Crypto;
using Org.BouncyCastle.Crypto.Engines;
using Org.BouncyCastle.Crypto.Modes;
using Org.BouncyCastle.Crypto.Paddings;
using Org.BouncyCastle.Crypto.Parameters;
using System;

namespace Crypto {
	class DES {
		//vars

		//constructor
		public DES() {

		}

		//public
		public static byte[] encrypt(byte[] input, byte[] key, byte[] iv, BlockMode mode, BlockPadding padding) {
			return encryptDecrypt(input, key, iv, mode, padding, true);
		}
		public static byte[] decrypt(byte[] input, byte[] key, byte[] iv, BlockMode mode, BlockPadding padding) {
			return encryptDecrypt(input, key, iv, mode, padding, false);
		}

		//private
		private static byte[] encryptDecrypt(byte[] input, byte[] key, byte[] iv, BlockMode mode, BlockPadding padding, bool encrypt) {
			DesEdeEngine engine = new DesEdeEngine();
			IBlockCipher cipherMode;
			BufferedBlockCipher cipher;
			KeyParameter keyP = new KeyParameter(key);
			ParametersWithIV keyParams = new ParametersWithIV(keyP, iv);

			if (mode == BlockMode.CBC) {
				cipherMode = new CbcBlockCipher(engine);
			} else if (mode == BlockMode.CFB) {
				cipherMode = new CfbBlockCipher(engine, iv.Length);
			} else if (mode == BlockMode.OFB) {
				cipherMode = new OfbBlockCipher(engine, iv.Length);
			} else {
				throw new Exception("mode must be a valid BlockMode.");
			}

			if (padding == BlockPadding.PKCS7Padding) {
				cipher = new PaddedBufferedBlockCipher(cipherMode, new Pkcs7Padding());
			} else if (padding == BlockPadding.ZeroBytePadding) {
				cipher = new PaddedBufferedBlockCipher(cipherMode, new ZeroBytePadding());
			} else if (padding == BlockPadding.NoPadding) {
				cipher = new BufferedBlockCipher(cipherMode);
			} else {
				throw new Exception("padding must be a valid BlockPadding.");
			}

			cipher.Init(encrypt, keyParams);
			byte[] output = new byte[cipher.GetOutputSize(input.Length)];
			int length = cipher.ProcessBytes(input, output, 0);
			cipher.DoFinal(output, length);

			return output;
		}
	}
}
