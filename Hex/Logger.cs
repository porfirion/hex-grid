using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Hex {
	class Logger {
		private static TextBox m_log = null;

		public static void init(TextBox log) {
			Logger.m_log = log;
		}

		public static void AppendText(string message) {
			log(message);
		}

		public static void log(string message) {
			if (m_log == null) {
				throw new Exception("Give me a log!");
			}
			else {
				m_log.AppendText(message + "\r\n");
			}
		}

		public static void clear() {
			m_log.Clear();
		}
	}
}
