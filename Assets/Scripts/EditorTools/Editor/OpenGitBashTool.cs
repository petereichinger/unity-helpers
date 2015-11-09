using System.Collections;
using System.Diagnostics;
using System.IO;
using UnityEditor;
using UnityEngine;
using Debug = UnityEngine.Debug;

namespace UnityHelpers.EditorTools.Editor {

	public class OpenGitBashTool : MonoBehaviour {
		private const string GIT_BASH_64 = @"C:\Program Files\Git\git-bash.exe";
		private const string GIT_BASH_32 = @"C:\Program Files(x86)\Git\git-bash.exe";

		[MenuItem("UnityHelpers/Open Git Bash")]
		public static void OpenGitBash() {
			string projectDir = Application.dataPath + "/../";
			string gitDir = projectDir + ".git";
#if !UNITY_EDITOR_WIN
		Debug.LogError("Only supported in Windows Editor");
#else
			if (!Directory.Exists(gitDir)) {
				Debug.LogError("No git repo for this project");
				return;
			}
			string gitBash = null;
			if (File.Exists(GIT_BASH_64)) {
				gitBash = GIT_BASH_64;
			} else if (File.Exists(GIT_BASH_32)) {
				gitBash = GIT_BASH_32;
			} else {
				Debug.LogError("Couldn't find Git Bash");
				return;
			}

			Process foo = new Process {
				StartInfo = {
				FileName = gitBash,
				WorkingDirectory = projectDir
			}
			};
			foo.Start();
#endif
		}
	}
}
