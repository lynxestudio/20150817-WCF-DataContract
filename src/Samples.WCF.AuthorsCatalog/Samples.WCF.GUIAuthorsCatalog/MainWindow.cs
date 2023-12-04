using System;
using Gtk;
using System.ServiceModel;
using System.Collections.Generic;
using Samples.WCF.AuthorsCatalog;

public partial class MainWindow: Gtk.Window
{
	ListStore authorsListStore = null;

	public MainWindow () : base (Gtk.WindowType.Toplevel)
	{
		Build ();
	}

	protected void OnDeleteEvent (object sender, DeleteEventArgs a)
	{
		Application.Quit ();
		a.RetVal = true;
	}

	protected void OnBtnCreateClicked (object sender, EventArgs e)
	{
		lbCstatus.Text = string.Empty;
		try {
			var proxy = Getproxy();
			Author a = new Author{
				FirstName = txtFirstName.Text,
				LastName = txtLastName.Text,
				BirthDate = calBirthdate.Date,
				Gender = chkGender.Active
			};
			lbCstatus.Text = proxy.CreateAuthor(a);
		} catch (Exception ex) {
			lbCstatus.Text = ex.Message;
		}
	}

	protected void OnBtnRefreshClicked (object sender, EventArgs e)
	{
		lbQstatus.Text = string.Empty;
		try {
			var proxy = Getproxy();
			List<Author> authors = proxy.GetAuthors();
			AddColumns ();
			authorsListStore = new ListStore(typeof(int),
				typeof(string),
				typeof(string),
				typeof(string),
				typeof(string));
			foreach (var item in authors) {
				authorsListStore.AppendValues(item.Id,
					item.FirstName,
					item.LastName,
					(item.BirthDate.HasValue == true ? 
						item.BirthDate.Value.ToString("MM/dd/yyyy") : "null"),
					(item.Gender.HasValue == true ? 
						(item.Gender.Value == true ? "Male" : "Female") : "null"));
			}
			gridAuthors.Model = authorsListStore;
		} catch (Exception ex) {
			lbQstatus.Text = ex.Message;
		}
	}

	IAuthorServiceContract Getproxy()
	{
		EndpointAddress address = new EndpointAddress ("http://localhost:8080/Samples/AuthorsCatalogService");
		BasicHttpBinding binding = new BasicHttpBinding ();
		IAuthorServiceContract proxy = ChannelFactory<IAuthorServiceContract>.CreateChannel (binding,address);
		return proxy;
	}

	void AddColumns()
	{
		string[] titles = {"Id","Name","Lastname","Birthdate","Gender"};
		TreeViewColumn column = null;
		for(var i = 0;i < titles.Length;i++)
		{
			column = new TreeViewColumn (titles[i],new CellRendererText(),"text",i);
			gridAuthors.AppendColumn (column);
		}
	}
}
