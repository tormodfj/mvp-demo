using System.Windows.Forms;

namespace MvpDemoApplication
{
	public partial class PhonebookView : Form, IPhonebookView
	{
		public PhonebookView()
		{
			InitializeComponent();
			PhonebookModel model = new PhonebookModel();
			PhonebookPresenter presenter = new PhonebookPresenter(model, this);
		}

		public DataGridView ContactsGrid
		{
			get { return contactsGrid; }
		}

		public Button SaveButton
		{
			get { return saveButton; }
		}
	}
}
