using System.IO;
using System;

namespace Samples.AuthorsServiceClient
{
	public static class Logger
	{
		public static void LogWriteError(string s){
			using(FileStream stream = new FileStream("log.txt",FileMode.OpenOrCreate,FileAccess.ReadWrite)){
				StreamWriter sw = new StreamWriter(stream);
				sw.BaseStream.Seek(0,SeekOrigin.End);
				sw.Write(DateTime.Now.ToString() + ": "+ s);
				sw.Flush();
				sw.Close();
			}
		}
	}
}

