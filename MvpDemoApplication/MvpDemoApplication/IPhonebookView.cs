using System.Windows.Forms;

namespace MvpDemoApplication
{
	public interface IPhonebookView
	{
		void SuspendLayout();

		void ResumeLayout();

		DataGridView ContactsGrid { get; }

		Button SaveButton { get; }
	}
}
