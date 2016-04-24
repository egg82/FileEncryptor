using System.IO;

class FileUtil {
	//vars

	//constructor
	public FileUtil() {

	}

	//public
	public static byte[] readFile(string path) {
		FileStream file = new FileStream(path, FileMode.OpenOrCreate, FileAccess.Read);
		byte[] output = new byte[file.Length];
		file.Read(output, 0, output.Length);
		file.Close();
		return output;
	}
	public static void writeFile(string path, byte[] data) {
		FileStream file = new FileStream(path, FileMode.OpenOrCreate, FileAccess.Write);
		file.Write(data, 0, data.Length);
		file.Close();
	}

	public static long fileSize(string path) {
		FileInfo info = new FileInfo(path);
		return info.Length;
	}
	public static bool fileExists(string path) {
		return File.Exists(path);
	}

	//private

}
